using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentsImportDto
    {
        public DepartmentsImportDto()
        {
            this.Cells = new HashSet<CellImportDto>();
        }

        [JsonProperty("Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }

        public ICollection<CellImportDto> Cells { get; set; }
    }
}
