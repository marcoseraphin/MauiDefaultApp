using LocalizationResourceManager.Maui;
using MauiDefaultApp.Interfaces;
using MauiDefaultApp.Models;
using MauiDefaultApp.Resources;

public class PermissionsManager(IDialogService dialogService, ILocalizationResourceManager localizationManager, IAppInfo appInfo) : IPermissionManager
{
    public async Task<bool> CheckAndRequestPermissionAsync(Permission permission)
    {
        switch (permission)
        {
            case Permission.Location:
            {
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status == PermissionStatus.Granted)
                {
                    return true;
                }

                if (!await ShowPermissionRequestDialogAsync(permission))
                {
                    return false;
                }

                var result = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                return result == PermissionStatus.Granted;
            }
            case Permission.Notification:
            {
                var status = await Permissions.CheckStatusAsync<NotificationPermission>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<NotificationPermission>();
                }

                return status == PermissionStatus.Granted;
            }
            case Permission.Camera:
            {
                var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.Camera>();
                }

                return status == PermissionStatus.Granted;
            }
            case Permission.Calendar:
            {
#if ANDROID
                var statusRead = await Permissions.CheckStatusAsync<Permissions.CalendarRead>();
                if (statusRead != PermissionStatus.Granted)
                {
                    statusRead = await Permissions.RequestAsync<Permissions.CalendarRead>();
                }
#else
                var statusRead = PermissionStatus.Granted;
#endif

                var statusWrite = await Permissions.CheckStatusAsync<Permissions.CalendarWrite>();
                if (statusWrite != PermissionStatus.Granted)
                {
                    statusWrite = await Permissions.RequestAsync<Permissions.CalendarWrite>();
                }

                return statusRead == PermissionStatus.Granted && statusWrite == PermissionStatus.Granted;
            }

            default:
            {
                return false;
            }
        }
    }

    public async Task<bool> ShowPermissionRequestDialogAsync(Permission permission)
    {
        return await dialogService.ConfirmAsync(
            permission.GetRequestDisplayMessage(localizationManager),
            permission.GetRequestDisplayHeading(localizationManager),
            localizationManager.GetValue(nameof(MauiDefaultApp.Resources.Resources.BTN_OK)),
            localizationManager.GetValue(nameof(MauiDefaultApp.Resources.Resources.BTN_CANCEL)));
    }

    public async Task PromptAppSettingsPageAsync(Permission permission)
    {
        if (await dialogService.ConfirmAsync(permission.GetRequestDisplayHeading(localizationManager),
                permission.GetRationaleMessage(localizationManager),
                localizationManager.GetValue(nameof(MauiDefaultApp.Resources.Resources.SETTINGS_PAGE_TITLE)),
                localizationManager.GetValue(nameof(MauiDefaultApp.Resources.Resources.BTN_CANCEL))))
        {
            appInfo.ShowSettingsUI();
        }
    }
}
