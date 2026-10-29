
using TradingCompany.DAL.Interfaces;
using TradingCompany.DAL.Models;
using TradingCompany.DTO;

namespace TradingCompany.DAL.Repositories
{
    public class ProductRepository : BaseDtoRepository<Product, ProductDto>, IProductRepository
    {
        public ProductRepository(TradingCompanyContext context) : base(context) { }

        protected override Product MapToEntity(ProductDto dto) => new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            CategoryId = dto.CategoryId
        };

        protected override ProductDto MapToDto(Product entity) => new ProductDto
        {
            ProductId = entity.ProductId,
            Name = entity.Name,
            Price = entity.Price,
            CategoryId = entity.CategoryId
        };

        protected override Product? FindEntity(int id) => _context.Products.Find(id);

        protected override void UpdateEntityProperties(Product entity, ProductDto dto)
        {
            entity.Name = dto.Name;
            entity.Price = dto.Price;
            entity.CategoryId = dto.CategoryId;
        }
    }
}