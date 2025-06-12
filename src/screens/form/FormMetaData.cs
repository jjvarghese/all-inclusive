using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace All_Inclusive.screens.form
{
    public class FormMetadata
    {
        private string _errorText;
        private bool _isErrorVisible;

        public string Title { get; set; }
        public string Placeholder { get; set; }
        public string Description { get; set; }
        public Keyboard Keyboard { get; set; }

        public string ErrorText
        {
            get => _errorText;
            set
            {
                _errorText = value;
                // OnPropertyChanged();
            }
        }

        public bool IsErrorVisible
        {
            get => _isErrorVisible;
            set
            {
                _isErrorVisible = value;
                // OnPropertyChanged();
            }
        }

        // public event PropertyChangedEventHandler PropertyChanged;
        //
        // protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        // {
        //     PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        // }
    }
}