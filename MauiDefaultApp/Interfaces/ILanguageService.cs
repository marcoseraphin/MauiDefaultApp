using MauiDefaultApp.Models;

public interface ILanguageService
{
    void SetUserInterfaceLanguage(AppLanguage language);

    List<LanguageModel> GetAvailableLanguages();
}