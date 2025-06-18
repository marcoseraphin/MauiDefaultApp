namespace MauiDefaultApp.Interfaces;

public interface IDialogService
{
    Task AlertAsync(string? message, string? title = null, string? cancel = "OK");
    Task<bool> ConfirmAsync(string? message, string? title = null, string? accept = "OK", string? cancel = "Cancel");
    Task<string?> DisplayPromptAsync(string? message, string? title = null, string? accept = "OK", string? cancel = "Cancel", string? placeholder = null, int maxLength = -1, Keyboard? keyboard = null, string? initialValue = "");
    Task<string?> DisplayActionSheetAsync(string? title, string? cancel, string? destruction, string[] buttons);
    void ShowLoading(string? message = null);
    void HideHud();
    Task<string> ActionSheetAsync(string? title, string? cancel, string? destructive, CancellationToken? cancelToken = null, params string[] buttons);
    Task ShowToastAsync(string? message, TimeSpan? dismissTimer = null);
    Task ShowSuccesToastAsync(string? message);
    Task ShowErrorToastAsync(string? message);
}
