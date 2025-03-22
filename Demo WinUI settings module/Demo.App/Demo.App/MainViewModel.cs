using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;

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
}
