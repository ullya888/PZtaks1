
using TradingCompany.DAL.Interfaces;
using TradingCompany.DAL.Models;
using TradingCompany.DTO;

namespace TradingCompany.DAL.Repositories
{
    public class CartItemRepository : BaseDtoRepository<CartItem, CartItemDto>, ICartItemRepository
    {
        public CartItemRepository(TradingCompanyContext context) : base(context) { }

        protected override CartItem MapToEntity(CartItemDto dto) => new CartItem
        {
            UserId = dto.UserId,
            ProductId = dto.ProductId,
            Quantity = dto.Quantity
        };

        protected override CartItemDto MapToDto(CartItem entity) => new CartItemDto
        {
            CartItemId = entity.CartItemId,
            UserId = entity.UserId,
            ProductId = entity.ProductId,
            Quantity = entity.Quantity
        };

        protected override CartItem? FindEntity(int id) => _context.CartItems.Find(id);

        protected override void UpdateEntityProperties(CartItem entity, CartItemDto dto)
        {
            entity.UserId = dto.UserId;
            entity.ProductId = dto.ProductId;
            entity.Quantity = dto.Quantity;
        }
    }
}