namespace SoftJail.DataProcessor
{

    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Include(x => x.Cell)
                .Include(x => x.PrisonerOfficers)
                .ThenInclude(c => c.Officer)
                .ToArray()
                .Select(x => new ExportPrisonerByCellDto
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(o => new ExportOfficerDto
                    {
                        Department = o.Officer.Department.Name,
                        OfficerName = o.Officer.FullName
                    })
                    .OrderBy(n => n.OfficerName)
                    .ToArray(),
                    TotalOfficerSalary = x.PrisonerOfficers.Sum(o => o.Officer.Salary)
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            var serializer = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return serializer.ToString().TrimEnd();
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var namesOfPrisoners = prisonersNames.Split(",").ToArray();

            var prisoners = context.Prisoners
                .Where(p => namesOfPrisoners.Contains(p.FullName))
                .Select(x => new ExportPrisonerMailsDto
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd"),
                    Messages = x.Mails.Select(m => new ExportMailsDto
                    {
                        Description = Reverse(m.Description)
                    })
                    .ToArray()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var xmlSerializer = new XmlSerializer(typeof(ExportPrisonerMailsDto[]), new XmlRootAttribute("Prisoners"));

            xmlSerializer.Serialize(new StringWriter(sb), prisoners, namespaces);
            
            return sb.ToString().TrimEnd();
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}