using System;

namespace Demo.UI.Navigation.Models;

/// <summary>
/// Represents a message to navigate to a specified page.
/// </summary>
/// <param name="Page">The type of the page to navigate to.</param>
public record NavigateToPageMessage(Type Page) { }
