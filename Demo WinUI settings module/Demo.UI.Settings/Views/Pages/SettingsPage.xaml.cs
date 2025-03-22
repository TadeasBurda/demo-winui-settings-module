using System;
using Demo.UI.Navigation.Models;
using Demo.UI.Settings.ViewModels.Pages;
using Microsoft.UI.Xaml.Controls;

namespace Demo.UI.Settings.Views.Pages;

/// <summary>
/// Represents the settings page.
/// </summary>
public sealed partial class SettingsPage : Page, IBreadcrumbPage
{
    /// <summary>
    /// Gets the ViewModel for the settings page.
    /// </summary>
    internal SettingsViewModel ViewModel { get; } =
        DependencyConfiguration.GetService<SettingsViewModel>();

    /// <summary>
    /// Gets the title of the breadcrumb page.
    /// </summary>
    public string Title => "Settings";

    /// <summary>
    /// Gets the type of the parent page, if any.
    /// </summary>
    public Type? ParentPage => null;

    /// <summary>
    /// Initializes a new instance of the <see cref="SettingsPage"/> class.
    /// </summary>
    public SettingsPage()
    {
        InitializeComponent();
        DataContext ??= ViewModel;
    }
}
