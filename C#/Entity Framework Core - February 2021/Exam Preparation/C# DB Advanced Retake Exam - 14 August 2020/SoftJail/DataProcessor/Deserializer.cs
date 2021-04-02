namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Enums;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private static string ErrorMessage = "Invalid Data";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var jsonDepartments = JsonConvert.DeserializeObject<IEnumerable<DepartmentInputModel>>(jsonString);

            foreach (var department in jsonDepartments)
            {
                if (!IsValid(department) || !department.Cells.Any() || !department.Cells.All(x => IsValid(x)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currentDepartment = new Department
                {
                    Name = department.Name,
                    Cells = department.Cells.Select(x => new Cell
                    {
                        CellNumber = x.CellNumber,
                        HasWindow = x.HasWindow
                    })
                    .ToList()
                };

                context.Departments.Add(currentDepartment);
                context.SaveChanges();
                sb.AppendLine($"Imported {currentDepartment.Name} with {currentDepartment.Cells.Count} cells");
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var json = JsonConvert.DeserializeObject<IEnumerable<PrisonerInputModel>>(jsonString);

            foreach (var prisoner in json)
            {
                if (!IsValid(prisoner) || !prisoner.Mails.All(x => IsValid(x)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var incarcerationDate = DateTime.ParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var isValidReleaseDate = DateTime.TryParseExact(prisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var releaseDate);

                var currentPrisoner = new Prisoner
                {
                    FullName = prisoner.FullName,
                    Nickname = prisoner.Nickname,
                    Age = prisoner.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = isValidReleaseDate ? (DateTime?)releaseDate : null,
                    Bail = prisoner.Bail,
                    CellId = prisoner.CellId,
                    Mails = prisoner.Mails.Select(x => new Mail
                    {
                        Description = x.Description,
                        Sender = x.Sender,
                        Address = x.Address
                    })
                    .ToList()
                };

                context.Prisoners.Add(currentPrisoner);
                context.SaveChanges();

                sb.AppendLine($"Imported {currentPrisoner.FullName} {currentPrisoner.Age} years old");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(OfficerInputModel[]), new XmlRootAttribute("Officers"));

            var officersXml = serializer.Deserialize(new StringReader(xmlString)) as OfficerInputModel[];

            foreach (var officer in officersXml)
            {
                var isValidPosition = Enum.TryParse<Position>(officer.Position, out var position);
                var isValidWeapon = Enum.TryParse<Weapon>(officer.Weapon, out var weapon);

                if (!IsValid(officer) || !isValidPosition || !isValidWeapon)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currentOfficer = new Officer()
                {
                    FullName = officer.Name,
                    Salary = officer.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officer.DepartmentId,
                    OfficerPrisoners = officer.Prisoners.Select(p => new OfficerPrisoner
                    {
                        PrisonerId = p.Id
                    })
                    .ToArray()
                };

                context.Officers.Add(currentOfficer);
                context.SaveChanges();

                sb.AppendLine($"Imported {currentOfficer.FullName} ({currentOfficer.OfficerPrisoners.Count()} prisoners)");
            }
            return sb.ToString().TrimEnd();
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