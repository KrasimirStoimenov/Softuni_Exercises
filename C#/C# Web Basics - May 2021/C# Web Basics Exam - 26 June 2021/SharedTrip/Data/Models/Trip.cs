using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Data.Models
{
    using static DataConstants;

    public class Trip
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string StartPoint { get; init; }

        [Required]
        public string EndPoint { get; init; }

        public DateTime DepartureTime { get; init; }

        [Range(0, TripSeatsMaxValue)]
        public int Seats { get; set; }

        [Required]
        [MaxLength(TripDescriptionMaxLength)]
        public string Description { get; init; }

        public string ImagePath { get; init; }

        public ICollection<UserTrip> UserTrips { get; init; } = new HashSet<UserTrip>();

    }
}