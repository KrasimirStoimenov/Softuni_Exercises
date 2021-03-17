using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.ImportExportDataQueries;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            //
            //ImportData(db);
            //
            ////Query 5. Products In Range
            //Console.WriteLine(GetProductsInRange(db));

            //Query 6. Sold Products
            Console.WriteLine(GetSoldProducts(db));

        }
        //Query 6. Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Count >= 1)
                .Select(x => new ExportUserDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(p => new UsersProductSoldDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var xmlSerializer = new XmlSerializer(typeof(ExportUserDto[]), new XmlRootAttribute("Users"));
            xmlSerializer.Serialize(new StringWriter(sb), users,namespaces);

            return sb.ToString().TrimEnd();
        }

        //Query 5. Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            InitializeAutoMapper();

            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Take(10)
                .ProjectTo<ExportProductDto>(mapper.ConfigurationProvider)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportProductDto[]), new XmlRootAttribute("Products"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, products, namespaces);
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