using Microsoft.Extensions.DependencyInjection;
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
    /// Gets the current application instance.
    /// </summary>
    internal static new App Current => (App)Application.Current;

    /// <summary>
    /// Gets the service provider for dependency injection.
    /// </summary>
    internal ServiceProvider Services { get; } = ConfigureServices();

    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
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
        base.OnLaunched(args);

        UI.Navigation.DependencyConfiguration.Services = Services;
        UI.Settings.DependencyConfiguration.Services = Services;

        _contentFrame = new Frame();
        _contentFrame.Navigate(typeof(MainPage));

        _mainWindow = new MainWindow { Content = _contentFrame };
        _mainWindow.Activate();
    }

    /// <summary>
    /// Configures the services for dependency injection.
    /// </summary>
    /// <returns>A service provider with the configured services.</returns>
    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        UI.Navigation.DependencyConfiguration.Configure(services);
        UI.Settings.DependencyConfiguration.Configure(services);

        services.AddSingleton<MainViewModel>();

        return services.BuildServiceProvider();
    }
}
