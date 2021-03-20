using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DtoModels.InputModels;
using CarDealer.DtoModels.OutputModels;
using CarDealer.ImportExportDataQueries;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            //
            //ImportData(db);
            //
            ////Query 06. Cars With Distance
            //Console.WriteLine(GetCarsWithDistance(db));
            //
            ////Query 07. Cars from make BMW
            //Console.WriteLine(GetCarsFromMakeBmw(db));

            ////Query 08. Local Suppliers
            //Console.WriteLine(GetLocalSuppliers(db));

            //Query 09. Cars with Their List of Parts
            Console.WriteLine(GetCarsWithTheirListOfParts(db));

        }
        //Query 09. Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new ExportCarWithPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(p => new ExportPartsDto
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var serializer = new XmlSerializer(typeof(ExportCarWithPartsDto[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }
        //Query 08. Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            InitializeAutoMapper();

            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .ProjectTo<ExportSuppliersDto>(mapper.ConfigurationProvider)
                .ToArray();

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var serializer = new XmlSerializer(typeof(ExportSuppliersDto[]), new XmlRootAttribute("suppliers"));
            serializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Query 07. Cars from make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            InitializeAutoMapper();

            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ProjectTo<BmwCarExportDto>(mapper.ConfigurationProvider)
                .ToArray();

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var serializer = new XmlSerializer(typeof(BmwCarExportDto[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Query 06. Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            InitializeAutoMapper();

            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var serializer = new XmlSerializer(typeof(ExportCarDto[]), new XmlRootAttribute("cars"));

            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        private static void ImportData(CarDealerContext db)
        {
            //Query 01.Import Suppliers
            var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            Console.WriteLine(ImportDataQueries.ImportSuppliers(db, suppliersXml));

            //Query 02. Import Parts
            var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            Console.WriteLine(ImportDataQueries.ImportParts(db, partsXml));

            //Query 03. Import Cars
            var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            Console.WriteLine(ImportDataQueries.ImportCars(db, carsXml));

            //Query 04. Import Customers
            var customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            Console.WriteLine(ImportDataQueries.ImportCustomers(db, customersXml));

            //Query 05. Import Sales
            var salesXml = File.ReadAllText("../../../Datasets/sales.xml");
            Console.WriteLine(ImportDataQueries.ImportSales(db, salesXml));
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