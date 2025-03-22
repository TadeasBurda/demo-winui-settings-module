using Demo.UI.Navigation.Models;
using Demo.UI.Settings.ViewModels.Pages;
using Microsoft.UI.Xaml.Controls;
using System;

namespace Demo.UI.Settings.Views.Pages;

/// <summary>
/// Represents the database settings page.
/// </summary>
public sealed partial class DatabaseSettingsPage : Page, IBreadcrumbPage
{
    /// <summary>
    /// Gets the ViewModel for the database settings page.
    /// </summary>
    internal DatabaseSettingsViewModel ViewModel { get; } =
        DependencyConfiguration.GetService<DatabaseSettingsViewModel>();

    /// <summary>
    /// Gets the title of the breadcrumb page.
    /// </summary>
    public string Title => "Local database";

    /// <summary>
    /// Gets the type of the parent page, if any.
    /// </summary>
    public Type? ParentPage => typeof(SettingsPage);

    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseSettingsPage"/> class.
    /// </summary>
    public DatabaseSettingsPage()
    {
        InitializeComponent();
        DataContext ??= ViewModel;
    }
}
