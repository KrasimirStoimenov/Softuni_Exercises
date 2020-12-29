using System;

namespace _08._Employee_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	First name
            //•	Last name
            //•	Age(0...100)
            //•	Gender(m or f)
            //•	Personal ID number(e.g. 8306112507)
            //•	Unique employee number(27560000…27569999)

            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            byte age = byte.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            long idNumber = long.Parse(Console.ReadLine());
            uint employeeNumber = uint.Parse(Console.ReadLine());

            Console.WriteLine($"First name: {firstName}");
            Console.WriteLine($"Last name: {lastName}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Personal ID: {idNumber}");
            Console.WriteLine($"Unique Employee number: {employeeNumber}");

        }
    }
}

