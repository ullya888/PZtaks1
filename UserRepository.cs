using System.Collections.Generic;
using System.Linq;
using TradingCompany.DAL.Interfaces;
using TradingCompany.DAL.Models;

namespace TradingCompany.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TradingCompanyContext _context;

        public UserRepository(TradingCompanyContext context)
        {
            _context = context;
        }

        public void Create(User item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Update(User item)
        {
            _context.Users.Update(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.Users.Find(id);
            if (item != null)
            {
                _context.Users.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}