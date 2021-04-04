using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ProjectsExportModel
    {
        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        public string ProjectName { get; set; }

        public string HasEndDate { get; set; }

        public TaskExportModel[] Tasks { get; set; }
    }
}