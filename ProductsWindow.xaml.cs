using System.Windows;
using TradingCompany.WPF.ViewModels;

namespace TradingCompany.WPF
{
    public partial class ProductsWindow : Window
    {
        public ProductsWindow(ProductsViewModel viewModel)
        {
            InitializeComponent();

            
            DataContext = viewModel;

            
            viewModel.Load();
        }
    }
}