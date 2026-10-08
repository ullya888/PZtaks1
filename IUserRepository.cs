using System.Collections.Generic;
using TradingCompany.DAL.Models;

namespace TradingCompany.DAL.Interfaces
{
    public interface IUserRepository
    {
        void Create(User item);
        User GetById(int id);
        IEnumerable<User> GetAll();
        void Update(User item);
        void Delete(int id);
    }
}