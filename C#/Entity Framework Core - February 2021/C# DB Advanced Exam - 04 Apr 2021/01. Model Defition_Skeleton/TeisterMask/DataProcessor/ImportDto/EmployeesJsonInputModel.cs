using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class EmployeesJsonInputModel
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{3}-[0-9]{3}-[0-9]{4}")]
        public string Phone { get; set; }
        public int[] Tasks { get; set; }
    }
}
//•	Username - text with length [3, 40]. Should contain only lower or upper case letters and/or digits. (required)