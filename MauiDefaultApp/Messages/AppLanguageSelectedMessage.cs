using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using MauiDefaultApp.Models;

namespace MauiDefaultApp.Messages;

public class AppLanguageSelectedMessage(AppLanguage value) : ValueChangedMessage<AppLanguage>(value);