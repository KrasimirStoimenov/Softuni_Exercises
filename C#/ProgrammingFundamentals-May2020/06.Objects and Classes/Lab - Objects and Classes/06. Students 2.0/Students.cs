using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Students_2._0
{
    class Students
    {
        public Students(string first, string last, int age, string home)
        {
            this.FirstName = first;
            this.LastName = last;
            this.Age = age;
            this.Hometown = home;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }
    }
}
