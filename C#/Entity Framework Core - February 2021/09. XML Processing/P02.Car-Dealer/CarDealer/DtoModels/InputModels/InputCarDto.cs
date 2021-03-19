using System.Xml.Serialization;

namespace CarDealer.DtoModels.InputModels
{
    [XmlType("Car")]
    public class InputCarDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public PartIdDto[] Parts { get; set; }

    }
}
