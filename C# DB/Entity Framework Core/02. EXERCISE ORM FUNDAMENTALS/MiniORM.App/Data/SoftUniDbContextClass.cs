﻿using System;
using System.Collections.Generic;
using System.Text;
using MiniORM.App.Data.Entities;

namespace MiniORM.App.Data
{
    public class SoftUniDbContextClass : DbContext
    {
        public SoftUniDbContextClass(string connectionString) 
            : base(connectionString)
        {
        }

        public DbSet<Employee> Employees { get; }
        
        public DbSet<Department> Departments { get; }

        public DbSet<Project> Projects { get; }

        public DbSet<EmployeesProject> EmployeesProjects { get; }
    }
}