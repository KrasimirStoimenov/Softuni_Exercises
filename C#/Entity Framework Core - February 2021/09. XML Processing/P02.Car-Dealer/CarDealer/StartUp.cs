using AutoMapper;
using CarDealer.Data;
using CarDealer.DtoModels.InputModels;
using CarDealer.ImportExportDataQueries;
using CarDealer.Models;
using System;
using System.Collections.Generic;
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

            ImportData(db);


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