namespace Library.Infra.Redis.Configuration;

public class CacheOptions
{
    public const string CacheSectionName = "Cache";

    public CacheOptions()
    {
        DefaultTimeout = TimeSpan.FromHours(1);
        CustomTimeouts = new Dictionary<string, TimeSpan>(StringComparer.OrdinalIgnoreCase);
    }

    public TimeSpan DefaultTimeout { get; set; }

    public bool IsCacheDisabled { get; set; }

    public Dictionary<string, TimeSpan> CustomTimeouts { get; set; }
}
