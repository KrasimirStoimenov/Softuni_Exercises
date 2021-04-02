using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OfficerInputModel
    {
        
        [Required]
        [StringLength(30,MinimumLength = 3)]
        public string Name { get; set; }

        [Range (0, double.MaxValue)]
        public decimal Money { get; set; }

        public string Position { get; set; }

        public string Weapon { get; set; }

        public int DepartmentId { get; set; }

        [XmlArray]
        public OfficerPrisonerInputModel[] Prisoners { get; set; }
    }
}