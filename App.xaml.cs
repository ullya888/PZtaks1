using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using TradingCompany.DAL.Models;
using TradingCompany.DAL.Repositories;
using TradingCompany.DAL.Interfaces;
using TradingCompany.BL;
using TradingCompany.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace TradingCompany.WPF
{
    public partial class App : Application
    {
        public static ServiceProvider Services { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            var connectionString = "Server=localhost;Database=TradingCompany;User Id=sa;Password=ranboopog;TrustServerCertificate=True;";

          
            services.AddDbContext<TradingCompanyContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IProductRepository, ProductRepository>();

           
            services.AddSingleton<IUserSession, UserSession>();
            services.AddTransient<IProductService, ProductService>();

           
            services.AddTransient<LoginViewModel>();
            services.AddTransient<ProductsViewModel>();

            
            services.AddTransient<LoginWindow>();
            services.AddTransient<ProductsWindow>();

            
           services.AddTransient<ProductsWindow>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAuthService, AuthService>();

            Services = services.BuildServiceProvider();

    
            var loginWindow = Services.GetRequiredService<LoginWindow>();

           
            MainWindow = loginWindow;
            loginWindow.Show();
        }
    }
}