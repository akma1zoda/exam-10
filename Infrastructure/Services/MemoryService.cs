using Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services;

public class MemoryService(IMemoryCache memoryCache, ILogger<MemoryService> logger) : IMemoryCacheService
{
    public T? GetAsync<T>(string key)
    {
        var data = memoryCache.Get<T>(key);
        return data;
    }

    public void SetAsync<T>(string key, T value, int minutes)
    {
        var cachOptions = new MemoryCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(minutes),
            SlidingExpiration = TimeSpan.FromMinutes(minutes)
        };
        memoryCache.Set(key, value, cachOptions);
    }

    public void RemoveAsync(string key)
    {
        memoryCache.Remove(key);
    }
}