using ServiceStack.Caching;
using ServiceStack.Redis;

namespace WebAPI.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly IRedisClient _redisClient;

        public RedisCacheManager()
        { 
            _redisClient = new RedisClient(new RedisEndpoint("localhost", 6379));
        }

        public object? Get(string key)
        {
            return _redisClient.Get<object>(key);
        }

        public TItem? Get<TItem>(string key)
        {
            return _redisClient.Get<TItem>(key); 
        }

        public void Set(string key, object value, int minutes)
        {
            _redisClient.Set(key, value, TimeSpan.FromMinutes(minutes));
        }

        public void Remove(string key)
        {
            _redisClient.Remove(key);
        }

        public void RemoveAll()
        {
            _redisClient.FlushAll();
        }

        public void RemoveByPattern(string pattern)
        {
            _redisClient.RemoveByPattern($"*{pattern}*");
        }

        public bool Contains(string key)
        {
            return _redisClient.ContainsKey(key);
        }
    }
}
