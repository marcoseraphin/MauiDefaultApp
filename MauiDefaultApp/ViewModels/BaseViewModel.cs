using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiDefaultApp.ViewModels;

public abstract class BaseViewModel : ObservableObject, IQueryAttributable
{
    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        OnInitialize(query);
    }

    protected virtual void OnInitialize(IDictionary<string, object> query) { }

}