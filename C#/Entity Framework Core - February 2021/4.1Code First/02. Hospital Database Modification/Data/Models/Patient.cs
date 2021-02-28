using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        /*•	Patient:
        	PatientId
        	FirstName (up to 50 characters, unicode)
        	LastName (up to 50 characters, unicode)
        	Address (up to 250 characters, unicode)
        	Email (up to 80 characters, not unicode)
        	HasInsurance
        */

        public int PatientId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Address { get; set; }
        [EmailAddress]
        [MaxLength(80)]
        public string Email { get; set; }
        [Required]
        public bool HasInsurance { get; set; }

        public ICollection<Visitation> Visitations { get; set; } = new HashSet<Visitation>();
        public ICollection<Diagnose> Diagnoses { get; set; } = new HashSet<Diagnose>();
        public ICollection<PatientMedicament> Prescriptions { get; set; } = new HashSet<PatientMedicament>();

    }
}
