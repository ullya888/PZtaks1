
using TradingCompany.DAL.Interfaces;
using TradingCompany.DAL.Models;
using TradingCompany.DTO;

namespace TradingCompany.DAL.Repositories
{
    public class CategoryRepository : BaseDtoRepository<Category, CategoryDto>, ICategoryRepository
    {
        public CategoryRepository(TradingCompanyContext context) : base(context) { }

        protected override Category MapToEntity(CategoryDto dto) => new Category
        {
            Name = dto.Name
        };

        protected override CategoryDto MapToDto(Category entity) => new CategoryDto
        {
            CategoryId = entity.CategoryId,
            Name = entity.Name
        };

        protected override Category? FindEntity(int id) => _context.Categories.Find(id);

        protected override void UpdateEntityProperties(Category entity, CategoryDto dto)
        {
            entity.Name = dto.Name;
        }
    }
}