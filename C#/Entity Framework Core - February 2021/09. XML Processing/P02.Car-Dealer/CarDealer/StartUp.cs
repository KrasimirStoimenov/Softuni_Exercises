using AutoMapper;
using CarDealer.Data;
using CarDealer.DtoModels.InputModels;
using CarDealer.Models;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            //Query 01.Import Suppliers
            var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            Console.WriteLine(ImportSuppliers(db, suppliersXml));

            //Query 02. Import Parts
            var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            Console.WriteLine(ImportParts(db, partsXml));
        }
        //Query 02. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            var serializer = new XmlSerializer(typeof(InputPartsDto[]), new XmlRootAttribute("Parts"));

            var partsXml = serializer.Deserialize(new StringReader(inputXml));

            var parts = mapper.Map<Part[]>(partsXml)
                .Where(x => context.Suppliers.Select(x => x.Id).Contains(x.SupplierId))
               .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        //Query 01. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            var serializer = new XmlSerializer(typeof(InputSuppliersDto[]), new XmlRootAttribute("Suppliers"));

            var suppliersXml = serializer.Deserialize(new StringReader(inputXml));

            var suppliers = mapper.Map<Supplier[]>(suppliersXml);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(config);
        }
    }
}