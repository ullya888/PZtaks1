using System;
using TradingCompany.DAL.Models;
using TradingCompany.DAL.Repositories;

namespace TradingCompany.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using var context = new TradingCompanyContext();
            var categoryRepo = new CategoryRepository(context);
            var productRepo = new ProductRepository(context);

            while (true)
            {

                Console.WriteLine("1. Show all categories");
                Console.WriteLine("2. Add a new category");
                Console.WriteLine("3. Show all products");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n ..Category list..");
                        var categories = categoryRepo.GetAll();
                        foreach (var c in categories)
                        {
                            Console.WriteLine($"[{c.CategoryId}] {c.Name}");
                        }
                        break;

                    case "2":
                        Console.Write("Write the category name: ");
                        var name = Console.ReadLine();
                        categoryRepo.Create(new Category { Name = name });
                        Console.WriteLine("Category added successfully");
                        break;

                    case "3":
                        Console.WriteLine("\n..Products list..");
                        var products = productRepo.GetAll();
                        foreach (var p in products)
                        {
                            Console.WriteLine($"[{p.ProductId}] {p.Name} - {p.Price} uah");
                        }
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}