using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
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

            ////3.Employees Full Information
            //Console.WriteLine(new string('-', 20));
            //Console.WriteLine(GetEmployeesFullInformation(db));

            ////4.Employees with Salary Over 50 000
            //Console.WriteLine(new string('-', 20));
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(db));

            ////5.Employees from Research and Development
            //Console.WriteLine(new string('-', 20));
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(db));

            ////6.Adding a New Address and Updating Employee
            //Console.WriteLine(new string('-', 20));
            //Console.WriteLine(AddNewAddressToEmployee(db));

            ////7.Employees and Projects
            //Console.WriteLine(new string('-', 20));
            //Console.WriteLine(GetEmployeesInPeriod(db));

            ////8.Addresses by Town
            //Console.WriteLine(new string('-', 20));
            //Console.WriteLine(GetAddressesByTown(db));

            ////9.Employee 147
            //Console.WriteLine(new string('-', 20));
            //Console.WriteLine(GetEmployee147(db));

            ////10.Departments with More Than 5 Employees
            //Console.WriteLine(new string('-', 20));
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(db));

            ////11.Find Latest 10 Projects
            //Console.WriteLine(new string('-', 20));
            //Console.WriteLine(GetLatestProjects(db));

            ////12.Increase Salaries
            //Console.WriteLine(new string('-', 20));
            //Console.WriteLine(IncreaseSalaries(db));

            ////13.Find Employees by First Name Starting with "Sa"
            //Console.WriteLine(new string('-', 20));
            //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(db));

            //14.Delete Project by Id
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(DeleteProjectById(db));
        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectToDelete = context.Projects
                .Where(p => p.ProjectId == 2)
                .FirstOrDefault();
            var employeeProjects = context.EmployeesProjects
                .Include(e => e.Employee)
                .Where(p => p.ProjectId == 2)
                .ToList();

            foreach (var empProject in employeeProjects)
            {
                empProject.Project = null;
                context.EmployeesProjects.Remove(empProject);
            }
            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var departments = new List<string>()
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };

            var employees = context.Employees
                .Where(d => departments.Contains(d.Department.Name))
                .ToList();

            foreach (var emp in employees)
            {
                emp.Salary *= 1.12M;
            }

            context.SaveChanges();

            var sb = new StringBuilder();

            var orderedEmployees = employees
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);


            foreach (var emp in orderedEmployees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            var lastProjects = context.Projects
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate,
                })
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .OrderBy(x => x.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var project in lastProjects)
            {
                sb.AppendLine($"{project.Name}")
                    .AppendLine($"{project.Description}");

                var formattedDate = string.Format($"{project.StartDate }", "M/d/yyyy h:mm:ss tt");
                sb.AppendLine(formattedDate);
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Include(e => e.Employees)
                .Where(de => de.Employees.Count() > 5)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    EmployeesInDepartment = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenByDescending(e => e.LastName)
                    .ToList()
                })
                .OrderBy(d => d.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.ManagerFirstName}  {department.ManagerLastName}");

                foreach (var emp in department.EmployeesInDepartment)
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Projects = x.EmployeesProjects.Select(p => new
                    {
                        p.Project.Name
                    })
                    .OrderBy(p => p.Name)
                    .ToList()
                })
                .FirstOrDefault();

            var sb = new StringBuilder();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var project in employee147.Projects)
            {
                sb.AppendLine($"{project.Name}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(x => new
                {
                    TownName = x.Town.Name,
                    AddressText = x.AddressText,
                    EmployeesCount = x.Employees.Count,
                })
                .OrderByDescending(x => x.EmployeesCount)
                .ThenBy(x => x.TownName)
                .ThenBy(x => x.AddressText)
                .ToList();

            var sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();

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
