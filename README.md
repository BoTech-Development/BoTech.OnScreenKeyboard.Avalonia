# OnScreenKeyboard for Avalonia

## Why using the Keyboard
+ In the most use cases the operating system already provides an inbuild OnScreenKeyboard, but on IOT devices, an on-screen keyboard is not always available.
+ You may want to provide your own Keyboard by customizing this repository or by Styling the Keyboard so that it matches your color theme.
  + For Example when you develop an mobile Code editor, you may want provide some special characters like Function Keys or tabulator, to make things easier.
## Installation

### 1. Download or build the nuget package
#### Note: because the Keyboard is still in development there is no nuget Package available. 
+ Solution: Just build the BoTech.OnScreenKeyboard.Avalonia Project and import the .dll File in your project.
### 2. Add the following Code lines (*changes reserved*)

#### 2.1. MainWindow.axaml.cs

````c#
public partial class MainWindow : Window
{
    public MainWindow()
    {
        OnScreenKeyboardManager.Window = this;
        InitializeComponent();
    }
}
````
#### Explanation
+ This line causes the code to wait in the background for the user to press an input field so that the on-screen keyboard is displayed. 

#### 2.2. MainView.axaml
````xaml
<UserControl>
    <StackPanel>
        <!--Put your View Stuff here-->
        <controls:OnScreenKeyboardPresenter x:Name="OnScreenKeyboard1" />
    </StackPanel>
</UserControl>

````

#### Explanation
+ Here you define where the keyboard should be displayed in the window.

#### 2.2. MainView.axaml.cs
````c#
public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        OnScreenKeyboardManager.RegisterKeyboard(this.FindControl<OnScreenKeyboardPresenter>("OnScreenKeyboard1"));
    }
}

````

#### Explanation
+ By defining this line of code you register the control so that the OnScreenKeyboardManager can display it and interact with it when the user presses in an input field.