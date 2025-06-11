using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Input.TextInput;
using Avalonia.Markup.Xaml.MarkupExtensions;
using BoTech.OnScreenKeyboard.Avalonia.Controls;

namespace BoTech.OnScreenKeyboard.Avalonia;

public class OnScreenKeyboardManager
{
    //************************************************Static-Context************************************************
    public static Window? Window { get; set; }
    
    //private static List<OnScreenKeyboardManager> _onScreenKeyboards = new List<OnScreenKeyboardManager>();
    private static OnScreenKeyboardManager _onScreenKeyboardManager;
    public static void RegisterKeyboard(OnScreenKeyboardPresenter presenter)
    {
        if(Window == null) throw new InvalidOperationException("Window is null. This error could happen when you not place the code line 'OnScreenKeyboardManager.Window = this;' at the top of the MainWindow Constructor.");
        //_onScreenKeyboards.Add(new OnScreenKeyboardManager(Window, presenter));
        _onScreenKeyboardManager = new OnScreenKeyboardManager(presenter);
    }
    //************************************************End of Static-Context************************************************
    
    private Controls.OnScreenKeyboard _onScreenKeyboardControl;
    private OnScreenKeyboardPresenter _presenter;
    private Control? _inputControl = null;
    //************************************************Constructors************************************************
    private OnScreenKeyboardManager(OnScreenKeyboardPresenter presenter)
    {
        _presenter = presenter;
        _onScreenKeyboardControl = new Controls.OnScreenKeyboard(this);
        // Window will be not null because this will be checked in the RegisterKeyboard Method
        Window!.TextInputMethodClientRequested += OnTextInputStart;
        Window!.PointerPressed += WindowOnPointerPressed;
    }

    private void WindowOnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if(sender is Control control)
            if (control.GetType().Name != "TextBox" && control.GetType().Name != "AutoCompleteBox" &&
                control.GetType().Name != "NumericUpDown")
            {
                HideKeyboard();
            }
    }

    //************************************************End of Constructors************************************************
    //************************************************Public Methods************************************************
    /// <summary>
    /// Adds a new Letter to the Selected TextBox
    /// </summary>
    /// <param name="letter"></param>
    public void NextInput(char letter)
    {
        // Yes, I know abstraction has another look but this is an issue at Avalonia.
        // Sorry robert c martin
        if(_inputControl != null)
            switch (_inputControl.GetType().Name)
            {
                case "TextBox":
                    if(_inputControl is TextBox) ((TextBox)_inputControl).Text += letter.ToString();
                    break;
                case "AutoCompleteBox":
                    if(_inputControl is AutoCompleteBox) ((AutoCompleteBox)_inputControl).Text += letter.ToString();
                    break;
                case "NumericUpDown":
                    if(_inputControl is NumericUpDown) ((NumericUpDown)_inputControl).Text += letter.ToString();
                    break;
            }
    }
    
    //************************************************End of Public Methods************************************************
    //************************************************Private Methods************************************************
    
    /// <summary>
    /// Will be called when the user clicks on an Control which accepts text or number input.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnTextInputStart(object? sender, TextInputMethodClientRequestedEventArgs e)
    {
        if (Window != null && Window.FocusManager != null)
        {
            IInputElement? inputElement = Window.FocusManager.GetFocusedElement() as IInputElement;
            // Show only the Keyboard when the InputElement has changed.
            // When the User clicks a button from the OnScreenKeyboard, the inputElement will immediately change to the button which the user had clicked.
            // This will cause that the Keyboard will be rendered again, although the user wants to enter text in the old input Control. => Therefore it is necessary to check if the new inputElement is part of the Keyboard.
            if (inputElement != null && inputElement != (IInputElement)_inputControl!)
            {
                if (inputElement is Control inputControl)
                {
                    if (inputControl.Name == null || !inputControl.Name.Contains("OnScreenKeyboard"))
                    {
                        _inputControl = inputControl;
                        ShowKeyboard();
                    }
                }
            }
            else if(_onScreenKeyboardControl.IsHided)
            {
                ShowKeyboard();
            }
        }
    }

    private void ShowKeyboard()
    {
        _onScreenKeyboardControl.IsHided = false;
        _presenter.ShowKeyboard(_onScreenKeyboardControl);
    }

    private void HideKeyboard()
    {
        _onScreenKeyboardControl.IsHided = true;
        _presenter.HideKeyboard();
    }
    //************************************************End of Private Methods************************************************
}