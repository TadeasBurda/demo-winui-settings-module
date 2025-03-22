using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace Demo.App;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainPage : Page
{
    internal MainViewModel ViewModel { get; } =
        App.Current.Services.GetRequiredService<MainViewModel>();

    public MainPage()
    {
        InitializeComponent();

        DataContext ??= ViewModel;
    }
}
