using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using TradingCompany.DAL.Models;
using TradingCompany.DAL.Repositories;

namespace TradingCompany.Tests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private TradingCompanyContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<TradingCompanyContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;
            return new TradingCompanyContext(options);
        }

        [Test]
        public void Create_ShouldAddUser()
        {
            var context = GetInMemoryContext();
            var repository = new UserRepository(context);
            var user = new User { Login = "тесткор", PasswordHash = "123456" };

            repository.Create(user);

            Assert.That(context.Users.Count(), Is.EqualTo(1));
            Assert.That(context.Users.First().Login, Is.EqualTo("тесткор"));
        }

        [Test]
        public void GetById_ShouldReturnUser()
        {
            var context = GetInMemoryContext();
            var repository = new UserRepository(context);
            var user = new User { Login = "юзер1", PasswordHash = "123" };
            context.Users.Add(user);
            context.SaveChanges();

            var result = repository.GetById(user.UserId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Login, Is.EqualTo("юзер1"));
        }

        [Test]
        public void Update_ShouldModifyUser()
        {
            var context = GetInMemoryContext();
            var repository = new UserRepository(context);
            var user = new User { Login = "старлогін", PasswordHash = "6767" };
            context.Users.Add(user);
            context.SaveChanges();

            user.Login = "новлогін";
            repository.Update(user);

            var updated = context.Users.Find(user.UserId);
            Assert.That(updated!.Login, Is.EqualTo("новлогін"));
        }

        [Test]
        public void Delete_ShouldRemoveUser()
        {
            var context = GetInMemoryContext();
            var repository = new UserRepository(context);
            var user = new User { Login = "видалимене", PasswordHash = "9090" };
            context.Users.Add(user);
            context.SaveChanges();

            repository.Delete(user.UserId);

            Assert.That(context.Users.Count(), Is.EqualTo(0));
        }
    }
}