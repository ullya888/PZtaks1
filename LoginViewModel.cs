using TradingCompany.BL;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TradingCompany.WPF.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly IUserSession _session;
        private string _login;
        private string _errorMessage;

        public string Login
        {
            get => _login;
            set { _login = value; OnPropertyChanged(); }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            private set { _errorMessage = value; OnPropertyChanged(); }
        }

        public LoginViewModel(IUserSession session)
        {
            _session = session;
        }

        public bool SignIn(string password)
        {
            if (string.IsNullOrWhiteSpace(Login))
            {
                ErrorMessage = "Введіть логін.";
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                ErrorMessage = "Введіть пароль.";
                return false;
            }

            
            if (Login == "admin" && password == "123")
            {
                _session.SignIn(Login, isAdmin: true);
                ErrorMessage = null;
                return true;
            }

           
            if (!string.IsNullOrWhiteSpace(password))
            {
                _session.SignIn(Login, isAdmin: false);
                ErrorMessage = null;
                return true;
            }

            ErrorMessage = "Невірний логін або пароль.";
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}