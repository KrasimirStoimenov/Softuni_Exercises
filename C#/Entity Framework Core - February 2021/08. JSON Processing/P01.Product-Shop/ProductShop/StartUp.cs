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

            QueryAndImportData(db);
            QueryAndExportData(db);

        }
        public static void QueryAndExportData(ProductShopContext db)
        {
            //Query 1. Export Products in Range
            Console.WriteLine(ExportQueriesTasks.GetProductsInRange(db));

            //Query 2. Export Successfully Sold Products
            Console.WriteLine(ExportQueriesTasks.GetProductsInRange(db));

            //Query 3. Export Categories by Products Count
            Console.WriteLine(ExportQueriesTasks.GetCategoriesByProductsCount(db));

            //Query 4. Export Users and Products
            Console.WriteLine(ExportQueriesTasks.GetUsersWithProducts(db));
        }

        public static void QueryAndImportData(ProductShopContext db)
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