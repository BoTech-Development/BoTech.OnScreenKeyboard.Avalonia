using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;
using BoTech.OnScreenKeyboard.Avalonia.Controls.UiBuilder;

namespace BoTech.OnScreenKeyboard.Avalonia.Controls;

public class OnScreenKeyboard : ContentControl
{
    private OnScreenKeyboardManager _manager;
    public bool IsHided { get; set; } = true;
    /// <summary>
    /// Creates a new Visual Instance of the OnScreen keyboard.
    /// </summary>
    /// <param name="manager">The Manager is needed to transfer a button Click.</param>
    public OnScreenKeyboard(OnScreenKeyboardManager manager)
    {
        _manager = manager;
        Content = CreateOnScreenKeyboard();
        
    }
    /// <summary>
    /// Creates the UI for the OnScreenKeyboard
    /// </summary>
    /// <returns>
    /// Returns the ui border.
    /// </returns>
    private Border CreateOnScreenKeyboard()
    {
        StackPanel main = new StackPanel();
        main.Children.Add(new AlphabetBuilder(_manager).CreateAlphabetUi());
        main.Children.Add(CreateBottomRow());
        return new Border()
        {
            Child = main
        };

    }
    private StackPanel CreateBottomRow()
    {
        StackPanel row = new StackPanel();
        
        return row;
    }
}