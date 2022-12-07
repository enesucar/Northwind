using Microsoft.Extensions.Caching.Memory;
using System.Collections;
using System.Reflection;

namespace WebAPI.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public object? Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public TItem? Get<TItem>(string key)
        {
            return _memoryCache.Get<TItem>(key);
        }

        public void Set(string key, object value, int minutes)
        {
            MemoryCacheEntryOptions options = new()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(minutes),
            };
            _memoryCache.Set(key, value, options);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var coherentState = typeof(MemoryCache).GetField("_coherentState", BindingFlags.NonPublic | BindingFlags.Instance);
            var coherentStateValue = coherentState.GetValue(_memoryCache);
            var entriesCollection = coherentStateValue.GetType().GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
            var entriesCollectionValue = entriesCollection.GetValue(coherentStateValue) as ICollection;
            var keys = new List<string>();

            if (entriesCollectionValue != null)
            {
                foreach (var item in entriesCollectionValue)
                {
                    var methodInfo = item.GetType().GetProperty("Key");
                    var val = methodInfo.GetValue(item);
                    keys.Add(val.ToString());
                }
             
                keys = keys.Where(o => o.Contains(pattern)).ToList();

                foreach (var item in keys)
                {
                    Remove(item);
                }
            }
        }

        public void RemoveAll()
        {
            _memoryCache.Dispose();
        }

        public bool Contains(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }
    }
}
