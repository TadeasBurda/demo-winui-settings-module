using System.Windows.Input;
using Demo.UI.Settings.ViewModels.UserControls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Demo.UI.Settings.Views.UserControls;

/// <summary>
/// Represents a settings card user control.
/// </summary>
public sealed partial class SettingsCard : UserControl
{
    /// <summary>
    /// Gets the ViewModel for the settings card.
    /// </summary>
    internal SettingsCardViewModel ViewModel { get; } =
        DependencyConfiguration.GetService<SettingsCardViewModel>();

    #region Glyph

    /// <summary>
    /// Gets or sets the glyph of the settings card.
    /// </summary>
    public string Glyph
    {
        get => (string)GetValue(GlyphProperty);
        set => SetValue(GlyphProperty, value);
    }

    /// <summary>
    /// Identifies the <see cref="Glyph"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty GlyphProperty = DependencyProperty.Register(
        nameof(Glyph),
        typeof(string),
        typeof(SettingsCard),
        new PropertyMetadata(default(string))
    );

    #endregion

    #region Title

    /// <summary>
    /// Gets or sets the title of the settings card.
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
        typeof(SettingsCard),
        new PropertyMetadata(default(string))
    );

    #endregion

    #region Description

    /// <summary>
    /// Gets or sets the description of the settings card.
    /// </summary>
    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    /// <summary>
    /// Identifies the <see cref="Description"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
        nameof(Description),
        typeof(string),
        typeof(SettingsCard),
        new PropertyMetadata(default(string))
    );

    #endregion

    #region Command

    /// <summary>
    /// Gets or sets the command to be executed when the settings card is clicked.
    /// </summary>
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    /// <summary>
    /// Identifies the <see cref="Command"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
        nameof(Command),
        typeof(ICommand),
        typeof(SettingsCard),
        new PropertyMetadata(default(ICommand))
    );

    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="SettingsCard"/> class.
    /// </summary>
    public SettingsCard()
    {
        InitializeComponent();
        DataContext ??= ViewModel;
    }
}
