﻿using System;
using System.IO;
using System.Linq;
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

        }
        //Query 6. Export Successfully Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {

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