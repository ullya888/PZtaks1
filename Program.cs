using Microsoft.EntityFrameworkCore;
using System;
using TradingCompany.DAL.Models;
using TradingCompany.DAL.Repositories;
using TradingCompany.DTO;

namespace TradingCompany.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TradingCompanyContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=TradingCompany;User Id=sa;Password=ranboopog;TrustServerCertificate=True;");

            using var context = new TradingCompanyContext(optionsBuilder.Options);
            using var categoryRepo = new CategoryRepository(context);
            using var productRepo = new ProductRepository(context);
            using var cartItemRepo = new CartItemRepository(context);

            while (true)
            {
                Console.WriteLine("\n--- CATEGORIES ---");
                Console.WriteLine("1. Show all categories");
                Console.WriteLine("2. Get category by ID");
                Console.WriteLine("3. Add a new category");
                Console.WriteLine("4. Update category");
                Console.WriteLine("5. Delete category");

                Console.WriteLine("\n--- PRODUCTS ---");
                Console.WriteLine("6. Show all products");
                Console.WriteLine("7. Get product by ID");
                Console.WriteLine("8. Add a new product");
                Console.WriteLine("9. Update product");
                Console.WriteLine("10. Delete product");

                Console.WriteLine("\n--- CART ITEMS ---");
                Console.WriteLine("11. Show all cart items");
                Console.WriteLine("12. Get cart item by ID");
                Console.WriteLine("13. Add a new cart item");
                Console.WriteLine("14. Update cart item");
                Console.WriteLine("15. Delete cart item");

                Console.WriteLine("\n0. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n..Category list..");
                        foreach (var c in categoryRepo.GetAll())
                        {
                            Console.WriteLine($"ID: {c.CategoryId} | Name: {c.Name}");
                        }
                        break;

                    case "2":
                        Console.Write("Enter Category ID: ");
                        if (int.TryParse(Console.ReadLine(), out int catId))
                        {
                            var cat = categoryRepo.GetById(catId);
                            if (cat != null) Console.WriteLine($"Found: [{cat.CategoryId}] {cat.Name}");
                            else Console.WriteLine("Category not found.");
                        }
                        break;

                    case "3":
                        Console.Write("Write the category name: ");
                        var catName = Console.ReadLine();
                        categoryRepo.Create(new CategoryDto { Name = catName });
                        Console.WriteLine("Category added successfully!");
                        break;

                    case "4":
                        Console.Write("Enter Category ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateCatId))
                        {
                            var cat = categoryRepo.GetById(updateCatId);
                            if (cat != null)
                            {
                                Console.Write("Enter new name: ");
                                cat.Name = Console.ReadLine();
                                categoryRepo.Update(updateCatId, cat);
                                Console.WriteLine("Category updated successfully!");
                            }
                            else Console.WriteLine("Category not found.");
                        }
                        break;

                    case "5":
                        Console.Write("Enter Category ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int delCatId))
                        {
                            categoryRepo.Delete(delCatId);
                            Console.WriteLine("Category deleted (if existed).");
                        }
                        break;

                    case "6":
                        Console.WriteLine("\n..Products list..");
                        foreach (var p in productRepo.GetAll())
                        {
                            Console.WriteLine($"ID: {p.ProductId} | Name: {p.Name} | Price: {p.Price} uah | Category ID: {p.CategoryId}");
                        }
                        break;

                    case "7":
                        Console.Write("Enter Product ID: ");
                        if (int.TryParse(Console.ReadLine(), out int prodId))
                        {
                            var prod = productRepo.GetById(prodId);
                            if (prod != null)
                            {
                                Console.WriteLine($"Found: [{prod.ProductId}] {prod.Name} - {prod.Price} uah | Category ID: {prod.CategoryId}");
                            }
                            else
                            {
                                Console.WriteLine("Product not found.");
                            }
                        }
                        break;

                    case "8":
                        Console.Write("Enter product name: ");
                        var pName = Console.ReadLine();

                        Console.Write("Enter product price: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal pPrice))
                        {
                            Console.Write("Enter product Category ID: ");
                            if (int.TryParse(Console.ReadLine(), out int productCatId))
                            {
                                productRepo.Create(new ProductDto { Name = pName, Price = pPrice, CategoryId = productCatId });
                                Console.WriteLine("Product added successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Category ID format.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid price format.");
                        }
                        break;

                    case "9":
                        Console.Write("Enter Product ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateProdId))
                        {
                            var prod = productRepo.GetById(updateProdId);
                            if (prod != null)
                            {
                                Console.Write("Enter new name: ");
                                prod.Name = Console.ReadLine();

                                Console.Write("Enter new price: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
                                {
                                    prod.Price = newPrice;

                                    Console.Write($"Enter new Category ID (Current: {prod.CategoryId}). Leave blank to keep current: ");
                                    string catInput = Console.ReadLine();

                                    if (!string.IsNullOrWhiteSpace(catInput))
                                    {
                                        if (int.TryParse(catInput, out int newCatId))
                                        {
                                            prod.CategoryId = newCatId;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Category ID format");
                                            break; 
                                        }
                                    }

                                    productRepo.Update(updateProdId, prod);
                                    Console.WriteLine("Product updated successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid price format. ");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Product not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format.");
                        }
                        break;

                    case "10":
                        Console.Write("Enter Product ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int delProdId))
                        {
                            productRepo.Delete(delProdId);
                            Console.WriteLine("Product deleted (if existed).");
                        }
                        break;

                    case "11":
                        Console.WriteLine("\n..Cart Items list..");
                        foreach (var ci in cartItemRepo.GetAll())
                        {
                            Console.WriteLine($"ID: {ci.CartItemId} | Product ID: {ci.ProductId} | Quantity: {ci.Quantity}");
                        }
                        break;

                    case "12":
                        Console.Write("Enter Cart Item ID: ");
                        if (int.TryParse(Console.ReadLine(), out int cartId))
                        {
                            var ci = cartItemRepo.GetById(cartId);
                            if (ci != null) Console.WriteLine($"Found: ID {ci.CartItemId}, ProductID {ci.ProductId}, Qty {ci.Quantity}");
                            else Console.WriteLine("Cart item not found.");
                        }
                        break;

                    case "13":
                        Console.Write("Enter Product ID for cart: ");
                        if (int.TryParse(Console.ReadLine(), out int cartProdId))
                        {
                            Console.Write("Enter quantity: ");
                            if (int.TryParse(Console.ReadLine(), out int qty))
                            {
                                cartItemRepo.Create(new CartItemDto { ProductId = cartProdId, Quantity = qty });
                                Console.WriteLine("Cart item added successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid quantity format.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Product ID format.");
                        }
                        break;

                    case "14":
                        Console.Write("Enter Cart Item ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateCartId))
                        {
                            var ci = cartItemRepo.GetById(updateCartId);
                            if (ci != null)
                            {
                                Console.Write("Enter new quantity: ");
                                if (int.TryParse(Console.ReadLine(), out int newQty))
                                {
                                    ci.Quantity = newQty;
                                    cartItemRepo.Update(updateCartId, ci);
                                    Console.WriteLine("Cart item updated successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid quantity format.");
                                }
                            }
                            else Console.WriteLine("Cart item not found.");
                        }
                        break;

                    case "15":
                        Console.Write("Enter Cart Item ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int delCartId))
                        {
                            cartItemRepo.Delete(delCartId);
                            Console.WriteLine("Cart item deleted (if existed).");
                        }
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Unknown command lol");
                        break;
                }
            }
        }
    }
}