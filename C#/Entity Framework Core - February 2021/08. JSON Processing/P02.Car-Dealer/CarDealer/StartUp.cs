using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Castle.Core.Resource;

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

            //Query 01. Import Suppliers
            var suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            ImportSuppliers(db, suppliersJson);

            //Query 02. Import Parts
            var partsJson = File.ReadAllText("../../../Datasets/parts.json");
            ImportParts(db, partsJson);

            //Query 03. Import Cars
            var carsJson = File.ReadAllText("../../../Datasets/cars.json");
            ImportCars(db, carsJson);

            //Query 04. Import Customers
            var customersJson = File.ReadAllText("../../../Datasets/customers.json");
            ImportCustomers(db, customersJson);
        }
        //Query 04. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();
            var customersDto = JsonConvert.DeserializeObject<IEnumerable<CustomerInputModel>>(inputJson);
            var customers = mapper.Map<IEnumerable<Customer>>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        //Query 03. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var carsDto = JsonConvert.DeserializeObject<IEnumerable<CarInputModel>>(inputJson);

            var cars = new List<Car>();

            foreach (var car in carsDto)
            {
                var currentCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance,
                };

                foreach (var partId in car.PartsId.Distinct())
                {
                    var currentPart = new PartCar()
                    {
                        Car = currentCar,
                        PartId = partId
                    };

                    currentCar.PartCars.Add(currentPart);
                }

                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //Query 02. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var partsDto = JsonConvert.DeserializeObject<IEnumerable<PartInputModel>>(inputJson);
            var parts = mapper.Map<IEnumerable<Part>>(partsDto);

            var contextSuppliers = context.Suppliers.Select(x => x.Id).ToList();
            parts = parts.Where(x => contextSuppliers.Contains(x.SupplierId)).ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        //Query 01. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var suppliersDto = JsonConvert.DeserializeObject<IEnumerable<SupplierInputModel>>(inputJson);
            var suppliers = mapper.Map<IEnumerable<Supplier>>(suppliersDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
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