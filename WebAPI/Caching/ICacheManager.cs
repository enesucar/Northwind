using WebAPI.Caching;

namespace WebAPI.Caching
{
    public interface ICacheManager
    {
        object? Get(string key);
        TItem? Get<TItem>(string key); 
        void Set(string key, object value, int minutes);
        void Remove(string key);
        void RemoveByPattern(string pattern);
        void RemoveAll();
        bool Contains(string key);
    }
}