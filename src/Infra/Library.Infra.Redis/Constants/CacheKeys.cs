namespace Library.Infra.Redis.Constants;

public class CacheKeys
{
    private static readonly string _prefix = "Library";
    public static string PrefixWithEnvironment(string environmentName) => $"{_prefix}_{environmentName.ToLowerInvariant()}_";
}
