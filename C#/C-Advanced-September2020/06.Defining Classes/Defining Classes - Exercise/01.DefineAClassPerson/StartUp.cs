using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person()
            {
                Name = "Pesho",
                Age = 20
            };

            Person secondPerson = new Person();
            secondPerson.Name = "Gosho";
            secondPerson.Age = 18;

            

            Console.WriteLine(firstPerson.Name);
            Console.WriteLine(firstPerson.Age);
            Console.WriteLine(secondPerson.Name);
            Console.WriteLine(secondPerson.Age);
        }
    }
}
