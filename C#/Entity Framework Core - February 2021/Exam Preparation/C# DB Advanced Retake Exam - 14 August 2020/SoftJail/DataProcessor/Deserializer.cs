﻿namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
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
            var sb = new StringBuilder();

            var prisonersMailsJson = JsonConvert.DeserializeObject<PrisonersImportDto[]>(jsonString);

            List<Prisoner> prisoners = new List<Prisoner>();

            foreach (var prisonerJson in prisonersMailsJson)
            {
                if (!IsValid(prisonerJson))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Prisoner currentPrisoner = new Prisoner
                {
                    FullName = prisonerJson.FullName,
                    Nickname = prisonerJson.Nickname,
                    Age = prisonerJson.Age,
                    IncarcerationDate = DateTime.ParseExact(prisonerJson.IncarcerationDate,"dd/MM/yyyy",CultureInfo.InvariantCulture),
                    Bail = prisonerJson.Bail,
                    CellId = prisonerJson.CellId
                };

                if (string.IsNullOrEmpty(prisonerJson.ReleaseDate))
                {
                    currentPrisoner.ReleaseDate = null;
                }
                else
                {
                    currentPrisoner.ReleaseDate = DateTime.ParseExact(prisonerJson.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                bool hasInvalidMail = false;
                foreach (var mailJson in prisonerJson.Mails)
                {
                    if (!IsValid(mailJson))
                    {
                        hasInvalidMail = true;
                        break;
                    }

                    currentPrisoner.Mails.Add(new Mail()
                    {
                        Description = mailJson.Description,
                        Sender = mailJson.Sender,
                        Address = mailJson.Address
                    });
                }

                if (hasInvalidMail)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                prisoners.Add(currentPrisoner);
                sb.AppendLine($"Imported {currentPrisoner.FullName} {currentPrisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
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