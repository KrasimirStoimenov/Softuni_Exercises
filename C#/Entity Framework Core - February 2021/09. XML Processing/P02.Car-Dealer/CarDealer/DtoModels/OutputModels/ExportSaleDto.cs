using System.Xml.Serialization;

namespace CarDealer.DtoModels.OutputModels
{
    [XmlType("sale")]
    public class ExportSaleDto
    {
        [XmlElement("car")]
        public ExportSoldCarsDto SoldCars { get; set; } = new ExportSoldCarsDto();

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public decimal PriceWithDiscount { get; set; }
    }
}
