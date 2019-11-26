namespace SoftJail.DataProcessor
{

    using Data;
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
            var exportPrisoners = context
                 .Prisoners
                 .Where(p => ids.Contains(p.Id))
                 .Select(p => new
                 {
                     Id = p.Id,
                     Name = p.FullName,
                     CellNumber = p.Cell.CellNumber,
                     Officers = p.PrisonerOfficers.Select(po => new
                     {
                         OfficerName = po.Officer.FullName,
                         Department = po.Officer.Department.Name,



                     })
                     .OrderBy(o => o.OfficerName)
                     .ToArray(),
                     TotalOfficerSalary = p.PrisonerOfficers.Select(po => po.Officer.Salary).Sum()
                 })
                 .OrderBy(p => p.Name)
                 .OrderBy(p => p.Id)
                 .ToArray();


            var json = JsonConvert.SerializeObject(exportPrisoners, Formatting.Indented);

            return json;

        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var names = prisonersNames.Split(',');

            var prisonersToExport = context.
                Prisoners
                .Where(p => names.Contains(p.FullName))
                .Select(p => new ExportPrisonerDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = p.Mails
                    .Select(m => new MailDto
                    {
                        Description = ReverseString(m.Description)
                    }).ToArray()

                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportPrisonerDto[]),
                                new XmlRootAttribute("Prisoners"));


            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            serializer.Serialize(new StringWriter(sb), prisonersToExport, namespaces);


            return sb.ToString().TrimEnd();

        }

        private static string ReverseString(string text)
        {
            return string.Join("", text.Reverse());


        }

    }
}