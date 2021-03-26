using SoftJail.Data.Models;
using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class ExportPrisonerMailsDto
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public ExportMailsDto[] Messages { get; set; }
    }
}
