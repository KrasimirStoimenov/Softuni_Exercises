using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DtoModels.OutputModels;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.ImportExportDataQueries
{
    class ExportDataQueries
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

        //Query 10. Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new ExportCustomersDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpendMoney = c.Sales.SelectMany(s => s.Car.PartCars).Sum(x => x.Part.Price)
                })
                .OrderByDescending(m => m.SpendMoney)
                .ToArray();

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var serializer = new XmlSerializer(typeof(ExportCustomersDto[]), new XmlRootAttribute("customers"));
            serializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Query 11. Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new ExportSaleDto
                {
                    SoldCars = new ExportSoldCarsDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance,
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = x.Car.PartCars.Sum(p => p.Part.Price)
                                     - (x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100)
                })
                .ToArray();

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var serializer = new XmlSerializer(typeof(ExportSaleDto[]), new XmlRootAttribute("sales"));
            serializer.Serialize(new StringWriter(sb), sales, namespaces);

            return sb.ToString().Trim();
        }
    }
}
