using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            db.Database.EnsureCreated();

            //Query 2. Import Users
            var inputJson2 = File.ReadAllText("../../../Datasets/users.json");
            Console.WriteLine(ImportUsers(db, inputJson2));

            //Query 3. Import Products
            var inputJson3 = File.ReadAllText("../../../Datasets/products.json");
            Console.WriteLine(ImportProducts(db, inputJson3));

            //Query 4. Import Categories
            var inputJson4 = File.ReadAllText("../../../Datasets/categories.json");
            Console.WriteLine(ImportCategories(db, inputJson4));

            //Query 5. Import Categories and Products
            var inputJson5 = File.ReadAllText("../../../Datasets/categories-products.json");
            Console.WriteLine(ImportCategoryProducts(db, inputJson5));
        }
        //Query 5. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        //Query 4. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(x => x.Name != null)
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        //Query 3. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //Query 2. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
    }
}