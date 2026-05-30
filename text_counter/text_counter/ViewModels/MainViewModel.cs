using System.ComponentModel;

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
            WordCount = value.Split(new[] {' ','\n'}).Length;
            LineCount = value.Split('\n',StringSplitOptions.RemoveEmptyEntries).Length;

        }
    }
    
    private int _charcount = 0;
    public int CharCount
    {
        get => _charcount;
        set
        {
            _charcount = value;
            OnPropertyChanged(nameof(CharCount));
        }
    }
    
    private int _wordcount=0;
    public int WordCount
    {
        get => _wordcount;
        set
        {
            _wordcount = value;
            OnPropertyChanged(nameof(WordCount));
        }
    }
    
    private int _linecount=0;
    public int LineCount
    {
        get => _linecount;
        set
        {
            _linecount = value;
            OnPropertyChanged((nameof(LineCount)));
        }
    }
}