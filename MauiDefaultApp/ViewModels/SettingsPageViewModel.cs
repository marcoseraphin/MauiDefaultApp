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
    INavigationService navigationService) : BaseViewModel
{
    private readonly ILanguageService _languageService = languageService;
    private readonly IDialogService _dialogService = dialogService;
    private readonly IDiagnosticService _diagnosticService = diagnosticService;
    private readonly INavigationService _navigationService = navigationService;

    [RelayCommand]
    private async Task GoBack()
    {
        await _navigationService.GoBackAsync();
    }

} 