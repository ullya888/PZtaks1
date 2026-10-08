using System.Collections.Generic;
using TradingCompany.DAL.Models;

namespace TradingCompany.DAL.Interfaces
{
    public interface IProductRepository
    {
        void Create(Product item);
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        void Update(Product item);
        void Delete(int id);
    }
}