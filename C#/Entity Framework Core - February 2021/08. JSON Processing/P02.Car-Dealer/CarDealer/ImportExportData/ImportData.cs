using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.ImportExportData
{
    public static class ImportData
    {
        private static IMapper mapper;
        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(config);
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

        //Query 05. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var salesDto = JsonConvert.DeserializeObject<IEnumerable<SaleInputModel>>(inputJson);
            var sales = mapper.Map<IEnumerable<Sale>>(salesDto);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }
    }
}
