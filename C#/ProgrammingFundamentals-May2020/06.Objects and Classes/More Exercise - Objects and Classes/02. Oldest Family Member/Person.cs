using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Oldest_Family_Member
{
    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
