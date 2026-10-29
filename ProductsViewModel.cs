using System.Collections.ObjectModel;
using TradingCompany.BL;
using TradingCompany.DTO;

namespace TradingCompany.WPF.ViewModels
{
    public class ProductsViewModel
    {
        private readonly IProductService _productService;
        private readonly IUserSession _session;

        public ObservableCollection<ProductDto> Products { get; } = new ObservableCollection<ProductDto>();
        public RelayCommand AddCommand { get; }

        
        public bool CanEdit => _session.IsAdmin;

        public ProductsViewModel(IProductService productService, IUserSession session)
        {
            _productService = productService;
            _session = session;

           
            AddCommand = new RelayCommand(AddProduct, () => _session.IsAdmin);
        }

        public void Load()
        {
            Products.Clear();
            foreach (var p in _productService.GetAll()) Products.Add(p);
        }

        private void AddProduct()
        {
            
        }
    }
}