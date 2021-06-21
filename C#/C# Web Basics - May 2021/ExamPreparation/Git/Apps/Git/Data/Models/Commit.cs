using System.ComponentModel.DataAnnotations;
using System;

namespace Git.Data.Models
{
    public class Commit
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; init; }

        public DateTime CreatedOn { get; init; }

        public string CreatorId { get; init; }

        public User Creator { get; init; }

        public string RepositoryId { get; init; }
        
        public Repository Repository { get; init; }
    }
}
//•	Has an Id – a string, Primary Key
//•	Has a Description – a string with min length 5 (required)
//•	Has a CreatedOn – a datetime (required)
//•	Has a CreatorId – a string
//•	Has Creator – a User object
//•	Has RepositoryId – a string
//•	Has Repository– a Repository object
