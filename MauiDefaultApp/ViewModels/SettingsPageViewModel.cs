using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiDefaultApp.Interfaces;
using MauiDefaultApp.Messages;
using MauiDefaultApp.Models;

namespace MauiDefaultApp.ViewModels;

public partial class SettingsPageViewModel : BaseViewModel
{
    private readonly ILanguageService _languageService;
    private readonly IDialogService _dialogService;
    private readonly IDiagnosticService _diagnosticService;
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private AppLanguage _selectedLanguage = AppLanguage.German;

    [ObservableProperty]
    private List<AppLanguage> _availableLanguages = new()
    {
        AppLanguage.Automatic,
        AppLanguage.German,
        AppLanguage.English
    };

    public SettingsPageViewModel(
        ILanguageService languageService,
        IDialogService dialogService,
        IDiagnosticService diagnosticService,
        INavigationService navigationService)
    {
        _languageService = languageService;
        _dialogService = dialogService;
        _diagnosticService = diagnosticService;
        _navigationService = navigationService;
    }

    partial void OnSelectedLanguageChanged(AppLanguage value)
    {
        _ = SetLanguageAsync(value);
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await _navigationService.GoBackAsync();
    }

    private async Task SetLanguageAsync(AppLanguage language)
    {
        try
        {
            _languageService.SetUserInterfaceLanguage(language);
            WeakReferenceMessenger.Default.Send(new AppLanguageSelectedMessage(language));
        }
        catch (Exception ex)
        {
            await _dialogService.AlertAsync($"An error occurred while changing language: {ex.Message}", "Error", "OK");
            _diagnosticService.WriteException(ex);
        }
    }
} 