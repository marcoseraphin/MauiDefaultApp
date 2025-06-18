using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.Messaging;
using MauiDefaultApp.Extensions;
using MauiDefaultApp.Interfaces;
using MauiDefaultApp.Services;
using MauiDefaultApp.ViewModels;
using MauiDefaultApp.Views;

namespace MauiDefaultApp;

public static class Registration
{
    public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton(MediaPicker.Default);
        builder.Services.AddSingleton(FilePicker.Default);
        builder.Services.AddSingleton(Preferences.Default);
        builder.Services.AddSingleton(FileSystem.Current);
        builder.Services.AddSingleton(PhoneDialer.Default);
        builder.Services.AddSingleton(Connectivity.Current);
        builder.Services.AddSingleton(Geolocation.Default);
        builder.Services.AddSingleton(Browser.Default);
        builder.Services.AddSingleton(AppInfo.Current);
        builder.Services.AddSingleton(FileSaver.Default);
        builder.Services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
  
        builder.Services.AddSingleton<IDialogService, DialogService>();
        builder.Services.AddSingleton<IDiagnosticService, DiagnosticService>();
        
        //builder.Services.AddSingleton<IFeatureService>(FeatureService.Instance);

        //#region Add IHttpService related services
        // builder.Services.AddTransient<IHttpService<HttpAuthenticatorDefault>, HttpService<HttpAuthenticatorDefault>>();
        // builder.Services.AddTransient<IHttpService<HttpAuthenticatorForBlueBoxApi>, HttpService<HttpAuthenticatorForBlueBoxApi>>();
        // builder.Services.AddTransient<IHttpService<HttpAuthenticatorForResultConnectorApi>, HttpService<HttpAuthenticatorForResultConnectorApi>>();

        // // Note: Here we make use of keyed service registration to dynamically resolve IHttpAuthenticator
        // // implementations based on their associated keys at runtime.
        // // Otherwise (with '.AddSingleton<IHttpAuth..., HttpAuth...>()'), last singleton authenticator service,
        // // which was registered, would just override previous registrations.
        // builder.Services.AddKeyedSingleton<IHttpAuthenticator, HttpAuthenticatorDefault>(nameof(HttpAuthenticatorDefault));
        // builder.Services.AddKeyedSingleton<IHttpAuthenticator, HttpAuthenticatorForBlueBoxApi>(nameof(HttpAuthenticatorForBlueBoxApi));
        // builder.Services.AddKeyedSingleton<IHttpAuthenticator, HttpAuthenticatorForResultConnectorApi>(nameof(HttpAuthenticatorForResultConnectorApi));
        // #endregion

        // // Default HTTP client (named as recommended here: https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.httpclientfactoryservicecollectionextensions.addhttpclient)
        // builder.Services.AddHttpClient(Microsoft.Extensions.Options.Options.DefaultName)
        //     .ConfigurePrimaryHttpMessageHandler(HttpHelper.GetNativeMessageHandler)
        //     .AddStandardResilienceHandler();

        return builder;
    }

    public static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
    {
        builder.Services.AddTransientWithShellRoute<MainPage, MainPageViewModel>();
        return builder;
    }

//     public static MauiAppBuilder RegisterSentry(this MauiAppBuilder builder)
//     {
// #if !HOTRESTART
//         builder.UseSentry(options =>
//         {
//             // The DSN is the only required setting.
//             options.Dsn = "https://414f8e65f750cb54623176831f4a9aee@o4506020215586816.ingest.sentry.io/4506020217815040";

//             // Use debug mode if you want to see what the SDK is doing.
//             // Debug messages are written to stdout with Console.Writeline,
//             // and are viewable in your IDE's debug console or with 'adb logcat', etc.
//             // This option is not recommended when deploying your application.

// #if DEBUG
//             options.Debug = false;
//             options.TracesSampleRate = 0.0;
// #else
//             options.Debug = false;
// #endif
//             options.AutoSessionTracking = true;
//             options.StackTraceMode = StackTraceMode.Enhanced;
//             options.IsGlobalModeEnabled = true;

//             // Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
//             // We recommend adjusting this value in production.
//             options.TracesSampleRate = 0.8;
//             options.AttachStacktrace = true;

//             // Other Sentry options can be set here.
//         });
// #endif
//         return builder;
//     }

//     public static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
//     {
//         builder.ConfigureLifecycleEvents(events =>
//         {
// #if IOS 
//             events.AddiOS(iOS => iOS.WillFinishLaunching((_, __) =>
//             {
//                 Plugin.Firebase.Core.Platforms.iOS.CrossFirebase.Initialize();
//                 Plugin.Firebase.CloudMessaging.FirebaseCloudMessagingImplementation.Initialize();
//                 return false;
//             }));
// #elif ANDROID
//             events.AddAndroid(android => android.OnCreate((activity, _) =>
//             Plugin.Firebase.Core.Platforms.Android.CrossFirebase.Initialize(activity)));
// #endif
//         });

//         return builder;
//     }
}