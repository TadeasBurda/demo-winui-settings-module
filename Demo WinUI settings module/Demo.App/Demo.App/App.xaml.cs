using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Demo.App;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    private Window? _mainWindow;
    private Frame? _contentFrame;

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        _contentFrame = new Frame();
        _contentFrame.Navigate(typeof(MainPage));

        _mainWindow = new MainWindow { Content = _contentFrame };
        _mainWindow.Activate();
    }
}
