using Library.Infra.Redis.Configuration;
using Library.Infra.Redis.Constants;
using Library.Infra.Redis.Converters;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Text.Json;

namespace Library.Infra.Redis.Repositories;

public class RedisCacheRepository : ICacheRepository
{
    private readonly IDatabase _database;
    private readonly IDistributedCache _cache;
    private readonly ILogger<RedisCacheRepository> _logger;
    private readonly CacheOptions _cacheOptions;

    private static readonly JsonSerializerOptions _jsonOptions =
        new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters =
            {
                    new TimeSpanConverter(),
            }
        };

    public RedisCacheRepository(
            IDistributedCache cache,
            IOptions<CacheOptions> options,
            ConnectionMultiplexer redis,
            ILogger<RedisCacheRepository> logger)
    {
        _cache = cache;
        _logger = logger;
        _cacheOptions = options.Value;
        _database = redis.GetDatabase();
    }

    public async Task<T> GetItemAsync<T>(string key, string objectName)
    {
        var cacheKey = GetItemCacheKey(objectName, key);

        return await GetItemWithCustomKeyAsync<T>(cacheKey);
    }

    public async Task<T> GetItemWithCustomKeyAsync<T>(string key)
    {
        try
        {
            if (_cacheOptions.IsCacheDisabled)
            {
                return default;
            }

            var data = await _cache.GetStringAsync(key);

            if (string.IsNullOrEmpty(data))
            {
                return default;
            }


            try
            {
                var dt = JsonSerializer.Deserialize<T>(data, _jsonOptions);
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return JsonSerializer.Deserialize<T>(data, _jsonOptions);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error retrieving item from cache with message: {ex.Message}.");

            return default;
        }
    }

    public async Task SetItemAsync<T>(string key, string objectName, T item, TimeSpan? lifeTime = default)
    {
        var cacheKey = GetItemCacheKey(objectName, key);
        var cacheExpiration = lifeTime ?? GetExpirationTime(objectName);

        await SetItemWithCustomKeyAsync(cacheKey, item, cacheExpiration);
    }

    public async Task SetItemWithCustomKeyAsync<T>(string key, T item, TimeSpan? lifeTime = default)
    {
        try
        {
            if (_cacheOptions.IsCacheDisabled)
            {
                return;
            }

            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = lifeTime ?? _cacheOptions.DefaultTimeout,
            };

            var serializedItem = JsonSerializer.Serialize(item, _jsonOptions);

            await _cache.SetStringAsync(key, serializedItem, options);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error storing item in cache with message: {ex.Message}.");
        }
    }

    /// <inheritdoc/>        
    public async Task RemoveAsync(string key, string objectName)
    {
        try
        {
            if (_cacheOptions.IsCacheDisabled)
            {
                return;
            }

            var cacheKey = GetItemCacheKey(objectName, key);
            await _cache.RemoveAsync(cacheKey);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error removing item from cache.");
        }
    }

    /// <inheritdoc/>
    public async Task DeleteKeysAsync(string[] keys)
    {
        var prefix = CacheKeys.PrefixWithEnvironment("dev");

        RedisKey[] redisKeys = keys.Select(key => (RedisKey)($"{prefix}{key}")).ToArray();

        await _database.KeyDeleteAsync(redisKeys);
    }

    private string GetItemCacheKey(string entityName, string key) => $"{entityName}_{key}";

    private TimeSpan GetExpirationTime(string entityName)
    {
        if (_cacheOptions.CustomTimeouts.TryGetValue(entityName, out TimeSpan timeSpan))
        {
            return timeSpan;
        }

        return _cacheOptions.DefaultTimeout;
    }
}
