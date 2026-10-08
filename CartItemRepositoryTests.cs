using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using TradingCompany.DAL.Models;
using TradingCompany.DAL.Repositories;

namespace TradingCompany.Tests
{
    [TestFixture]
    public class CartItemRepositoryTests
    {
        private TradingCompanyContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<TradingCompanyContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;
            return new TradingCompanyContext(options);
        }

        [Test]
        public void Create_ShouldAddCartItem()
        {
            var context = GetInMemoryContext();
            var repository = new CartItemRepository(context);
            var cartItem = new CartItem { Quantity = 2 };

            repository.Create(cartItem);

            Assert.That(context.CartItems.Count(), Is.EqualTo(1));
            Assert.That(context.CartItems.First().Quantity, Is.EqualTo(2));
        }

        [Test]
        public void GetById_ShouldReturnCartItem()
        {
            var context = GetInMemoryContext();
            var repository = new CartItemRepository(context);
            var cartItem = new CartItem { Quantity = 3 };
            context.CartItems.Add(cartItem);
            context.SaveChanges();

            var result = repository.GetById(cartItem.CartItemId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Quantity, Is.EqualTo(3));
        }

        [Test]
        public void Update_ShouldModifyCartItem()
        {
            var context = GetInMemoryContext();
            var repository = new CartItemRepository(context);
            var cartItem = new CartItem { Quantity = 1 };
            context.CartItems.Add(cartItem);
            context.SaveChanges();

            cartItem.Quantity = 5;
            repository.Update(cartItem);

            var updated = context.CartItems.Find(cartItem.CartItemId);
            Assert.That(updated!.Quantity, Is.EqualTo(5));
        }

        [Test]
        public void Delete_ShouldRemoveCartItem()
        {
            var context = GetInMemoryContext();
            var repository = new CartItemRepository(context);
            var cartItem = new CartItem { Quantity = 1 };
            context.CartItems.Add(cartItem);
            context.SaveChanges();

            repository.Delete(cartItem.CartItemId);

            Assert.That(context.CartItems.Count(), Is.EqualTo(0));
        }
    }
}