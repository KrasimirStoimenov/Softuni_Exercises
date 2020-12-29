using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string peopleType = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;

            switch (day)
            {
                case "Friday":
                    if (peopleType == "Students")
                    {
                        price = 8.45;
                    }
                    else if (peopleType == "Business")
                    {
                        price = 10.90;
                    }
                    else if (peopleType == "Regular")
                    {
                        price = 15;
                    }
                    break;
                case "Saturday":
                    if (peopleType == "Students")
                    {
                        price = 9.80;
                    }
                    else if (peopleType == "Business")
                    {
                        price = 15.60;
                    }
                    else if (peopleType == "Regular")
                    {
                        price = 20;
                    }
                    break;
                case "Sunday":
                    if (peopleType == "Students")
                    {
                        price = 10.46;
                    }
                    else if (peopleType == "Business")
                    {
                        price = 16;
                    }
                    else if (peopleType == "Regular")
                    {
                        price = 22.50;
                    }
                    break;

            }
            double totalPrice = 0;
            if (peopleType == "Students" && people >= 30)
            {
                totalPrice = (people * price) * 0.85;
            }
            else if (peopleType == "Business" && people >= 100)
            {
                people -= 10;
                totalPrice = people * price;
            }
            else if (peopleType == "Regular" && (people >= 10 && people <= 20))
            {
                totalPrice = (people * price) * 0.95;
            }
            else
            {
                totalPrice = people * price;
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
