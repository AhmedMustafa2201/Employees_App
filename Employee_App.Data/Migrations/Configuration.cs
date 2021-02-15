using System.Collections.Generic;
using Employee_App.Data.Domain;
using System;
using System.Data.Entity.Migrations;

namespace Employee_App.Data.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<Employee_APP.Data.ApplicationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Employee_APP.Data.ApplicationDBContext context)
        {
            #region Add Departmants
            var departments = new List<Departments>
            {
                new Departments
                {
                    Id = 1,
                    Name = "HR",
                    Description = "Human Resources",
                },
                new Departments
                {
                    Id = 2,
                    Name = "PR",
                    Description = "Public Relationships",
                },
                new Departments
                {
                    Id = 3,
                    Name = "Accounting",
                    Description = "description 1",
                },
                new Departments
                {
                    Id = 4,
                    Name = "Marketing",
                    Description = "description 2",
                },
            };

            foreach (var department in departments)
                context.Departments.AddOrUpdate(a => a.Id, department);

            #endregion

            #region add Clients
            var clients = new List<Clients>
            {
                new Clients {Id = 1, Email = "demo@client.com", CreatedAt = DateTime.Now, Phone = "0987654321", EmployeeID = 2, Name = "Abudallah Ali"},
                new Clients {Id = 2, Email = "demo@client.com", CreatedAt = DateTime.Now, Phone = "0987654321", EmployeeID = 4, Name = "Osama Mohammed"},
                new Clients {Id = 3, Email = "demo@client.com", CreatedAt = DateTime.Now, Phone = "0987654321", EmployeeID = 3, Name = "Ali Gaber"},
                new Clients {Id = 4, Email = "demo@client.com", CreatedAt = DateTime.Now, Phone = "0987654321", EmployeeID = 3, Name = "Kareem Sadek"},
                new Clients {Id = 5, Email = "demo@client.com", CreatedAt = DateTime.Now, Phone = "0987654321", EmployeeID = 2, Name = "Abdulrahman Amer"},
            };

            foreach (var client in clients)
                context.Clients.AddOrUpdate(a => a.Id, client);

            #endregion

            #region Add Employees
            var employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Full_Name = "Ahmed Mustafa",
                    Address = "Main St.",
                    Email = "demo@john.com",
                    Phone = "1234567890",
                    Salary = 4000,
                    CreatedAt = DateTime.Now,
                    DepartmentId = 3,
                },
                new Employee
                {
                    Id = 2,
                    Full_Name = "Mohammed Ali",
                    Address = "Main St.",
                    Email = "demo@john.com",
                    Phone = "1234567890",
                    Salary = 4000,
                    CreatedAt = DateTime.Now,
                    DepartmentId = 2,
                },
                new Employee
                {
                    Id = 3,
                    Full_Name = "Ali Essa",
                    Address = "Main St.",
                    Email = "demo@john.com",
                    Phone = "1234567890",
                    Salary = 4030,
                    CreatedAt = DateTime.Now,
                    DepartmentId = 3,
                },
                new Employee
                {
                    Id = 4,
                    Full_Name = "Abdulrahman Auf",
                    Address = "Main St.",
                    Email = "demo@john.com",
                    Phone = "1234567890",
                    Salary = 2000,
                    CreatedAt = DateTime.Now,
                    DepartmentId = 1,
                },
            };
            foreach (var employee in employees)
                context.Employee.AddOrUpdate(a => a.Id, employee);
            #endregion

        }
    }
}
