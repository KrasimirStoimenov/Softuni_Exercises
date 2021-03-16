using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
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


            //Query 1. Import Users
            var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            Console.WriteLine(ImportUsers(db, usersXml));
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