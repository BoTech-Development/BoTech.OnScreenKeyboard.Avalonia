using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BoTech.OnScreenKeyboard.Avalonia.Controls;

namespace BoTech.OnScreenKeyboard.Avalonia.Test.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        OnScreenKeyboardManager.Window = this;
        InitializeComponent();
    }
}