using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.Models
{
    public class User
    {
        //•	Users have an id, first name (optional) and last name (at least 3 characters) and age (optional).

        public int Id { get; set; }
        public string FirstName { get; set; }
        [MinLength(3)]
        public string LastName { get; set; }
        public int? Age { get; set; }

        public ICollection<Product> ProductsSold { get; set; } = new HashSet<Product>();
        public ICollection<Product> ProductsBought { get; set; } = new HashSet<Product>();
    }
}
