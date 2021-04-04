namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ProjectXmlInputModel[]), new XmlRootAttribute("Projects"));
            var projects = xmlSerializer.Deserialize(new StringReader(xmlString)) as ProjectXmlInputModel[];

            foreach (var project in projects)
            {
                var isOpenDateValid = DateTime.TryParseExact(project.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime openDate);
                var isDueDateValid = DateTime.TryParseExact(project.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate);

                if (!IsValid(project) || !isOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currentProject = new Project
                {
                    Name = project.Name,
                    OpenDate = openDate,
                    DueDate = isDueDateValid ? (DateTime?)dueDate : null
                };

                foreach (var task in project.Tasks)
                {
                    var isValidTaskOpenDate = DateTime.TryParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDate);
                    var isValidTaskDueDate = DateTime.TryParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate);

                    var isValidExecutionType = Enum.TryParse<ExecutionType>(task.ExecutionType, out var executionType);
                    var isValidLabelType = Enum.TryParse<LabelType>(task.LabelType, out var labelType);

                    if (!IsValid(task) || !isValidTaskOpenDate || !isValidTaskDueDate || !isValidExecutionType || !isValidLabelType || taskOpenDate < openDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (currentProject.DueDate != null && taskDueDate > dueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    currentProject.Tasks.Add(new Task
                    {
                        Name = task.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = executionType,
                        LabelType = labelType
                    });
                }

                context.Projects.Add(currentProject);
                context.SaveChanges();

                sb.AppendLine(string.Format(SuccessfullyImportedProject, currentProject.Name, currentProject.Tasks.Count));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var jsonEmployees = JsonConvert.DeserializeObject<IEnumerable<EmployeesJsonInputModel>>(jsonString);

            foreach (var employee in jsonEmployees)
            {
                if (!IsValid(employee))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (employee.Username.Any(x => !char.IsLetterOrDigit(x)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currentEmployee = new Employee
                {
                    Username = employee.Username,
                    Email = employee.Email,
                    Phone = employee.Phone,
                };

                foreach (var taskId in employee.Tasks.Distinct())
                {
                    var task = context.Tasks.FirstOrDefault(x => x.Id == taskId);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    currentEmployee.EmployeesTasks.Add(new EmployeeTask { TaskId = taskId });

                }

                context.Employees.Add(currentEmployee);
                context.SaveChanges();

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, currentEmployee.Username, currentEmployee.EmployeesTasks.Count));
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}