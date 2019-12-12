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
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {



            var projects = context.Projects
                .Where(p => p.Tasks.Any())

                .Select(p => new ExportProjectDto
                {

                    TasksCount = p.Tasks.Count(),
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    Tasks = p.Tasks.Select(t => new ExportTaskDto
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString(),


                    })
                    .OrderBy(t => t.Name)
                    .ToArray()


                })
                .OrderByDescending(t => t.TasksCount)
                .ThenBy(p => p.ProjectName)


                .ToArray();




            var serializer = new XmlSerializer(typeof(ExportProjectDto[]),
                                new XmlRootAttribute("Projects"));




            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            serializer.Serialize(new StringWriter(sb), projects, namespaces);



            return sb.ToString().TrimEnd();


        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                  .Where(emp => emp.EmployeesTasks.Any(e => e.Task.OpenDate >= date))
                  .OrderByDescending(emp => emp.EmployeesTasks.Where(et => et.Task.OpenDate >= date).Count())
                  .ThenBy(emp => emp.Username)
                  .Select(emp => new
                  {
                      emp.Username,
                      Tasks = emp.EmployeesTasks
                                  .Select(e => e.Task)
                                  .Where(e => e.OpenDate >= date)
                                      .OrderByDescending(t => t.DueDate)
                                      .ThenBy(t => t.Name)
                                      .Select(t => new
                                      {
                                          TaskName = t.Name,
                                          OpenDate = t.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                          DueDate = t.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                          LabelType = t.LabelType.ToString(),
                                          ExecutionType = t.ExecutionType.ToString()
                                      })
                  })
                  .Take(10)
                  .ToList();









            var json = JsonConvert.SerializeObject(employees, Formatting.Indented);
            return json;
        }
    }
}