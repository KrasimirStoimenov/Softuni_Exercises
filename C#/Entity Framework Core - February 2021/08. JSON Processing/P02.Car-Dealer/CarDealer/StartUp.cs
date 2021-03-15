﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            //
            //ImportDataQueries(db);

            //Query 01. Export Ordered Customers
            //Console.WriteLine(GetOrderedCustomers(db));

            //Query 02. Export Cars from Make Toyota

            //Query 03. Export Local Suppliers
            Console.WriteLine(GetLocalSuppliers(db));
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