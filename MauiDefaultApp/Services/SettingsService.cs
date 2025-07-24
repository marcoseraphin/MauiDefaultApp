
using MauiDefaultApp.Interfaces;
using MauiDefaultApp.Models;

namespace MauiDefaultApp.Services;

public sealed class SettingsService(IPreferences preferences) : ISettingsService
{
    private readonly IPreferences _preferences = preferences;

    public int Theme
    {
        get => _preferences.Get(nameof(Theme), 0);
        set => _preferences.Set(nameof(Theme), value);
    }

    public int Language
    {
        get => _preferences.Get(nameof(Language), (int)AppLanguage.Automatic);
        set => _preferences.Set(nameof(Language), value);
    }

    public string? Name
    {
        get => _preferences.Get(nameof(Name), string.Empty);
        set => _preferences.Set(nameof(Name), value);
    }
}