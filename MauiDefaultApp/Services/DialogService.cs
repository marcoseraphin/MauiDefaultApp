
using Acr.UserDialogs;
using CommunityToolkit.Maui.Core;
using MauiDefaultApp.Extensions;
using MauiDefaultApp.Interfaces;

namespace MauiDefaultApp.Services;

public sealed class DialogService(IUserDialogs userDialogs) : IDialogService
{
    private readonly IUserDialogs _userDialogs = userDialogs;

    public Task AlertAsync(string? message, string? title = null, string? cancel = "OK")
    => Shell.Current.DisplayAlert(title, message, cancel);

    public Task<bool> ConfirmAsync(string? message, string? title = null, string? accept = "OK", string? cancel = "Cancel")
    => Shell.Current.DisplayAlert(title, message, accept, cancel);

    public Task<string?> DisplayPromptAsync(string? message, string? title = null, string? accept = "OK", string? cancel = "Cancel", string? placeholder = null, int maxLength = -1, Keyboard? keyboard = null, string? initialValue = "")
    => Shell.Current.DisplayPromptAsync(title, message, accept, cancel, placeholder, maxLength, keyboard, initialValue);

    public Task<string?> DisplayActionSheetAsync(string? title, string? cancel, string? destruction, string[] buttons)
    => Shell.Current.DisplayActionSheet(title, cancel, destruction, buttons);

    public void ShowLoading(string? message = null)
    => _userDialogs.ShowLoading(message);

    public void HideHud()
    => _userDialogs.HideLoading();

    public Task<string> ActionSheetAsync(string? title, string? cancel, string? destructive, CancellationToken? cancelToken = null, params string[] buttons)
    => _userDialogs.ActionSheetAsync(title, cancel, destructive, cancelToken, buttons);

    public Task ShowToastAsync(string? message, TimeSpan? dismissTimer = null)
    {
        CancellationTokenSource cancellationTokenSource = new();

        var snackbarOptions = new SnackbarOptions
        {
            BackgroundColor = Colors.DarkGray,
            TextColor = Colors.White,
            ActionButtonTextColor = Colors.White,
            CornerRadius = new CornerRadius(10),
            Font = Microsoft.Maui.Font.SystemFontOfSize(16),
            ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(14),

        };
        var snackbar = CommunityToolkit.Maui.Alerts.Snackbar.Make(message ?? string.Empty, null, string.Empty, TimeSpan.FromSeconds(5), snackbarOptions);
        return snackbar.Show(cancellationTokenSource.Token);
    }

    public Task ShowSuccesToastAsync(string? message)
    {
        CancellationTokenSource cancellationTokenSource = new();

        var snackbarOptions = new SnackbarOptions
        {
            BackgroundColor = Colors.Green,
            TextColor = Colors.White,
            ActionButtonTextColor = Colors.White,
            CornerRadius = new CornerRadius(10),
            Font = Microsoft.Maui.Font.SystemFontOfSize(16),
            ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(14)
        };
        var snackbar = CommunityToolkit.Maui.Alerts.Snackbar.Make(message ?? string.Empty, null, string.Empty, TimeSpan.FromSeconds(3), snackbarOptions);

        return snackbar.Show(cancellationTokenSource.Token);
    }

    public Task ShowErrorToastAsync(string? message)
    {
        CancellationTokenSource cancellationTokenSource = new();

        var snackbarOptions = new SnackbarOptions
        {
            BackgroundColor = Application.Current!.Resources.GetColor("SystemOrange") ?? Colors.Transparent,
            TextColor = Colors.White,
            ActionButtonTextColor = Colors.White,
            CornerRadius = new CornerRadius(10),
            Font = Microsoft.Maui.Font.SystemFontOfSize(16),
            ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(14)
        };
        var snackbar = CommunityToolkit.Maui.Alerts.Snackbar.Make(message ?? string.Empty, null, string.Empty, TimeSpan.FromSeconds(3), snackbarOptions);

        return snackbar.Show(cancellationTokenSource.Token);
    }
}
