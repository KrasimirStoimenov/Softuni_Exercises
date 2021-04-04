namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var sb = new StringBuilder();

            var projects = context.Projects
                .Where(x => x.Tasks.Count > 0)
                .ToArray()
                .Select(x => new ProjectsExportModel
                {
                    TasksCount = x.Tasks.Count,
                    ProjectName = x.Name,
                    HasEndDate = x.DueDate == null ? "No" : "Yes",
                    Tasks = x.Tasks.Select(t => new TaskExportModel
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(x => x.Name)
                    .ToArray()
                })
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.ProjectName)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ProjectsExportModel[]), new XmlRootAttribute("Projects"));

            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), projects, ns);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(x => x.EmployeesTasks.Any(x => x.Task.OpenDate >= date))
                .ToList()
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                        .Where(et => et.Task.OpenDate >= date)
                        .OrderByDescending(t => t.Task.DueDate)
                        .ThenBy(t => t.Task.Name)
                        .Select(t => new
                        {
                            TaskName = t.Task.Name,
                            OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = t.Task.LabelType.ToString(),
                            ExecutionType = t.Task.ExecutionType.ToString()
                        })
                        .ToList()
                })
                .OrderByDescending(x => x.Tasks.Count)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }
    }
}