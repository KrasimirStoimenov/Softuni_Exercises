using System;

namespace _03._Restaurant_Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();

            string hall = string.Empty;
            double price = 0;
            if (peopleCount > 120)
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }
            else if (peopleCount > 100)
            {
                hall = "Great Hall";
                price = 7500;
            }
            else if (peopleCount > 50)
            {
                hall = "Terrace";
                price = 5000;
            }
            else if (peopleCount >= 0)
            {
                hall = "Small Hall";
                price = 2500;
            }

            switch (package)
            {
                case "Normal":
                    price += 500;
                    price *= 0.95;
                    break;
                case "Gold":
                    price += 750;
                    price *= 0.90;
                    break;
                case "Platinum":
                    price += 1000;
                    price *= 0.85;
                    break;
            }

            double priceForPerson = price / peopleCount;
            Console.WriteLine($"We can offer you the {hall}");
            Console.WriteLine($"The price per person is {priceForPerson:F2}$");
        }
    }
}
