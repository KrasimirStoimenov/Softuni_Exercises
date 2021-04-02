namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SoftJail.DataProcessor.ExportDto;
    using System.Xml.Serialization;
    using System.Text;
    using System.IO;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(x => ids.Contains(x.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(o => new
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name
                    })
                    .OrderBy(x => x.OfficerName)
                    .ToList(),

                    TotalOfficerSalary = decimal.Parse(x.PrisonerOfficers.Sum(s => s.Officer.Salary).ToString("F2"))
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToList();

            return JsonConvert.SerializeObject(prisoners, Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var sb = new StringBuilder();

            var chosenPrisoners = prisonersNames.Split(",").ToArray();

            var prisoners = context.Prisoners
                .Where(x => chosenPrisoners.Contains(x.FullName))
                .Select(x => new PrisonerExportModel
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = x.Mails.Select(m => new MessagesExportModel
                    {
                        Description = string.Join("", m.Description.Reverse())
                    })
                    .ToArray()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            var serializer = new XmlSerializer(typeof(PrisonerExportModel[]), new XmlRootAttribute("Prisoners"));

            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            serializer.Serialize(new StringWriter(sb), prisoners, ns);

            return sb.ToString().TrimEnd();
        }
    }
}