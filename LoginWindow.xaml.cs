using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using TradingCompany.WPF.ViewModels;
using TradingCompany.BL; 

namespace TradingCompany.WPF
{
    public partial class LoginWindow : Window
    {
        public LoginWindow(LoginViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (LoginViewModel)DataContext;

            if (!viewModel.SignIn(pwdPassword.Password))
            {
                pwdPassword.Clear();
                pwdPassword.Focus();
                return;
            }

            var session = App.Services.GetRequiredService<IUserSession>();

            Window nextWindow;

            if (session.IsAdmin)
            {
                
                nextWindow = App.Services.GetRequiredService<ProductsWindow>();
            }
            else
            {
                
                nextWindow = new Window
                {
                    Title = "Головне вікно користувача",
                    Width = 500,
                    Height = 350
                };
            }

            Application.Current.MainWindow = nextWindow;
            nextWindow.Show();

            this.Close();
        }
    }
}