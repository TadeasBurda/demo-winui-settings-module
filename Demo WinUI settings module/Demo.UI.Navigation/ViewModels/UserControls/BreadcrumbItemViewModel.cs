using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Demo.UI.Navigation.Models;

namespace Demo.UI.Navigation.ViewModels.UserControls;

/// <summary>
/// ViewModel for a breadcrumb item.
/// </summary>
internal partial class BreadcrumbItemViewModel : ObservableRecipient
{
    /// <summary>
    /// Gets or sets the type of the page associated with the breadcrumb item.
    /// </summary>
    internal Type? PageType { get; set; }

    /// <summary>
    /// Handles the breadcrumb item click event.
    /// </summary>
    [RelayCommand]
    internal void OnBreadcrumbItemClick()
    {
        if (PageType != null)
        {
            Messenger.Send(new NavigateToPageMessage(PageType));
        }
    }
}
