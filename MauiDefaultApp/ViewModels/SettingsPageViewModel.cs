using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LocalizationResourceManager.Maui;
using MauiDefaultApp.Interfaces;
using MauiDefaultApp.Models;
using System.Collections.ObjectModel;

namespace MauiDefaultApp.ViewModels;

public partial class SettingsPageViewModel(
    ILanguageService languageService,
    IDialogService dialogService,
    IDiagnosticService diagnosticService,
    INavigationService navigationService,
    ISettingsService settingsService,
    IThemeService themeService,
    ILocalizationResourceManager localizationResourceManager) : BaseViewModel
{
    private readonly ILanguageService _languageService = languageService;
    private readonly IDialogService _dialogService = dialogService;
    private readonly IDiagnosticService _diagnosticService = diagnosticService;
    private readonly INavigationService _navigationService = navigationService;
    private readonly ISettingsService _settingsService = settingsService;
    private readonly IThemeService _themeService = themeService;

    [ObservableProperty]
    private string _nameLabelText = localizationResourceManager.GetValue(
        nameof(Resources.Resources.NAME_ENTRY_TITLE));
    
    [ObservableProperty]
    private string _nameEntryPlaceholderText = localizationResourceManager.GetValue(
        nameof(Resources.Resources.NAME_ENTRY_PLACEHOLDER));

    private string? _name;
    public string? Name
    {
        get => _name;
        set
        {
            if (SetProperty(ref _name, value))
            {
                _settingsService.Name = value;
            }
        }
    }

    public ObservableCollection<LanguageModel> Languages { get; } =
        new(languageService.GetAvailableLanguages());

    private LanguageModel? _selectedLanguage;
    public LanguageModel? SelectedLanguage
    {
        get => _selectedLanguage;
        set
        {
            if (SetProperty(ref _selectedLanguage, value) && value != null)
            {
                _settingsService.Language = value.Id;
                _languageService.SetUserInterfaceLanguage((AppLanguage)value.Id);
                NameEntryPlaceholderText = localizationResourceManager.GetValue(
                    nameof(Resources.Resources.NAME_ENTRY_PLACEHOLDER));
            }
        }
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await _navigationService.GoBackAsync();
    }

    [RelayCommand]
    private async Task SaveSettings()
    {
        await _dialogService.AlertAsync("Settings saved", "Settings saved successfully");
    }

    [RelayCommand]
    private void SetDarkTheme() => _themeService.SetTheme(AppTheme.Dark);

    [RelayCommand]
    private void SetLightTheme() => _themeService.SetTheme(AppTheme.Light);

    protected override void OnInitialize(IDictionary<string, object> query)
    {
        Name = _settingsService.Name;
        SelectedLanguage = Languages.FirstOrDefault(l => l.Id == _settingsService.Language);
    }
} 