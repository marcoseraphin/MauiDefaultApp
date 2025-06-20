using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using LocalizationResourceManager.Maui;
using Acr.UserDialogs;
using System.Globalization;

#if DEBUG
using DotNet.Meteor.HotReload.Plugin;
#endif

namespace MauiDefaultApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseUserDialogs()
            .UseLocalizationResourceManager(settings =>
            {
                settings.RestoreLatestCulture(false);
                settings.AddResource(Resources.Resources.ResourceManager);
            })
            .RegisterServices()
            .RegisterPages()    
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
        builder.EnableHotReload();
#endif

        return builder.Build();
    }
}