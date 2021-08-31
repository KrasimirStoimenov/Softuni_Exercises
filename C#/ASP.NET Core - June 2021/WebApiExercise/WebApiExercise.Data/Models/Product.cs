namespace WebApiExercise.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }
    }
}
