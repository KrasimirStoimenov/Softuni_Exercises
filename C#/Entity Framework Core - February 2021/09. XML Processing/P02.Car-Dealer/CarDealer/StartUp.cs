using AutoMapper;
using CarDealer.Data;
using CarDealer.ImportExportDataQueries;
using System;
using System.IO;

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
            ExportData(db);
        }

        private static void ExportData(CarDealerContext db)
        {
            //Query 06. Cars With Distance
            Console.WriteLine(ExportDataQueries.GetCarsWithDistance(db));

            //Query 07. Cars from make BMW
            Console.WriteLine(ExportDataQueries.GetCarsFromMakeBmw(db));

            //Query 08. Local Suppliers
            Console.WriteLine(ExportDataQueries.GetLocalSuppliers(db));

            //Query 09. Cars with Their List of Parts
            Console.WriteLine(ExportDataQueries.GetCarsWithTheirListOfParts(db));

            //Query 10. Total Sales by Customer
            Console.WriteLine(ExportDataQueries.GetTotalSalesByCustomer(db));

            //Query 11. Sales with Applied Discount
            Console.WriteLine(ExportDataQueries.GetSalesWithAppliedDiscount(db));
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
    }
}