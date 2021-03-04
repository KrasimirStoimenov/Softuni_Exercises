using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Data.Models
{
    public class Store
    {
        /*•	Store:
        	StoreId
        	Name (up to 80 characters, unicode)
        	Sales
        */
        public int StoreId { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
    }
}
