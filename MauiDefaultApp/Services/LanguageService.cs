using LocalizationResourceManager.Maui;
using System.Globalization;
using MauiDefaultApp.Models;

public class LanguageService(ILocalizationResourceManager localizationManager) : ILanguageService
{
    private readonly ILocalizationResourceManager _localizationManager = localizationManager;

    public void SetUserInterfaceLanguage(AppLanguage language)
    {
        // if the default culture is something other than English or German, English will be used as a fallback
        _localizationManager.CurrentCulture = language switch
        {
            AppLanguage.Automatic => _localizationManager.DefaultCulture,
            AppLanguage.German => CultureInfo.CreateSpecificCulture(AppConst.LanguageLetterGerman),
            AppLanguage.English => CultureInfo.CreateSpecificCulture(AppConst.LanguageLetterEnglish),
            _ => _localizationManager.DefaultCulture
        };
    }

    public List<LanguageModel> GetAvailableLanguages() => [
            new() { Id = (int)AppLanguage.Automatic, DisplayName = _localizationManager["LANGUAGE_AUTOMATIC"] },
            new() { Id = (int)AppLanguage.German, DisplayName = _localizationManager["LANGUAGE_GERMAN"] },
            new() { Id = (int)AppLanguage.English, DisplayName = _localizationManager["LANGUAGE_ENGLISH"] }
        ];
}