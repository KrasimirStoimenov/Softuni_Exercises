using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Data.Models
{
    using static DataConstants;

    public class User
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; init; }

        [Required]
        public string Email { get; init; }

        [Required]
        public string Password { get; init; }

        public ICollection<UserTrip> UserTrips { get; init; } = new HashSet<UserTrip>();
    }
}
