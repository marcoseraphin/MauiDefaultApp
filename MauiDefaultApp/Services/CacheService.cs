using MonkeyCache.FileStore;
using MauiDefaultApp.Interfaces;

namespace MauiDefaultApp.Services;

public sealed class CacheService : ICacheService
{
    public CacheService()
    {
        Barrel.ApplicationId = "Cache.db";
    }

    public void Add<T>(string key, T data, TimeSpan expireIn) => Barrel.Current.Add(key, data, expireIn);
    public T Get<T>(string key) => Barrel.Current.Get<T>(key);
    public bool IsExpired(string key) => Barrel.Current.IsExpired(key);
    public bool Exists(string key) => Barrel.Current.Exists(key);
    public bool IsAvailable(string key) => Exists(key) && !IsExpired(key);
    public void Empty(params string[] key) => Barrel.Current.Empty(key);
    public void EmptyAll() => Barrel.Current.EmptyAll();
    public IEnumerable<string> GetAllKeys() => Barrel.Current.GetKeys();
}