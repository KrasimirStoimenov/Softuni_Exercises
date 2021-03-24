using SoftJail.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonersImportDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"The [A-Z][a-z]+")]
        public string Nickname { get; set; }

        [Range(18, 65)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        [Range(0, Double.PositiveInfinity)]
        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public ICollection<MailImportDto> Mails { get; set; }
    }
}
