using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.ImportQueries;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            //
            //ImportQueriesTask(db);

            //Query 1. Export Products in Range
            Console.WriteLine(GetProductsInRange(db));

            //Query 2. Export Successfully Sold Products
            Console.WriteLine(GetProductsInRange(db));

            //Query 3. Export Categories by Products Count
            Console.WriteLine(GetCategoriesByProductsCount(db));
        }
        //Query 3. Export Categories by Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = x.CategoryProducts.Average(pr => pr.Product.Price).ToString("F2"),
                    totalRevenue = x.CategoryProducts.Sum(pr => pr.Product.Price).ToString("F2")
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var resultJson = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return resultJson;
        }

        //Query 2. Export Successfully Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                        .Where(b => b.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                        .ToList()
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var resultJson = JsonConvert.SerializeObject(users, Formatting.Indented);

            return resultJson;
        }

        //Query 1. Export Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .OrderBy(x => x.price)
                .ToList();

            var resultJson = JsonConvert.SerializeObject(products, Formatting.Indented);

            return resultJson;
        }

        public static void ImportQueriesTask(ProductShopContext db)
        {
            //Query 2. Import Users
            var inputJson2 = File.ReadAllText("../../../Datasets/users.json");
            Console.WriteLine(ImportQueriesTasks.ImportUsers(db, inputJson2));

            //Query 3. Import Products
            var inputJson3 = File.ReadAllText("../../../Datasets/products.json");
            Console.WriteLine(ImportQueriesTasks.ImportProducts(db, inputJson3));

            //Query 4. Import Categories
            var inputJson4 = File.ReadAllText("../../../Datasets/categories.json");
            Console.WriteLine(ImportQueriesTasks.ImportCategories(db, inputJson4));

            //Query 5. Import Categories and Products
            var inputJson5 = File.ReadAllText("../../../Datasets/categories-products.json");
            Console.WriteLine(ImportQueriesTasks.ImportCategoryProducts(db, inputJson5));
        }

    }
}