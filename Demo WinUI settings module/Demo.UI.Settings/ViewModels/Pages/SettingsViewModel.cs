using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging; // added manually - fix NavigateToDatabaseSettingsPage method
using Demo.UI.Navigation.Models;
using Demo.UI.Settings.Views.Pages;

namespace Demo.UI.Settings.ViewModels.Pages;

/// <summary>
/// ViewModel for the settings page.
/// </summary>
internal partial class SettingsViewModel : ObservableRecipient
{
    /// <summary>
    /// Navigates to the database settings page.
    /// </summary>
    [RelayCommand]
    internal void NavigateToDatabaseSettingsPage() =>
        Messenger.Send(new NavigateToPageMessage(typeof(DatabaseSettingsPage)));
}
