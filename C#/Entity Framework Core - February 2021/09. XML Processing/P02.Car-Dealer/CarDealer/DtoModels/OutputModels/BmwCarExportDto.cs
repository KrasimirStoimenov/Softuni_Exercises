using CarDealer.Models;
using System.Xml.Serialization;

namespace CarDealer.DtoModels.OutputModels
{
    [XmlType("car")]
    public class BmwCarExportDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
