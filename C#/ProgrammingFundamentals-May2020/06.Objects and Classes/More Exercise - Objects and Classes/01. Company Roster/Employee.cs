using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Company_Roster
{
    class Employee
    {
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Department { get; set; }

        public Employee(string name, decimal salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }

    }
}
