using System.Globalization;
using Acr.UserDialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LocalizationResourceManager.Maui;
using MauiDefaultApp.ViewModels;

namespace MauiDefaultApp.ViewModels;

public partial class MainPageViewModel(ILocalizationResourceManager localizationResourceManager, IUserDialogs userDialogs) : BaseViewModel
{
    [ObservableProperty]
    private string _title = localizationResourceManager.GetValue(nameof(Resources.Resources.APP_NAME));

    [ObservableProperty]
    private int _count;

    [ObservableProperty]
    private string _counterText = "Click me";

    [RelayCommand]
    private async Task CounterClicked()
    {
        Count++;
        CounterText = Count == 1 ? $"Clicked {Count} time" : $"Clicked {Count} times";

        if (Count == 5)
        {
            CultureInfo.CreateSpecificCulture("en");
            await userDialogs.AlertAsync(CounterText);
        }
    }
}