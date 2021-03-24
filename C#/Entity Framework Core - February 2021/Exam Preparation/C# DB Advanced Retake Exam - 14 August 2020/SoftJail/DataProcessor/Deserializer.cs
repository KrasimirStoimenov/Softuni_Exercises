namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var departmentCellsJson = JsonConvert.DeserializeObject<DepartmentsImportDto[]>(jsonString);

            var departments = new List<Department>();

            foreach (var departmentJson in departmentCellsJson)
            {
                if (!IsValid(departmentJson))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Department currentDepartment = new Department()
                {
                    Name = departmentJson.Name
                };

                bool hasInvalidCell = false;
                foreach (var cellJson in departmentJson.Cells)
                {
                    if (!IsValid(cellJson))
                    {
                        hasInvalidCell = true;
                        break;
                    }

                    Cell currentCell = new Cell()
                    {
                        CellNumber = cellJson.CellNumber,
                        HasWindow = cellJson.HasWindow
                    };

                    currentDepartment.Cells.Add(currentCell);
                }

                if (hasInvalidCell)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (currentDepartment.Cells.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                departments.Add(currentDepartment);

                sb.AppendLine($"Imported {departmentJson.Name} with {departmentJson.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}