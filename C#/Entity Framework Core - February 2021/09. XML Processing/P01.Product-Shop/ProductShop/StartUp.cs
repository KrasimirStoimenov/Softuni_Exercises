using ProductShop.Data;
using ProductShop.ImportExportDataQueries;
using System;
using System.IO;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            ImportData(db);
            ExportData(db);
        }

        private static void ExportData(ProductShopContext db)
        {
            //Query 5. Products In Range
            Console.WriteLine(ExportDataQueries.GetProductsInRange(db));

            //Query 6. Sold Products
            Console.WriteLine(ExportDataQueries.GetSoldProducts(db));

            //Query 7. Categories By Products Count
            Console.WriteLine(ExportDataQueries.GetCategoriesByProductsCount(db));

            //Query 8. Users and Products
            Console.WriteLine(ExportDataQueries.GetUsersWithProducts(db));

        }

        private static void ImportData(ProductShopContext db)
        {
            //Query 1. Import Users
            var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            Console.WriteLine(ImportDataQueries.ImportUsers(db, usersXml));

            //Query 2.Import Products
            var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            Console.WriteLine(ImportDataQueries.ImportProducts(db, productsXml));

            //Query 3. Import Categories
            var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            Console.WriteLine(ImportDataQueries.ImportCategories(db, categoriesXml));

            //Query 4. Import Categories and Products
            var categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            Console.WriteLine(ImportDataQueries.ImportCategoryProducts(db, categoriesProductsXml));
        }
    }
}