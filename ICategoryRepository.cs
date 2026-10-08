using System.Collections.Generic;
using TradingCompany.DAL.Models;

namespace TradingCompany.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        void Create(Category item);
        Category GetById(int id);
        IEnumerable<Category> GetAll();
        void Update(Category item);
        void Delete(int id);
    }
}