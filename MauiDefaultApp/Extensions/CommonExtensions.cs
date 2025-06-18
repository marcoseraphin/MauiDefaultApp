using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls;

namespace MauiDefaultApp.Extensions;

public static class CommonExtensions
{
    public static T TryGetValue<T>(this IDictionary<string, object> query, string key)
          => query?.TryGetValue(key, out var outValue) == true && outValue is T outTValue ? outTValue : default!;

    public static Color? GetColor(this ResourceDictionary dict, string colorKey)
    {
        if (!dict.TryGetValue(colorKey, out var outValue))
        {
            throw new ArgumentException($"Color key {colorKey} not found in resource dictionary");
        }

        var appThemeColor = (AppThemeColor)outValue;
        return Application.Current!.RequestedTheme switch
        {
            AppTheme.Light => appThemeColor.Light,
            AppTheme.Dark => appThemeColor.Dark,
            _ => appThemeColor.Default,
        };
    }
}