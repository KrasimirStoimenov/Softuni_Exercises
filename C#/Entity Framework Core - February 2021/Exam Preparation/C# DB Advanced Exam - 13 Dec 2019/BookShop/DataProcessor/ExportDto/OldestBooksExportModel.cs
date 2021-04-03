using System.Xml.Serialization;

namespace BookShop.DataProcessor.ExportDto
{
    [XmlType("Book")]
    public class OldestBooksExportModel
    {
        [XmlAttribute("Pages")]
        public int Pages { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }
    }
}
//<Books>
//  <Book Pages="4881">
//    <Name>Sierra Marsh Fern</Name>
//    <Date>03/18/2016</Date>
//  </Book>
