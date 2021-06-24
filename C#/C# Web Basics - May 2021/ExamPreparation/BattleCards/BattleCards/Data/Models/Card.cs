using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleCards.Data.Models
{
    using static DataConstants;

    public class Card
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(CardNameMaxLength)]
        public string Name { get; init; }

        [Required]
        public string ImageUrl { get; init; }

        [Required]
        public string Keyword { get; init; }

        public int Attack { get; init; }

        public int Health { get; init; }

        [Required]
        [MaxLength()]
        public string Description { get; init; }

        public ICollection<UserCard> UserCard { get; init; } = new HashSet<UserCard>();
    }
}
//•	Has Id – an int, Primary Key
//•	Has Name – a string (required); min. length: 5, max. length: 15
//•	Has ImageUrl – a string (required)
//•	Has Keyword – a string (required)
//•	Has Attack – an int (required); cannot be negative
//•	Has Health – an int (required); cannot be negative
//•	Has a Description – a string with max length 200 (required)
//•	Has UserCard collection
