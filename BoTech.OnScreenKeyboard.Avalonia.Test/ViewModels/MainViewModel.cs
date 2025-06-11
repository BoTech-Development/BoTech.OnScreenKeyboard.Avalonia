
using System.Collections.Generic;

namespace BoTech.OnScreenKeyboard.Avalonia.Test.ViewModels;

public class MainViewModel : ViewModelBase
{
    public List<string> AutoCompleteBoxItems { get; set; }

    public MainViewModel()
    {
        AutoCompleteBoxItems = new List<string>()
        {
            "BoTech",
            "BoTech.DesignerForAvalonia",
            "BoTech.OnScreenKeyboard.Avalonia",
        };
    }
}
