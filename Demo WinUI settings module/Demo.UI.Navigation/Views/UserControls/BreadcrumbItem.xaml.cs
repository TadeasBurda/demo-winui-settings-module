using System;
using Demo.UI.Navigation.ViewModels.UserControls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Demo.UI.Navigation.Views.UserControls;

/// <summary>
/// Represents a breadcrumb item user control.
/// </summary>
public sealed partial class BreadcrumbItem : UserControl
{
    /// <summary>
    /// Gets the ViewModel for the breadcrumb item.
    /// </summary>
    internal BreadcrumbItemViewModel ViewModel { get; } =
        DependencyConfiguration.GetService<BreadcrumbItemViewModel>();

    #region Title

    /// <summary>
    /// Gets or sets the title of the breadcrumb item.
    /// </summary>
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// Identifies the <see cref="Title"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title),
        typeof(string),
        typeof(BreadcrumbItem),
        new PropertyMetadata(default(string))
    );

    #endregion

    #region PageType

    /// <summary>
    /// Gets or sets the type of the page associated with the breadcrumb item.
    /// </summary>
    public Type PageType
    {
        get => (Type)GetValue(PageTypeProperty);
        set => SetValue(PageTypeProperty, value);
    }

    /// <summary>
    /// Identifies the <see cref="PageType"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty PageTypeProperty = DependencyProperty.Register(
        nameof(PageType),
        typeof(Type),
        typeof(BreadcrumbItem),
        new PropertyMetadata(default(Type), OnPageTypeChanged)
    );

    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbItem"/> class.
    /// </summary>
    public BreadcrumbItem()
    {
        InitializeComponent();
        DataContext ??= ViewModel;
    }

    /// <summary>
    /// Called when the <see cref="PageType"/> property changes.
    /// </summary>
    /// <param name="d">The dependency object.</param>
    /// <param name="e">The event arguments.</param>
    private static void OnPageTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is BreadcrumbItem breadcrumbItem && e.NewValue is Type value)
        {
            breadcrumbItem.ViewModel.PageType = value;
        }
    }
}
