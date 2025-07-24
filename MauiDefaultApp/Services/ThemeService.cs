using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MauiDefaultApp.Extensions;
using MauiDefaultApp.Interfaces;
using MauiDefaultApp.Messages;
using Microsoft.Maui.Controls;

namespace MauiDefaultApp.Services;

public class ThemeService : ObservableObject, IThemeService
{
    public AppTheme CurrentTheme => Application.Current!.UserAppTheme;

    public void SetTheme(AppTheme appTheme)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Application.Current!.UserAppTheme = appTheme;

            OnPropertyChanged(nameof(CurrentTheme));

            switch (appTheme)
            {
                case AppTheme.Light:
                case AppTheme.Unspecified when Application.Current!.RequestedTheme == AppTheme.Light:
                    SetStatusBarColor(AppTheme.Light);
                    break;
                case AppTheme.Dark:
                case AppTheme.Unspecified:
                    SetStatusBarColor(AppTheme.Dark);
                    break;
            }

            WeakReferenceMessenger.Default.Send(new AppThemeChangedMessage(CurrentTheme));
        });
    }

    private static void SetStatusBarColor(AppTheme appTheme)
    {
#if ANDROID
        CommunityToolkit.Maui.Core.Platform.StatusBar.SetColor(Application.Current!.Resources.GetColor("SystemGroupedBackground"));

        CommunityToolkit.Maui.Core.Platform.StatusBar.SetStyle(appTheme == AppTheme.Light
            ? StatusBarStyle.DarkContent
            : StatusBarStyle.LightContent);
#endif
    }
}