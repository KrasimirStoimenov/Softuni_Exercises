using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.ImportExportDataQueries;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            ImportData(db);
            //Query 5. Products In Range
            Console.WriteLine(GetProductsInRange(db));

        }
        //Query 5. Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            InitializeAutoMapper();

            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Take(10)
                .ProjectTo<ProductExportDto>(mapper.ConfigurationProvider)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ProductExportDto[]), new XmlRootAttribute("Products"));

            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, products);
            };

            return sb.ToString().TrimEnd();
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

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = new Mapper(config);
        }

    }
}