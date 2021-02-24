using SoftUni.Data;
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
            Console.WriteLine(new string('-',20));
            Console.WriteLine(GetEmployeesFullInformation(db));

            //4.Employees with Salary Over 50 000
            Console.WriteLine(new string('-',20));
            Console.WriteLine(GetEmployeesWithSalaryOver50000(db));

            //5.Employees from Research and Development
            Console.WriteLine(new string('-',20));
            Console.WriteLine(GetEmployeesFromResearchAndDevelopment(db));


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
