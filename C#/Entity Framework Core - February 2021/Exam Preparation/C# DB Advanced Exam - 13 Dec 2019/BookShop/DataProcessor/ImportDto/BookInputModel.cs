using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using BookShop.Data.Models.Enums;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType("Book")]
    public class BookInputModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(1,3)]
        public string Genre { get; set; }

        [Range(0.01,double.MaxValue)]
        public decimal Price { get; set; }

        [Range(50,5000)]
        public int Pages { get; set; }

        [Required]
        public string PublishedOn { get; set; }
    }
}

//•	Id - integer, Primary Key
//•	Name - text with length [3, 30]. (required)
//•	Genre - enumeration of type Genre, with possible values (Biography = 1, Business = 2, Science = 3) (required)
//•	Price - decimal in range between 0.01 and max value of the decimal
//•	Pages – integer in range between 50 and 5000
//•	PublishedOn - date and time (required)
//•	AuthorsBooks - collection of type AuthorBook