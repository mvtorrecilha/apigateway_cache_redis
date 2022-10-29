namespace Library.Infra.Redis.Repositories;

public interface ICacheRepository
{
    /// <summary>
    /// Gets the item from cache.
    /// </summary>
    /// <typeparam name="T">Type of the item in cache.</typeparam>
    /// <param name="key">Key of the item in cache.</param>
    /// <param name="objectName">The object name used to compose the cache key</param>
    /// <returns>The cached item.</returns>
    Task<T> GetItemAsync<T>(string key, string objectName);

    /// <summary>
    /// Gets item from cache with the specified key.
    /// </summary>
    /// <typeparam name="T">Type of the item</typeparam>
    /// <param name="key">Key of the item in cache.</param>
    /// <returns>The cached item.</returns>
    Task<T> GetItemWithCustomKeyAsync<T>(string key);

    /// <summary>
    /// Sets the item in cache.
    /// </summary>
    /// <typeparam name="T">Type of the item.</typeparam>
    /// <param name="key">Key of the item to be stored.</param>
    /// <param name="objectName">The object name used to compose the cache key.</param>
    /// <param name="item">Item to be stored.</param>
    /// <param name="lifeTime">Optional life time of the item.</param>
    /// <returns>Async operation.</returns>
    Task SetItemAsync<T>(string key, string objectName, T item, TimeSpan? lifeTime = default);

    /// <summary>
    /// Sets them item in cache with the specified key.
    /// </summary>
    /// <typeparam name="T">Type of the item</typeparam>
    /// <param name="key">Key of the item to be stored.</param>
    /// <param name="item">Item to be stored.</param>
    /// <param name="lifeTime">Optional life time of the item.</param>
    /// <returns>Async operation.</returns>
    Task SetItemWithCustomKeyAsync<T>(string key, T item, TimeSpan? lifeTime = default);

    /// <summary>
    /// Remove the item from cache.
    /// </summary>
    /// <param name="key">Key of the item.</param>
    /// <param name="objectName">Name of the object to compose the cache key.</param>
    /// <returns></returns>
    Task RemoveAsync(string key, string objectName);

    /// <summary>
    /// Delete all keys from cache.
    /// </summary>
    /// <param name="keys">keys of user by object.</param>
    /// <returns></returns>
    Task DeleteKeysAsync(string[] keys);
}
