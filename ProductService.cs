using System.Collections.Generic;
using TradingCompany.DAL.Interfaces;
using TradingCompany.DTO;

namespace TradingCompany.BL
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAll();
        void Create(ProductDto product);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public IEnumerable<ProductDto> GetAll() => _productRepo.GetAll();

        public void Create(ProductDto product)
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(product.Name))
                errors.Add("Product must have a name");
            if (product.Price <= 0)
                errors.Add("Price must bw not 0");

            if (errors.Count > 0)
                throw new BusinessRuleException(errors);

            _productRepo.Create(product);
        }
    }
}