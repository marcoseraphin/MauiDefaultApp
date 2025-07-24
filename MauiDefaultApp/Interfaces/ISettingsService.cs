namespace MauiDefaultApp.Interfaces;

public interface ISettingsService
{
    int Theme { get; set; }
    int Language { get; set; }
    string? Name { get; set; }
}