using CarDealer.Models;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CarDealer.DtoModels.InputModels
{
    [XmlType("Customer")]
    public class InputCustomersDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("birthDate")]
        public string BirthDate { get; set; }

        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }

    }
}
