using System.ComponentModel;

namespace MauiDefaultApp.Interfaces;

public interface IThemeService : INotifyPropertyChanged
{
    void SetTheme(AppTheme appTheme);
    AppTheme CurrentTheme { get; }
}