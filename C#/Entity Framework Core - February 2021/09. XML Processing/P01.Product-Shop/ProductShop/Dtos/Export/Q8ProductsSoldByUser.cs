using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class Q8ProductsSoldByUser
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("products")]
        public Q8ProductsDto[] Products { get; set; }
    }
}