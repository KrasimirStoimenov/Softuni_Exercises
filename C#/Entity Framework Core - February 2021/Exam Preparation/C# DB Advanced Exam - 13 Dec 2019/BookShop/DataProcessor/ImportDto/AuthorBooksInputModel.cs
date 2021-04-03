using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor.ImportDto
{
    public class AuthorBooksInputModel
    {
        [Required]
        public int? Id { get; set; }
    }
}