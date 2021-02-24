using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //1.Import the SoftUni Database - Done
            //2.Database First - Done

            var db = new SoftUniContext();

            //3.Employees Full Information
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(GetEmployeesFullInformation(db));

            //4.Employees with Salary Over 50 000
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(GetEmployeesWithSalaryOver50000(db));

            //5.Employees from Research and Development
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(GetEmployeesFromResearchAndDevelopment(db));

            //6.Adding a New Address and Updating Employee
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(AddNewAddressToEmployee(db));

            //7.Employees and Projects
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(GetEmployeesInPeriod(db));
        }
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.EmployeesProjects.Any(x => x.Project.StartDate.Year >= 2001 && x.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmployeeFirstName = e.FirstName,
                    EmployeeLastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        ProjectStartDate = p.Project.StartDate,
                        ProjectEndDate = p.Project.EndDate,
                    }),
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.EmployeeFirstName} {emp.EmployeeLastName} - Manager: {emp.ManagerFirstName} {emp.ManagerLastName}");

                foreach (var project in emp.Projects)
                {
                    var projectStartDate = string.Format($"{project.ProjectStartDate}", "M/d/yyyy h:mm:ss tt");
                    var projectEndDate = string.Empty;

                    if (project.ProjectEndDate == null)
                    {
                        projectEndDate = "not finished";
                    }
                    else
                    {
                        projectEndDate = string.Format($"{project.ProjectEndDate}", "M/d/yyyy h:mm:ss tt");
                    }

                    sb.AppendLine($"--{project.ProjectName} - {projectStartDate} - {projectEndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
            };
            context.Addresses.Add(newAddress);

            var employeeNakov = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            employeeNakov.Address = newAddress;

            context.SaveChanges();

            var addresses = context.Addresses
                .Select(x => new
                {
                    x.AddressId,
                    x.AddressText,
                })
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine(address.AddressText);
            }

            return sb.ToString().TrimEnd();


        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary,
                })
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from {emp.DepartmentName} - ${emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var emplyees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary,
                })
                .OrderBy(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in emplyees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.MiddleName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary,
                })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
