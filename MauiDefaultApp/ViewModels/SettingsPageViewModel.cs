using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiDefaultApp.Interfaces;
using MauiDefaultApp.Messages;
using MauiDefaultApp.Models;

namespace MauiDefaultApp.ViewModels;

public partial class SettingsPageViewModel(
    ILanguageService languageService,
    IDialogService dialogService,
    IDiagnosticService diagnosticService,
    INavigationService navigationService,
    ISettingsService settingsService) : BaseViewModel
{
    private readonly ILanguageService _languageService = languageService;
    private readonly IDialogService _dialogService = dialogService;
    private readonly IDiagnosticService _diagnosticService = diagnosticService;
    private readonly INavigationService _navigationService = navigationService;
    private readonly ISettingsService _settingsService = settingsService;

    [ObservableProperty]
    private string? _name;

    [RelayCommand]
    private async Task GoBack()
    {
        await _navigationService.GoBackAsync();
    }

    [RelayCommand]
    private async Task SaveSettings()
    {
        _settingsService.Name = "John Doe";
        await _dialogService.AlertAsync("Settings saved", "Settings saved successfully");
    }

    protected override void OnInitialize(IDictionary<string, object> query)
    {
        Name = _settingsService.Name;
    }

} 