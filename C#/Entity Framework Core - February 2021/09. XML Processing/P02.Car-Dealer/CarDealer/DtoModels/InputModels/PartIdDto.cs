using CarDealer.Models;
using System.Xml.Serialization;

namespace CarDealer.DtoModels.InputModels
{
    [XmlType("partId")]
    public class PartIdDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}