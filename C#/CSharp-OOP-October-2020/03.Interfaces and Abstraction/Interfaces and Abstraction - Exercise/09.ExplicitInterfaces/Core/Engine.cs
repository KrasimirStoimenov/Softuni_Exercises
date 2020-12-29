using System;

using _09.ExplicitInterfaces.Interfaces;
using _09.ExplicitInterfaces.Models;

namespace _09.ExplicitInterfaces.Core
{
    public class Engine : IEngine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string person;
            while ((person = Console.ReadLine()) != "End")
            {
                string[] personArgs = person.Split(" ");
                string name = personArgs[0];
                string country = personArgs[1];
                int age = int.Parse(personArgs[2]);

                IPerson currentPerson = new Citizen(name, age, country);
                IResident resident = new Citizen(name, age, country);

                Console.WriteLine(currentPerson.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
