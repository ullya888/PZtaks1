using System.Collections.Generic;
using System.Linq;
using TradingCompany.DAL.Interfaces;
using TradingCompany.DAL.Models;

namespace TradingCompany.DAL.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly TradingCompanyContext _context;

        public CartItemRepository(TradingCompanyContext context)
        {
            _context = context;
        }

        public void Create(CartItem item)
        {
            _context.CartItems.Add(item);
            _context.SaveChanges();
        }

        public CartItem GetById(int id)
        {
            return _context.CartItems.Find(id);
        }

        public IEnumerable<CartItem> GetAll()
        {
            return _context.CartItems.ToList();
        }

        public void Update(CartItem item)
        {
            _context.CartItems.Update(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.CartItems.Find(id);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}