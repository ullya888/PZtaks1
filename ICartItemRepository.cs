using System.Collections.Generic;
using TradingCompany.DAL.Models;

namespace TradingCompany.DAL.Interfaces
{
    public interface ICartItemRepository
    {
        void Create(CartItem item);
        CartItem GetById(int id);
        IEnumerable<CartItem> GetAll();
        void Update(CartItem item);
        void Delete(int id);
    }
}