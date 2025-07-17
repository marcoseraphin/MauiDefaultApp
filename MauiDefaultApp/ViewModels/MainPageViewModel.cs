using System.Globalization;
using Acr.UserDialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LocalizationResourceManager.Maui;
using MauiDefaultApp.Interfaces;
using MauiDefaultApp.Messages;
using MauiDefaultApp.Models;
using MauiDefaultApp.ViewModels;
using MauiDefaultApp.Views;

namespace MauiDefaultApp.ViewModels;

public partial class MainPageViewModel(
    ILocalizationResourceManager localizationResourceManager,
    IUserDialogs userDialogs,
    ILanguageService languageService,
    IDialogService dialogService,
    IDiagnosticService diagnosticService,
    INavigationService navigationService) : BaseViewModel
{
    private readonly ILanguageService languageService = languageService;
    private readonly IDialogService dialogService = dialogService;
    private readonly IDiagnosticService diagnosticService = diagnosticService;
    private readonly INavigationService navigationService = navigationService;

    [ObservableProperty]
    private string _title = localizationResourceManager.GetValue(nameof(Resources.Resources.APP_NAME));

    [ObservableProperty]
    private int _count;

    [ObservableProperty]
    private string _counterText = "Click me";

    [ObservableProperty]
    private string _languageButtonText = localizationResourceManager.GetValue(nameof(Resources.Resources.LANGUAGE_BUTTON));

    [ObservableProperty]
    private AppLanguage _selectedLanguage = AppLanguage.German;

    [RelayCommand]
    private async Task SwitchLanguageAsync()
    {
        if (SelectedLanguage == AppLanguage.German)
            await SetLanguageAsync(AppLanguage.English);
        else
            await SetLanguageAsync(AppLanguage.German);

        LanguageButtonText = localizationResourceManager.GetValue(nameof(Resources.Resources.LANGUAGE_BUTTON));
        Title = localizationResourceManager.GetValue(nameof(Resources.Resources.APP_NAME));
    }

    [RelayCommand]
    private async Task NavigateToSettings()
    {
        await navigationService.GoToAsync($"{Routes.SettingsPage}");
    }

    private async Task SetLanguageAsync(AppLanguage language)
    {
        try
        {
            SelectedLanguage = language;
            languageService.SetUserInterfaceLanguage(SelectedLanguage);

            // send the message to all subscribers to update the language settings
            WeakReferenceMessenger.Default.Send(new AppLanguageSelectedMessage(SelectedLanguage));
        }
        catch (Exception ex)
        {
            await dialogService.AlertAsync($"An error occurred while updating personal information: {ex.Message}", "Error", "OK");
            diagnosticService.WriteException(ex);
        }
    }

    [RelayCommand]
    private async Task CounterClicked()
    {
        Count++;
        CounterText = Count == 1 ? $"Clicked {Count} time" : $"Clicked {Count} times";

        if (Count == 5)
        {
            await userDialogs.AlertAsync(CounterText);
        }
    }
}