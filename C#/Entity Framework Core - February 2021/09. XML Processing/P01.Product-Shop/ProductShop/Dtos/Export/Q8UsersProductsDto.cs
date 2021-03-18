using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("users")]
    public class Q8UsersProductsDto
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("users")]
        public Q8UsersDto[] Users { get; set; }
    }
}
