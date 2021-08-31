namespace WebApiExercise.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProductInputViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Name { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 20)]
        public string Description { get; set; }
    }
}
