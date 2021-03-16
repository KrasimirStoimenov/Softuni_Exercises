﻿using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();


            //Query 1. Import Users
            var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            Console.WriteLine(ImportUsers(db, usersXml));
            
            //Query 2.Import Products
            var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            Console.WriteLine(ImportProducts(db, productsXml));
            
            //Query 3. Import Categories
            var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            Console.WriteLine(ImportCategories(db, categoriesXml));

            //Query 4. Import Categories and Products
            var categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            Console.WriteLine(ImportCategoryProducts(db, categoriesProductsXml));
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