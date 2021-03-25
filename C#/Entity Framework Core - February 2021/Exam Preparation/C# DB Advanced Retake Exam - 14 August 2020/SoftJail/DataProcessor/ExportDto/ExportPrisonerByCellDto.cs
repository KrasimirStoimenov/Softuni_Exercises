namespace SoftJail.DataProcessor.ExportDto
{
    public class ExportPrisonerByCellDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CellNumber { get; set; }
        public ExportOfficerDto[] Officers { get; set; }
        public decimal TotalOfficerSalary { get; set; }
    }
}
