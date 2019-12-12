namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using System.Xml.Serialization;
    using System.Text;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportProjectDto[]),
                             new XmlRootAttribute("Projects"));
            var allProjects = (ImportProjectDto[])serializer.Deserialize(new StringReader(xmlString));
            var validProjects = new List<Project>();
            var sb = new StringBuilder();



            foreach (var projectDto in allProjects)
            {
                var tryOpenDate = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime openDate);
                //var tryDueDate = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dueDate);


                //var try = DateTime.TryParse(projectDto.OpenDate, "")
                //var projectOpenDate = DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //var projectDueDate = DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);




                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;

                }


                var project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = openDate,
                    
                };

                if (projectDto.DueDate == null || projectDto.DueDate == "")
                {
                    project.DueDate = null;
                }
                else
                {
                    project.DueDate = DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }



                foreach (var task in projectDto.Tasks)
                {



                    var validTaskOpenDate = DateTime.TryParseExact(task.OpenDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDate);
                    var validTaskDueDate = DateTime.TryParseExact(task.DueDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate);

                    var tryExecution = Enum.TryParse<ExecutionType>(task.ExecutionType, out ExecutionType resultExecutionType);
                    var tryLabel = Enum.TryParse<LabelType>(task.LabelType, out LabelType resultEnumType);

                    DateTime? projectDueDate = project.DueDate;


                    if (!IsValid(task) || !tryExecution || !tryLabel)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }


                    if (projectDueDate != null)
                    {
                        if (taskOpenDate < openDate || taskDueDate > projectDueDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                    }
                    else
                    {
                        if (taskOpenDate < openDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                    }






                    var taskToAdd = new Task
                    {
                        Name = task.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = resultExecutionType,
                        LabelType = resultEnumType

                    };

                    project.Tasks.Add(taskToAdd);

                }


                validProjects.Add(project);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));

            }


            context.Projects.AddRange(validProjects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var allEmployees = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);
            var validEmployees = new List<Employee>();
            var sb = new StringBuilder();
            var addedTask = new List<Task>();

            foreach (var employeeDto in allEmployees)
            {

                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,


                };


                foreach (var task in employeeDto.Tasks)
                {

                    var findTask = context.Tasks.FirstOrDefault(t => t.Id == task);

                    if (findTask == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (addedTask.Contains(findTask))
                    {
                        continue;
                    }

                    var employeeTask = new EmployeeTask
                    {
                        Employee = employee,
                        Task = findTask

                    };

                    addedTask.Add(findTask);
                    employee.EmployeesTasks.Add(employeeTask);


                }
                validEmployees.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(validEmployees);
            context.SaveChanges();


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