using MiniORM.App.Data;
using MiniORM.App.Data.Entities;
using System;
using System.Linq;

namespace MiniORM.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=.; Database=MiniORM; Integrated Security = true;";

            var db = new SoftUniDbContext(connectionString);

            db.Employees.Add(new Employee
            {
                FirstName = "xXx",
                LastName = "Inserted",
                DepartmentId = db.Departments.First().Id,
                IsEmployed = true,
            });

            var employee = db.Employees.Last();

            employee.FirstName = "Modified";

            db.SaveChanges();
        }
    }
}
