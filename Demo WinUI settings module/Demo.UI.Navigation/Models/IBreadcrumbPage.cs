using System;

namespace Demo.UI.Navigation.Models;

/// <summary>
/// Represents a breadcrumb page with a title and an optional parent page.
/// </summary>
public interface IBreadcrumbPage
{
    /// <summary>
    /// Gets the title of the breadcrumb page.
    /// </summary>
    string Title { get; }

    /// <summary>
    /// Gets the type of the parent page, if any.
    /// </summary>
    Type? ParentPage { get; }
}
