namespace SoftJail.DataProcessor
{

    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Linq;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Include(x=>x.Cell)
                .Include(x=>x.PrisonerOfficers)
                .ThenInclude(c=>c.Officer)
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

            var serializer = JsonConvert.SerializeObject(prisoners,Formatting.Indented);

            return serializer.ToString().TrimEnd();
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            throw new NotImplementedException();
        }
    }
}