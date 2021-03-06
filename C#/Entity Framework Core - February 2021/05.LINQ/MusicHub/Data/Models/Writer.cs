﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class Writer
    {
        /*Writer
        •	Id – Integer, Primary Key
        •	Name – text with max length 20 (required)
        •	Pseudonym – text
        •	Songs – collection of type Song
        */

        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Pseudonym { get; set; }

        public ICollection<Song> Songs { get; set; } = new HashSet<Song>();
    }
}
