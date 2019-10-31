using System;
using System.Linq;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            string result = DeleteProjectById(context);

            Console.WriteLine(result);
        }

        //03. Employees Full Information//
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    Id = e.EmployeeId,
                    Name = String.Join(" ", e.FirstName, e.LastName, e.MiddleName),
                    e.JobTitle,
                    e.Salary
                });

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.Name} {e.JobTitle} {e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //04. Employees with Salary Over 50 000//

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    firstName = e.FirstName,
                    salary = e.Salary

                }).Where(s => s.salary > 50000);

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.firstName} - {e.salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //05. Employees from Research and Development//

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(d => d.Department.Name == "Research and Development ")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    departmentName = e.Department.Name,
                    e.Salary,

                });

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.departmentName} - ${e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //06. Adding a New Address and Updating Employee//

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee nakov = context
                .Employees
                .First(e => e.LastName == "Nakov");

            nakov.Address = address;

            context.SaveChanges();

            var addressTexts = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => new
                {
                    e.Address.AddressText
                })
                .Take(10)
                .ToList();

            foreach (var at in addressTexts)
            {
                sb.AppendLine(at.AddressText);
            }

            return sb.ToString().TrimEnd();
        }

        //07. Employees and Projects//

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee = context
                .Employees.Where(e => e.EmployeesProjects.Any(p => p.Project.StartDate.Year > 2000 && p.Project.StartDate.Year < 2004))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    managerFirstName = e.Manager.FirstName,
                    managerLastName = e.Manager.LastName,
                    project = e.EmployeesProjects.Select(p => new
                    {
                        p.Project.Name,
                        p.Project.StartDate,
                        p.Project.EndDate
                    })


                })
                .Take(10);



            foreach (var e in employee)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.managerFirstName} {e.managerLastName}");



                foreach (var p in e.project)
                {
                    if (p.EndDate != null)
                    {
                        sb.AppendLine($"--{p.Name} - {p.StartDate} - {p.EndDate}");
                    }
                    else
                    {
                        sb.AppendLine($"--{p.Name} - {p.StartDate} - not finished");
                    }

                }

            }


            return sb.ToString().TrimEnd();


        }

        //08. Addresses by Town//

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context
                .Addresses
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count

                })
                .OrderByDescending(e => e.EmployeesCount)
                .ThenBy(e => e.TownName)
                .ThenBy(e => e.AddressText)
                .Take(10)
                .ToList();


            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //09. Employee 147//

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    projectsName = e.EmployeesProjects.Select(p => p.Project.Name)

                })
                .ToList();

            var projects = context
                .EmployeesProjects
                .Where(p => p.EmployeeId == 147)
                .OrderBy(p => p.Project.Name)
                .Select(p => p.Project.Name)
                .ToList();



            foreach (var e in employee)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

                foreach (var item in projects)
                {
                    sb.AppendLine($"{item}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //10. Departments with More Than 5 Employees//

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context
                .Departments
                .Where(e => e.Employees.Count() > 5)
                .OrderBy(e => e.Employees.Count())
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    managerFirstName = d.Manager.FirstName,
                    managerLastName = d.Manager.LastName,
                    employees = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle

                    })
                   .OrderBy(e => e.FirstName)
                   .ThenBy(e => e.LastName)

                });

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.managerFirstName} {d.managerLastName}");

                foreach (var e in d.employees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }




            return sb.ToString().TrimEnd();
        }

        //11. Find Latest 10 Projects//

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderBy(p => p.Name);

            foreach (var p in projects)
            {
                sb.AppendLine($"{p.Name}");
                sb.AppendLine($"{p.Description}");
                sb.AppendLine($"{p.StartDate}");
            }


            return sb.ToString().TrimEnd();


        }


        //12. Increase Salaries//

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Engineering"
                || e.Department.Name == "Tool Design"
                || e.Department.Name == "Marketing"
                || e.Department.Name == "Information Services");

            foreach (var e in employees)
            {
                e.Salary *= 1.12m;
            }

            context.SaveChanges();


            var employeesToPrint = employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            foreach (var e in employeesToPrint)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }
        //13. Find Employees by First Name Starting With Sa//

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //14. Delete Project by Id//

        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context
                .Projects.Find(2);


            var employeesProject = context
                .EmployeesProjects.Where(p => p.ProjectId == 2).ToList();

            foreach (var item in employeesProject)
            {
                context.EmployeesProjects.Remove(item);
            }

            context.Projects.Remove(project);

            context.SaveChanges();

            var projectsToPrint = context
                .Projects
                .Select(p => p.Name)
                .ToList();

            return string.Join(Environment.NewLine,projectsToPrint);

        }


        //15. Remove Town//

        public static string RemoveTown(SoftUniContext context)
        {
            var seattle = context
                .Towns
                .First(t => t.Name == "Seattle");

            var addressesInTown = context
                .Addresses
                .Where(a => a.Town.Name == "Seattle");


            var employeesToRemoveAddress = context
                .Employees
                .Where(e => addressesInTown.Contains(e.Address));

            foreach (var e in employeesToRemoveAddress)
            {
                e.AddressId = null;
            }

            foreach (var a in addressesInTown)
            {
                context.Addresses.Remove(a);
            }

            int addressesCount = addressesInTown.Count();

            context.Towns.Remove(seattle);

            context.SaveChanges();

            return $"{addressesCount} addresses in Seattle were deleted";
        }




    }
}
