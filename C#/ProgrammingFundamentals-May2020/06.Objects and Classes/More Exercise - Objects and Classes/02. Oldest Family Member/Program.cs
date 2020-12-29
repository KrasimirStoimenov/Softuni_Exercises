using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Oldest_Family_Member
{
    class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            AddingFamilyMembers(family);
            Person oldestPerson = family.GetOldestMember(family);
            Console.WriteLine(oldestPerson.ToString());
        }

        static void AddingFamilyMembers(Family family)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] member = Console.ReadLine().Split();
                string name = member[0];
                int age = int.Parse(member[1]);

                Person currentPerson = new Person(name, age);
                family.AddMember(currentPerson);
            }
        }
    }
    //class Person
    //{
    //    public string Name { get; set; }

    //    public int Age { get; set; }

    //    public Person(string name, int age)
    //    {
    //        this.Name = name;
    //        this.Age = age;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{this.Name} {this.Age}";
    //    }
    //}
    //class Family
    //{
    //    public List<Person> familyMembers;

    //    public Family()
    //    {
    //        familyMembers = new List<Person>();
    //    }

    //    public Person GetOldestMember(Family family)
    //    {
    //        var sorted = familyMembers.OrderByDescending(x => x.Age).ToList();

    //        return sorted[0];
    //    }

    //    public void AddMember(Person currentPerson)
    //    {
    //        familyMembers.Add(currentPerson);
    //    }
    //}


}
