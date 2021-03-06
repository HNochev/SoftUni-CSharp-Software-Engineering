namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.Linq;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners.ToList()
                .Where(x => ids.Contains(x.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(y => new
                    {
                        OfficerName = y.Officer.FullName,
                        Department = y.Officer.Department.Name,
                    })
                    .OrderBy(y => y.OfficerName)
                    .ToList(),
                    TotalOfficerSalary = decimal.Parse(x.PrisonerOfficers.Sum(y => y.Officer.Salary).ToString("f2")),
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToList();

            var result = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return result;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisoners = context.Prisoners.ToList()
                .Where(x => prisonersNames.Contains(x.FullName))
                .Select(x => new PrisonerXmlOutputModel
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Messages = x.Mails.Select(y => new MessageXmlOutputModel
                    {
                        Description = string.Join("", y.Description.ToCharArray().Reverse()),
                })
                    .ToArray(),
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

        var result = XmlConverter.Serialize(prisoners, "Prisoners");

            return result;
        }
}
}