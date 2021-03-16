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
            ExportDataQueries(db);
        }

        private static void ExportDataQueries(CarDealerContext db)
        {
            //Query 01. Export Ordered Customers
            Console.WriteLine(ExportData.GetOrderedCustomers(db));

            //Query 02. Export Cars from Make Toyota
            Console.WriteLine(ExportData.GetCarsFromMakeToyota(db));

            //Query 03. Export Local Suppliers
            Console.WriteLine(ExportData.GetLocalSuppliers(db));

            //Query 04. Export Cars with Their List of Parts
            Console.WriteLine(ExportData.GetCarsWithTheirListOfParts(db));

            //Query 05. Export Total Sales by Customer
            Console.WriteLine(ExportData.GetTotalSalesByCustomer(db));

            //Query 06. Export Sales with Applied Discount
            Console.WriteLine(ExportData.GetSalesWithAppliedDiscount(db));
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