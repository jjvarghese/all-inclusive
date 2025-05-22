using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace All_Inclusive.ViewModels;

public class FormViewModel : INotifyPropertyChanged
{
    private string _fullName;
    private string _email;

    public string FullName
    {
        get => _fullName;
        set { _fullName = value; OnPropertyChanged(); ClearFullNameError(); }
    }

    public string Email
    {
        get => _email;
        set { _email = value; OnPropertyChanged(); ClearEmailError(); }
    }

    public string FullNameError { get; private set; }
    public string EmailError { get; private set; }

    public bool HasFullNameError => !string.IsNullOrEmpty(FullNameError);
    public bool HasEmailError => !string.IsNullOrEmpty(EmailError);

    public ICommand SubmitCommand { get; }

    public FormViewModel()
    {
        SubmitCommand = new Command(OnSubmit);
    }

    private void OnSubmit()
    {
        bool isValid = true;

        if (string.IsNullOrWhiteSpace(FullName))
        {
            FullNameError = "Full name is required.";
            OnPropertyChanged(nameof(FullNameError));
            OnPropertyChanged(nameof(HasFullNameError));
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(Email) || !Email.Contains('@'))
        {
            EmailError = "Enter a valid email address.";
            OnPropertyChanged(nameof(EmailError));
            OnPropertyChanged(nameof(HasEmailError));
            isValid = false;
        }

        if (isValid)
        {
            // Proceed with next logic
        }
    }

    private void ClearFullNameError()
    {
        if (!string.IsNullOrEmpty(FullNameError))
        {
            FullNameError = string.Empty;
            OnPropertyChanged(nameof(FullNameError));
            OnPropertyChanged(nameof(HasFullNameError));
        }
    }

    private void ClearEmailError()
    {
        if (!string.IsNullOrEmpty(EmailError))
        {
            EmailError = string.Empty;
            OnPropertyChanged(nameof(EmailError));
            OnPropertyChanged(nameof(HasEmailError));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}