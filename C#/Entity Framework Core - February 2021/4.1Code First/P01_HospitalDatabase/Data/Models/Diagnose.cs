using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    public class Diagnose
    {
        /*•	Diagnose:
        	DiagnoseId
        	Name (up to 50 characters, unicode)
        	Comments (up to 250 characters, unicode)
        	Patient
        */

        public int DiagnoseId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string Comments { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
