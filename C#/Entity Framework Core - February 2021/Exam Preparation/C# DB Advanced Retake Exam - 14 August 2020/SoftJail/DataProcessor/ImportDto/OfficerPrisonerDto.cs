using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Prisoner")]
    public class OfficerPrisonerDto
    {
        [XmlAttribute("Id")]
        public int PrisonerId { get; set; }
    }
}