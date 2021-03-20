using System.Xml.Serialization;
using CarDealer.Models;

namespace CarDealer.DtoModels.OutputModels
{
    [XmlType("suplier")]
    public class ExportSuppliersDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public int PartCount { get; set; }

    }
}
