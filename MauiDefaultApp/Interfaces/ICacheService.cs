namespace MauiDefaultApp.Interfaces;

public interface ICacheService
{
    void Add<T>(string key, T data, TimeSpan expireIn);
    T Get<T>(string key);
    bool IsExpired(string key);
    bool Exists(string key);
    bool IsAvailable(string key);
    void Empty(params string[] key);
    void EmptyAll();
    IEnumerable<string> GetAllKeys();
}