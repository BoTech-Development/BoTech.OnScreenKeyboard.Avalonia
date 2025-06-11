using Avalonia.Controls;

namespace BoTech.OnScreenKeyboard.Avalonia.Controls;
/// <summary>
/// This class is a wrapper that can draw the OnScreenKeyboard. This Class is necessary to make the Package easy to use and provide Popup Animations.
/// </summary>
public class OnScreenKeyboardPresenter : ContentControl
{
    

    public OnScreenKeyboardPresenter()
    {
        
       // OnScreenKeyboardManager.RegisterKeyboard();
    }

    public void ShowKeyboard(OnScreenKeyboard keyboardToShow)
    {
        Content = keyboardToShow;
    }
    public void HideKeyboard() => Content = null;
}