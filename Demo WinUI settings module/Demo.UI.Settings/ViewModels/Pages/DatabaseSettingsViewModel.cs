﻿using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging; // added manually - fix Cancel method
using Demo.UI.Navigation.Models;
using Demo.UI.Settings.Views.Pages;

namespace Demo.UI.Settings.ViewModels.Pages;

/// <summary>
/// ViewModel for the database settings page.
/// </summary>
internal partial class DatabaseSettingsViewModel : ObservableRecipient
{
    /// <summary>
    /// Gets or sets the connection string.
    /// </summary>
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveConnectionStringCommand))]
    internal partial string ConnectionString { get; set; }

    /// <summary>
    /// Gets a value indicating whether the connection string can be saved.
    /// </summary>
    internal bool CanSaveConnectionString => !string.IsNullOrWhiteSpace(ConnectionString);

    /// <summary>
    /// Saves the connection string to the settings.
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanSaveConnectionString))]
    internal void SaveConnectionString()
    {
        // Save the connection string to the settings.
        Debug.WriteLine($"Saving connection string: {ConnectionString}");
    }

    /// <summary>
    /// Cancels the operation and navigates back to the settings page.
    /// </summary>
    [RelayCommand]
    internal void Cancel()
    {
        // Clear data
        ConnectionString = string.Empty;

        Messenger.Send(new NavigateToPageMessage(typeof(SettingsPage)));
    }
}
