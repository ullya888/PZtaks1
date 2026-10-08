using System.Collections.Generic;
using System.Linq;
using TradingCompany.DAL.Interfaces;
using TradingCompany.DAL.Models;

namespace TradingCompany.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TradingCompanyContext _context;

        public CategoryRepository(TradingCompanyContext context)
        {
            _context = context;
        }

        public void Create(Category item)
        {
            _context.Categories.Add(item);
            _context.SaveChanges();
        }

        public Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void Update(Category item)
        {
            _context.Categories.Update(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.Categories.Find(id);
            if (item != null)
            {
                _context.Categories.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}