using System;
using System.Collections.Generic;

using _05.BirthdayCelebrations.Models;
using _05.BirthdayCelebrations.Interfaces;

namespace _05.BirthdayCelebrations.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<IBirthable> birthdays;
        public Engine()
        {
            this.birthdays = new List<IBirthable>();
        }
        public void Run()
        {
            Processing();
            string yearOfBirthdaysToPrint = Console.ReadLine();
            PrintOutput(yearOfBirthdaysToPrint, birthdays);
        }

        private void PrintOutput(string yearOfBirthdaysToPrint, ICollection<IBirthable> birthdays)
        {
            foreach (var birthday in birthdays)
            {
                if (birthday.Birthdate.EndsWith(yearOfBirthdaysToPrint))
                {
                    Console.WriteLine(birthday.Birthdate);
                }
            }
        }

        private void Processing()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(" ");
                string type = cmdArgs[0];
                string name = cmdArgs[1];
                switch (type)
                {
                    case "Citizen":
                        AddCitizenBirthday(cmdArgs, name);
                        break;
                    case "Robot":
                        break;
                    case "Pet":
                        AddPetBirthday(cmdArgs, name);
                        break;
                }
            }
        }

        private void AddPetBirthday(string[] cmdArgs, string name)
        {
            string petBirthdate = cmdArgs[2];
            IBirthable petBirthday = new Pet(name, petBirthdate);
            birthdays.Add(petBirthday);
        }

        private void AddCitizenBirthday(string[] cmdArgs, string name)
        {
            int age = int.Parse(cmdArgs[2]);
            string id = cmdArgs[3];
            string birthdate = cmdArgs[4];
            IBirthable birthday = new Citizen(name, age, id, birthdate);
            birthdays.Add(birthday);
        }
    }
}
