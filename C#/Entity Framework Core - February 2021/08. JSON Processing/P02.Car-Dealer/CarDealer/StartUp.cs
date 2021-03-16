using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.OutputModels;
using CarDealer.ImportExportData;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
            
            ImportDataQueries(db);

            //Query 01. Export Ordered Customers
            Console.WriteLine(GetOrderedCustomers(db));

            //Query 02. Export Cars from Make Toyota
            Console.WriteLine(GetCarsFromMakeToyota(db));

            //Query 03. Export Local Suppliers
            Console.WriteLine(GetLocalSuppliers(db));

            //Query 04. Export Cars with Their List of Parts
            Console.WriteLine(GetCarsWithTheirListOfParts(db));

            //Query 05. Export Total Sales by Customer
            Console.WriteLine(GetTotalSalesByCustomer(db));

            //Query 06. Export Sales with Applied Discount
            Console.WriteLine(GetSalesWithAppliedDiscount(db));

        }
        //Query 06. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    price = x.Car.PartCars.Select(p => p.Part.Price).Sum().ToString("F2"),
                    priceWithDiscount = (x.Car.PartCars.Select(p => p.Part.Price).Sum() * (1 - (x.Discount * 0.01M))).ToString("F2")
                })
                .ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }

        //Query 05. Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Count >= 1)
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count,
                    spentMoney = x.Sales.Select(c => c.Car.PartCars.Select(p => p.Part.Price).Sum()).Sum()
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        //Query 04. Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance,
                    },
                    parts = x.PartCars.Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("F2")
                    })

                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        //Query 03. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            InitializeAutoMapper();

            var suppliers = context.Suppliers
                .Include(x => x.Parts)
                .Where(x => x.IsImporter == false)
                .ToList();

            var suppliersDto = mapper.Map<IEnumerable<SupplierOutputModel>>(suppliers);

            var json = JsonConvert.SerializeObject(suppliersDto, Formatting.Indented);

            return json;
        }

        //Query 02. Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            InitializeAutoMapper();

            var toyotaCars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            var carsDto = mapper.Map<IEnumerable<CarOutputModel>>(toyotaCars);

            var json = JsonConvert.SerializeObject(carsDto, Formatting.Indented);

            return json;
        }

        //Query 01. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            InitializeAutoMapper();

            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .ToList();

            var customersDto = mapper.Map<IEnumerable<CustomerOutputModel>>(customers);

            var json = JsonConvert.SerializeObject(customersDto, Formatting.Indented);

            return json;
        }

        private static void ImportDataQueries(CarDealerContext db)
        {
            //Query 01. Import Suppliers
            var suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            Console.WriteLine(ImportData.ImportSuppliers(db, suppliersJson));

            //Query 02. Import Parts
            var partsJson = File.ReadAllText("../../../Datasets/parts.json");
            Console.WriteLine(ImportData.ImportParts(db, partsJson));

            //Query 03. Import Cars
            var carsJson = File.ReadAllText("../../../Datasets/cars.json");
            Console.WriteLine(ImportData.ImportCars(db, carsJson));

            //Query 04. Import Customers
            var customersJson = File.ReadAllText("../../../Datasets/customers.json");
            Console.WriteLine(ImportData.ImportCustomers(db, customersJson));

            //Query 05. Import Sales
            var salesJson = File.ReadAllText("../../../Datasets/sales.json");
            Console.WriteLine(ImportData.ImportSales(db, salesJson));
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