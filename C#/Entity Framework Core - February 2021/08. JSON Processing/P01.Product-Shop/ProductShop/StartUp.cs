using System;
using System.IO;
using ProductShop.Data;
using ProductShop.ImportQueries;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            ImportQueriesTask(db);

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