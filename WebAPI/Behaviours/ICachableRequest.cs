namespace WebAPI.Behaviours
{
    public interface ICachableRequest
    {
        bool BypassCache { get; set; }
        string CacheKey { get; set; }
        TimeSpan? SlidingExpiration { get; set; }
    }
}
