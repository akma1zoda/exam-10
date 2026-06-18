namespace Application.Interfaces;

public interface IMemoryCacheService
{
     T? GetAsync<T>(string key);
     void SetAsync<T>(string key, T value, int minutes);
     void RemoveAsync(string key);
}