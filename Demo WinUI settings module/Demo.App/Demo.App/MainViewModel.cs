﻿using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace Demo.App;

/// <summary>
/// Represents the tags used for navigation.
/// </summary>
internal enum NavigationTag
{
    Settings
}

/// <summary>
/// ViewModel for the main page, handling navigation and back button state.
/// </summary>
internal partial class MainViewModel : ObservableObject
{
    /// <summary>
    /// Gets or sets the content frame used for navigation.
    /// </summary>
    internal Frame? ContentFrame { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the back button is enabled.
    /// </summary>
    [ObservableProperty]
    internal partial bool IsBackButtonEnabled { get; set; } = false;

    /// <summary>
    /// Handles the back navigation request.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="args">The event arguments.</param>
    internal void OnNavigationBackRequested(
        NavigationView sender,
        NavigationViewBackRequestedEventArgs args
    )
    {
        if (ContentFrame?.CanGoBack == true)
        {
            ContentFrame.GoBack();
        }

        IsBackButtonEnabled = ContentFrame?.CanGoBack == true;
    }

    /// <summary>
    /// Updates the back button state when navigation occurs.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="args">The event arguments.</param>
    internal void OnContentFrameNavigated(object sender, NavigationEventArgs args)
    {
        if (sender is Frame frame)
        {
            IsBackButtonEnabled = frame.CanGoBack;
        }
    }

    /// <summary>
    /// Handles the selection change in the NavigationView.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="args">The event arguments.</param>
    internal void OnNavigationSelectionChanged(
        NavigationView sender,
        NavigationViewSelectionChangedEventArgs args
    )
    {
        if (
            sender.SelectedItem is NavigationViewItem selectedItem
            && selectedItem.Tag is string tag
        )
        {
            switch (tag)
            {
                case nameof(NavigationTag.Settings):
                    ContentFrame?.Navigate(typeof(SettingsPage));
                    break;
                default:
                    throw new InvalidOperationException("Unknown tag");
            }
        }
    }
}
