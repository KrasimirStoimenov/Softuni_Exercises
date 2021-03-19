using System.Xml.Serialization;

namespace CarDealer.DtoModels.InputModels
{
    [XmlType("Sale")]
    public class InputSalesDto
    {
        [XmlElement("carId")]
        public int CarId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }
    }
}
