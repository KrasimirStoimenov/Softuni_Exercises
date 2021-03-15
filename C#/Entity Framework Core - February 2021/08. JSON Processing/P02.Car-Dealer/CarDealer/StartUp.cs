using System;
using System.IO;
using CarDealer.Data;
using CarDealer.ImportExportData;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            ImportDataQueries(db);
            

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
    }
}