using Microsoft.UI.Xaml;
using Windows.Storage;

namespace Demo.App;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    private const string WINDOW_POSITION_KEY = "WindowPosition";

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        SetWindowPosition();
        Closed += (_, __) => SaveWindowPosition();
    }

    /// <summary>
    /// Saves the current window position to local settings.
    /// </summary>
    private void SaveWindowPosition()
    {
        var localSettings = ApplicationData.Current.LocalSettings;
        var position = new { Left = AppWindow.Position.X, Top = AppWindow.Position.Y };
        localSettings.Values[WINDOW_POSITION_KEY] = $"{position.Left},{position.Top}";
    }

    /// <summary>
    /// Sets the window position from local settings if available.
    /// </summary>
    private void SetWindowPosition()
    {
        var localSettings = ApplicationData.Current.LocalSettings;
        if (localSettings.Values.TryGetValue(WINDOW_POSITION_KEY, out object? value))
        {
            var position = value?.ToString()?.Split(',');
            if (
                position?.Length == 2
                && int.TryParse(position[0], out int left)
                && int.TryParse(position[1], out int top)
            )
            {
                AppWindow.Move(new Windows.Graphics.PointInt32(left, top));
            }
        }
    }
}
