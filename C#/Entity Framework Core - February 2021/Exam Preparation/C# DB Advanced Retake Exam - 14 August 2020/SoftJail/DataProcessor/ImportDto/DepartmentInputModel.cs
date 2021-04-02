using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentInputModel
    {
        [Required]
        [StringLength(25,MinimumLength = 3)]
        public string Name { get; set; }
        public IEnumerable<DepartmentCellInputModel> Cells { get; set; }
    }
}