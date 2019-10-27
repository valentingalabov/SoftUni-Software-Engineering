using MiniORM.App.Data;
using System;
using System.Linq;

namespace MiniORM.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var connectionString = "Server = VALIO\\SQLEXPRESS;" +
        "Database = MiniORM;" +
        "Integrated Security = true";

            var context = new SoftUniDbContextClass(connectionString);

            context.Employees.Add(new Data.Entities.Employee
            { 
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed= true
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";
            context.SaveChanges();
        }
    }
}
