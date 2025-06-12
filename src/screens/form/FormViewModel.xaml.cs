using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using All_Inclusive.screens.form;

namespace All_Inclusive.screens.form
{
    public class FormViewModel : INotifyPropertyChanged
    {
        private string _fullName;
        private string _email;
        private string _fullNameError;
        private string _emailError;
        public ObservableCollection<FormMetadata> FieldLayout { get; } = new ObservableCollection<FormMetadata>
        {
            new FormMetadata
            {
                Title = "Full name",
                Placeholder = "Enter your full name",
                Description = "Full name",
                Keyboard = Keyboard.Default
            },
            new FormMetadata
            {
                Title = "Email",
                Placeholder = "you@example.com",
                Description = "Email address",
                Keyboard = Keyboard.Email
            }
        };
        
        public string FullName 
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged();
                ClearFullNameError();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
                ClearEmailError();
            }
        }

        public string FullNameError
        {
            get => _fullNameError;
            private set
            {
                _fullNameError = value;
                OnPropertyChanged();
                UpdateFieldLayoutErrors();
            }
        }

        public string EmailError
        {
            get => _emailError;
            private set
            {
                _emailError = value;
                OnPropertyChanged();
                UpdateFieldLayoutErrors();
            }
        }

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
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains('@'))
            {
                EmailError = "Enter a valid email address.";
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
            }
        }

        private void ClearEmailError()
        {
            if (!string.IsNullOrEmpty(EmailError))
            {
                EmailError = string.Empty;
            }
        }

        private void UpdateFieldLayoutErrors()
        {
            foreach (var field in FieldLayout)
            {
                if (field.Title == "Full name")
                {
                    field.ErrorText = FullNameError;
                    field.IsErrorVisible = HasFullNameError;
                }
                else if (field.Title == "Email")
                {
                    field.ErrorText = EmailError;
                    field.IsErrorVisible = HasEmailError;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
