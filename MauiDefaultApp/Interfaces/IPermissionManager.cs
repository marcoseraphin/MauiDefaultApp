using MauiDefaultApp.Models;
using Microsoft.Maui.ApplicationModel;

namespace MauiDefaultApp.Interfaces;

public interface IPermissionManager
{
    Task<bool> CheckAndRequestPermissionAsync(Permission permission);
    Task PromptAppSettingsPageAsync(Permission permissions);

}