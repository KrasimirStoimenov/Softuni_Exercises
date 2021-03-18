using System.Xml.Serialization;

namespace CarDealer.DtoModels.InputModels
{
    [XmlType("Supplier")]
    public class InputSuppliersDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}
