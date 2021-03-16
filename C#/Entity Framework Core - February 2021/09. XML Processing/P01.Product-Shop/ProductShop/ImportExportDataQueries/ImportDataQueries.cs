using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ProductShop.ImportExportDataQueries
{
    public class ImportDataQueries
    {
        private static IMapper mapper;

        //Query 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("Users"));
            var usersXml = (UserDto[])serializer.Deserialize(new StringReader(inputXml));

            var users = mapper.Map<User[]>(usersXml);
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        //Query 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var serializer = new XmlSerializer(typeof(ProductDto[]), new XmlRootAttribute("Products"));
            var productsXml = (ProductDto[])serializer.Deserialize(new StringReader(inputXml));

            var products = mapper.Map<Product[]>(productsXml);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //Query 3. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));
            var categoriesXml = (CategoryDto[])serializer.Deserialize(new StringReader(inputXml));

            var categories = mapper.Map<Category[]>(categoriesXml);
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        //Query 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var serializer = new XmlSerializer(typeof(CategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));
            var categoryProductsXml = (CategoryProductDto[])serializer.Deserialize(new StringReader(inputXml));

            var categoryProducts = mapper.Map<CategoryProduct[]>(categoryProductsXml);

            var categoryIds = context.Categories.Select(x => x.Id);
            var productIds = context.Products.Select(x => x.Id);

            var filteredCategoryProducts = categoryProducts
                .Where(x => categoryIds.Contains(x.CategoryId) && productIds.Contains(x.ProductId))
                .ToArray();

            context.CategoryProducts.AddRange(filteredCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {filteredCategoryProducts.Length}";
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
