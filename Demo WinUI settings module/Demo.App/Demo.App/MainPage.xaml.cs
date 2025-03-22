using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Demo.App;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainPage : Page
{
    /// <summary>
    /// Gets the ViewModel for the MainPage.
    /// </summary>
    internal MainViewModel ViewModel { get; } =
        App.Current.Services.GetRequiredService<MainViewModel>();

    /// <summary>
    /// Initializes a new instance of the <see cref="MainPage"/> class.
    /// </summary>
    public MainPage()
    {
        InitializeComponent();
        DataContext ??= ViewModel;
        Loaded += OnPageLoaded;
    }

    /// <summary>
    /// Handles the Loaded event of the page.
    /// </summary>
    /// <param name="_">The sender of the event.</param>
    /// <param name="__">The event arguments.</param>
    private void OnPageLoaded(object _, RoutedEventArgs __)
    {
        ViewModel.IsActive = true;
        ViewModel.ContentFrame = _contentFrame;
    }
}
