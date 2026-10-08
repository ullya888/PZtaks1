using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using TradingCompany.DAL.Models;
using TradingCompany.DAL.Repositories;

namespace TradingCompany.Tests
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private TradingCompanyContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<TradingCompanyContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;
            return new TradingCompanyContext(options);
        }

        [Test]
        public void Create_ShouldAddProduct()
        {
            var context = GetInMemoryContext();
            var repository = new ProductRepository(context);
            var product = new Product { Name = "тесттовар", Price = 500.00m };

            repository.Create(product);

            Assert.That(context.Products.Count(), Is.EqualTo(1));
            Assert.That(context.Products.First().Name, Is.EqualTo("тесттовар"));
        }

        [Test]
        public void GetById_ShouldReturnProduct()
        {
            var context = GetInMemoryContext();
            var repository = new ProductRepository(context);
            var product = new Product { Name = "товар1", Price = 100m };
            context.Products.Add(product);
            context.SaveChanges();

            var result = repository.GetById(product.ProductId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo("товар1"));
        }

        [Test]
        public void Update_ShouldModifyProduct()
        {
            var context = GetInMemoryContext();
            var repository = new ProductRepository(context);
            var product = new Product { Name = "старназва", Price = 100m };
            context.Products.Add(product);
            context.SaveChanges();

            product.Name = "новназва";
            repository.Update(product);

            var updated = context.Products.Find(product.ProductId);
            Assert.That(updated!.Name, Is.EqualTo("новназва"));
        }

        [Test]
        public void Delete_ShouldRemoveProduct()
        {
            var context = GetInMemoryContext();
            var repository = new ProductRepository(context);
            var product = new Product { Name = "видалмене", Price = 100m };
            context.Products.Add(product);
            context.SaveChanges();

            repository.Delete(product.ProductId);

            Assert.That(context.Products.Count(), Is.EqualTo(0));
        }
    }
}