using System.ComponentModel;
using CommunityToolkit.Maui;

namespace MauiDefaultApp.Extensions;

public static class NavigationExtensions
{
    public static IServiceCollection AddTransientWithShellRoute<TPage, TViewModel>(this IServiceCollection serviceCollection)
        where TPage : NavigableElement
        where TViewModel : class, INotifyPropertyChanged
        => serviceCollection.AddTransientWithShellRoute<TPage, TViewModel>(typeof(TPage).Name!);

    public static IServiceCollection AddTransientWithShellRoute<TPage>(this IServiceCollection serviceCollection)
        where TPage : NavigableElement
    {
        Routing.RegisterRoute(typeof(TPage).Name!, typeof(TPage));
        return serviceCollection.AddTransient<TPage>();
    }
}