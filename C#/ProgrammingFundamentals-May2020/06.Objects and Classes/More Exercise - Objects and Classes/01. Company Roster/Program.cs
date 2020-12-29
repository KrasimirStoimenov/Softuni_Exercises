using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Company_Roster
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = new List<Employee>();
            Dictionary<string, decimal> dict = new Dictionary<string, decimal>();

            Proccessing(employeeList, dict);
            PrintOutput(employeeList, dict);

        }

        static void PrintOutput(List<Employee> employeeList, Dictionary<string, decimal> dict)
        {
            var sortedDict = dict.OrderByDescending(x => x.Value).ToDictionary(k => k.Key, v => v.Value);
            var firstElement = sortedDict.ElementAt(0);

            Console.WriteLine($"Highest Average Salary: {firstElement.Key}");

            var empListInThatDepartment = employeeList.Where(x => x.Department == firstElement.Key)
                .OrderByDescending(m => m.Salary)
                .ToList();

            foreach (var emp in empListInThatDepartment)
            {
                Console.WriteLine($"{emp.Name} {emp.Salary:F2}");
            }
        }

        static void Proccessing(List<Employee> empList, Dictionary<string, decimal> dict)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string name = cmdArgs[0];
                decimal salary = decimal.Parse(cmdArgs[1]);
                string department = cmdArgs[2];

                Employee emp = new Employee(name, salary, department);
                empList.Add(emp);

                if (dict.ContainsKey(department))
                {
                    dict[department] += salary;
                }
                else
                {
                    dict.Add(department, salary);
                }
            }
        }
    }

    //class Employee
    //{
    //    public string Name { get; set; }

    //    public decimal Salary { get; set; }

    //    public string Department { get; set; }

    //    public Employee(string name, decimal salary, string department)
    //    {
    //        this.Name = name;
    //        this.Salary = salary;
    //        this.Department = department;
    //    }

    //}
}
