using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Demo.UI.Navigation.Models;
using Demo.UI.Navigation.ViewModels.UserControls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Demo.UI.Navigation.Views.UserControls;

/// <summary>
/// Represents the breadcrumb header user control.
/// </summary>
public sealed partial class BreadcrumbHeader : UserControl
{
    /// <summary>
    /// Gets the ViewModel for the breadcrumb header.
    /// </summary>
    internal BreadcrumbHeaderViewModel ViewModel { get; } =
        DependencyConfiguration.GetService<BreadcrumbHeaderViewModel>();

    #region CurrentPageType

    /// <summary>
    /// Gets or sets the type of the current page.
    /// </summary>
    public Type CurrentPageType
    {
        get => (Type)GetValue(CurrentPageTypeProperty);
        set => SetValue(CurrentPageTypeProperty, value);
    }

    /// <summary>
    /// Identifies the <see cref="CurrentPageType"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty CurrentPageTypeProperty = DependencyProperty.Register(
        nameof(CurrentPageType),
        typeof(Type),
        typeof(BreadcrumbHeader),
        new PropertyMetadata(default(Type), OnActivePageChanged)
    );

    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="BreadcrumbHeader"/> class.
    /// </summary>
    public BreadcrumbHeader()
    {
        InitializeComponent();
        DataContext ??= ViewModel;
    }

    /// <summary>
    /// Called when the active page changes.
    /// </summary>
    /// <param name="d">The dependency object.</param>
    /// <param name="e">The event arguments.</param>
    private static void OnActivePageChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e
    )
    {
        if (d is BreadcrumbHeader breadcrumbHeader && e.NewValue is Type page)
        {
            breadcrumbHeader.RenderBreadcrumb(page);
        }
    }

    /// <summary>
    /// Renders the breadcrumb for the specified page.
    /// </summary>
    /// <param name="page">The type of the page.</param>
    private void RenderBreadcrumb(Type page)
    {
        if (Activator.CreateInstance(page) is IBreadcrumbPage currentPage)
        {
            _stackPanel.Children.Clear();

            AddCurrentPage(currentPage);

            if (currentPage.ParentPage != null)
            {
                RecursivelyAddParentPages(currentPage.ParentPage);
            }

            ReverseBreadcrumbOrder();
        }
    }

    /// <summary>
    /// Reverses the order of the breadcrumb items.
    /// </summary>
    private void ReverseBreadcrumbOrder()
    {
        var children = _stackPanel.Children.ToArray();
        children.Reverse();

        _stackPanel.Children.Clear();

        foreach (var child in children)
        {
            _stackPanel.Children.Add(child);
        }
    }

    /// <summary>
    /// Recursively adds the parent pages to the breadcrumb.
    /// </summary>
    /// <param name="parentPage">The type of the parent page.</param>
    private void RecursivelyAddParentPages(Type parentPage)
    {
        if (Activator.CreateInstance(parentPage) is IBreadcrumbPage page)
        {
            var item = new BreadcrumbItem { Title = page.Title, PageType = parentPage };
            _stackPanel.Children.Add(item);

            if (page.ParentPage != null)
            {
                RecursivelyAddParentPages(page.ParentPage);
            }
        }
    }

    /// <summary>
    /// Adds the current page to the breadcrumb.
    /// </summary>
    /// <param name="page">The current breadcrumb page.</param>
    private void AddCurrentPage(IBreadcrumbPage page)
    {
        var textBlock = new TextBlock
        {
            Text = page.Title,
            Style = (Style)Application.Current.Resources["TitleTextBlockStyle"]
        };
        _stackPanel.Children.Add(textBlock);
    }
}
