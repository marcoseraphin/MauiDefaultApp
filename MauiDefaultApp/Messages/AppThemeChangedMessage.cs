using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiDefaultApp.Messages;

public class AppThemeChangedMessage(AppTheme value) : ValueChangedMessage<AppTheme>(value);
