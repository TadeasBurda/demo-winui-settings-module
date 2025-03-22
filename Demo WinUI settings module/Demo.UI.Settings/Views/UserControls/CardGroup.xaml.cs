using Demo.UI.Settings.ViewModels.UserControls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Demo.UI.Settings.Views.UserControls;

/// <summary>
/// Represents a card group user control.
/// </summary>
public sealed partial class CardGroup : UserControl
{
    /// <summary>
    /// Gets the ViewModel for the card group.
    /// </summary>
    internal CardGroupViewModel ViewModel { get; } =
        DependencyConfiguration.GetService<CardGroupViewModel>();

    #region Children

    /// <summary>
    /// Gets the collection of child elements.
    /// </summary>
    public UIElementCollection Children => _childrenPanel.Children;

    /// <summary>
    /// Identifies the <see cref="Children"/> dependency property.
    /// </summary>
    public static readonly DependencyProperty ChildrenProperty = DependencyProperty.Register(
        nameof(Children),
        typeof(UIElementCollection),
        typeof(CardGroup),
        new PropertyMetadata(default(UIElementCollection))
    );

    #endregion

    #region Title

    /// <summary>
    /// Gets or sets the title of the card group.
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
        typeof(CardGroup),
        new PropertyMetadata(default(string))
    );

    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="CardGroup"/> class.
    /// </summary>
    public CardGroup()
    {
        InitializeComponent();
        DataContext ??= ViewModel;
    }
}
