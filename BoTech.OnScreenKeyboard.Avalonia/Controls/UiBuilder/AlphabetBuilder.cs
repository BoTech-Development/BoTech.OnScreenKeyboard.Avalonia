using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Layout;

namespace BoTech.OnScreenKeyboard.Avalonia.Controls.UiBuilder;

public class AlphabetBuilder
{
    private OnScreenKeyboardManager _manager;
    public AlphabetBuilder(OnScreenKeyboardManager manager)
    {
        _manager = manager;
    }
    public StackPanel CreateAlphabetUi()
    {
        char[] firstRowLetters = ['Q','W','E','R','T','Y', 'U', 'I', 'O', 'P'];
        char[] secondRowLetters = ['A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L'];
        char[] thirdRowLetters = ['Z', 'X', 'C', 'V', 'B', 'N', 'M'];
        List<StackPanel> keyboard = new List<StackPanel>();
        keyboard.Add(CreateLetterRowFor(firstRowLetters));
        keyboard.Add(CreateLetterRowFor(secondRowLetters));
        keyboard.Add(CreateLetterRowFor(thirdRowLetters));
        keyboard.Add(CreateBottomControlKeysRow());
        StackPanel main = new StackPanel();
        main.Children.AddRange(keyboard);
        return main;
    }

    private StackPanel CreateBottomControlKeysRow()
    {
        ToggleButton ctrl = new ToggleButton()
        {
            Content = "Ctrl"
        };
        ctrl.Click += (sender, args) =>
        {
            ctrl.IsChecked = !ctrl.IsChecked;
        };
        Button left = new Button()
        {
            Content = "<"
        };
        Button right = new Button()
        {
            Content = ">"
        };
        Button top = new Button()
        {
            Content = "˄",
            Height = 16,
            Padding = new Thickness(12, 0, 12, 0),
        };
        Button bottom = new Button()
        {
            Content = "˅",
            Height = 16,
            Padding = new Thickness(12, 0, 12, 0),
        };
        Button space = new Button()
        {
            Content = "",
            Width = 128
        };
        space.Click += (sender, args) => OnTextInputClick(sender, args, ' ');
        StackPanel row = new StackPanel()
        {
            Orientation = Orientation.Horizontal,
            Children =
            {
                ctrl,
                left,
                space,
                right,
                new StackPanel()
                {
                    Orientation = Orientation.Vertical,
                    Children =
                    {
                        top,
                        bottom
                    }
                }
            }
        };
        return row;
    }
    /// <summary>
    /// Creates a row of Buttons which contains the given letters.
    /// </summary>
    /// <param name="letters"></param>
    /// <returns>A new StackPanel with all Buttons</returns>
    private StackPanel CreateLetterRowFor(char[] letters)
    {
        StackPanel stackPanel = new StackPanel()
        {
            Orientation = Orientation.Horizontal,
        };
        for (int i = 0; i < letters.Length; i++)
        {
            char currentLetter = letters[i];
            Button btn = new Button()
            {
                Name = "OnScreenKeyboard-" + currentLetter.ToString(),
                Content = currentLetter.ToString(),
            };
           
            btn.Click += (sender, args) => OnTextInputClick(sender, args, currentLetter);
            stackPanel.Children.Add(btn);
        }
        return stackPanel;
    }

    private void OnTextInputClick(object sender, RoutedEventArgs e, char letter)
    {
        _manager.NextInput(letter);
    }
}