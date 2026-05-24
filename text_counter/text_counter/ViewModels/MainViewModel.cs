using System.ComponentModel;
using System.Security.Cryptography;

namespace text_counter.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string? propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    // EventHandler? PropertyChange

    private string _inputtext= "";

    public string InputText
    {
        get => _inputtext;
        set
        {
            _inputtext = value;
            OnPropertyChanged(nameof(InputText));// UIに通知

            CharCount = _inputtext.Length;

        }
    }
    
    private int _charcount = 0;
    public int CharCount
    {
        get => _charcount;
        set {
            _charcount = value;
            OnPropertyChanged(nameof(CharCount));
        }
    }
    
}