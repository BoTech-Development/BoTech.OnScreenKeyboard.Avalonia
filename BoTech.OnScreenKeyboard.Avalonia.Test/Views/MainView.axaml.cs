using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BoTech.OnScreenKeyboard.Avalonia.Controls;

namespace BoTech.OnScreenKeyboard.Avalonia.Test.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        OnScreenKeyboardManager.RegisterKeyboard(this.FindControl<OnScreenKeyboardPresenter>("OnScreenKeyboard1"));
    }
}