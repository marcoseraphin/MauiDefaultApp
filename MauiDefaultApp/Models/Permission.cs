using LocalizationResourceManager.Maui;
using MauiDefaultApp.Resources;

namespace MauiDefaultApp.Models;

public enum Permission
{
    Location,
    Notification,
    Camera,
    Calendar
}

public static class PermissionsExtensions
{
    public static string GetRequestDisplayHeading(this Permission permission, ILocalizationResourceManager localizationManager) =>
        permission switch
        {
            Permission.Location =>
                localizationManager.GetValue(nameof(Resources.Resources.LOCATION_PERMISSION_HEADER)),
            Permission.Notification =>
                localizationManager.GetValue(nameof(Resources.Resources.NOTIFICATION_PERMISSION_HEADER)),
            Permission.Camera =>
               localizationManager.GetValue(nameof(Resources.Resources.CAMERA_PERMISSION_HEADER)),
            Permission.Calendar =>
                localizationManager.GetValue(nameof(Resources.Resources.CALENDAR_PERMISSION_HEADER)),
            _ => throw new ArgumentException($"Unrecognised permissions : {permission}")
        };

    public static string GetRequestDisplayMessage(this Permission permission, ILocalizationResourceManager localizationManager) =>
        permission switch
        {
             Permission.Location =>
                localizationManager.GetValue(nameof(Resources.Resources.LOCATION_PERMISSION_MESSAGE_RATIONALE)),
            Permission.Notification =>
                localizationManager.GetValue(nameof(Resources.Resources.NOTIFICATION_PERMISSION_MESSAGE_RATIONALE)),
            Permission.Camera =>
                localizationManager.GetValue(nameof(Resources.Resources.CAMERA_PERMISSION_MESSAGE_RATIONALE)),
            Permission.Calendar =>
                localizationManager.GetValue(nameof(Resources.Resources.CALENDAR_PERMISSION_MESSAGE_RATIONALE)),
            _ => throw new ArgumentException($"Unrecognised permissions : {permission}")
        };

    public static string GetRationaleMessage(this Permission permission, ILocalizationResourceManager localizationManager) =>
        permission switch
        {
            Permission.Location =>
                localizationManager.GetValue(nameof(Resources.Resources.LOCATION_PERMISSION_MESSAGE_RATIONALE)),
            Permission.Notification =>
                localizationManager.GetValue(nameof(Resources.Resources.NOTIFICATION_PERMISSION_MESSAGE_RATIONALE)),
            Permission.Camera =>
                localizationManager.GetValue(nameof(Resources.Resources.CAMERA_PERMISSION_MESSAGE_RATIONALE)),
            Permission.Calendar =>
                localizationManager.GetValue(nameof(Resources.Resources.CALENDAR_PERMISSION_MESSAGE_RATIONALE)),
            _ => throw new ArgumentException($"Unrecognised permissions : {permission}")
        };
}
