using Library.Infra.Redis.Constants;
using Library.Infra.Redis.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Library.Infra.Redis.Extensions;

public static class RedisDiExtensions
{
    public static IServiceCollection AddRedisRepository(this IServiceCollection services, IConfiguration config, string environmentName)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = config.GetConnectionString("Redis");
            options.InstanceName = CacheKeys.PrefixWithEnvironment(environmentName);
        });

        services
            .AddSingleton(sp =>
            {
                return ConnectionMultiplexer.Connect(config.GetConnectionString("Redis"));
            });

        services.AddTransient<ICacheRepository, RedisCacheRepository>();

        return services;
    }
}
