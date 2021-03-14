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