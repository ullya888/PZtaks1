using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using TradingCompany.DAL.Models;
using TradingCompany.DAL.Repositories;

namespace TradingCompany.Tests
{
    [TestFixture]
    public class CategoryRepositoryTests
    {
        private TradingCompanyContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<TradingCompanyContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;

            return new TradingCompanyContext(options);
        }

        [Test]
        public void Create_ShouldAddCategoryToDatabase()
        {
            var context = GetInMemoryContext();
            var repository = new CategoryRepository(context);
            var category = new Category { Name = "тесткатегорія" };

            repository.Create(category);

            Assert.That(context.Categories.Count(), Is.EqualTo(1));
            Assert.That(context.Categories.First().Name, Is.EqualTo("тесткатегорія"));
        }

        [Test]
        public void GetById_ShouldReturnCorrectCategory()
        {
            var context = GetInMemoryContext();
            var repository = new CategoryRepository(context);
            var category = new Category { Name = "помади" };
            context.Categories.Add(category);
            context.SaveChanges();

            var result = repository.GetById(category.CategoryId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo("помади"));
        }

        [Test]
        public void Update_ShouldModifyExistingCategory()
        {
            var context = GetInMemoryContext();
            var repository = new CategoryRepository(context);
            var category = new Category { Name = "старназва" };
            context.Categories.Add(category);
            context.SaveChanges();

            category.Name = "новназва";
            repository.Update(category);

            var updatedCategory = context.Categories.Find(category.CategoryId);
            Assert.That(updatedCategory!.Name, Is.EqualTo("новназва"));
        }

        [Test]
        public void Delete_ShouldRemoveCategoryFromDatabase()
        {
            var context = GetInMemoryContext();
            var repository = new CategoryRepository(context);
            var category = new Category { Name = "видалмене" };
            context.Categories.Add(category);
            context.SaveChanges();

            repository.Delete(category.CategoryId);

            Assert.That(context.Categories.Count(), Is.EqualTo(0));
        }
    }
}