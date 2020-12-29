using System;

namespace _01._Spring_Vacation_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysForTrip = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            double priceForFuel = double.Parse(Console.ReadLine());
            double foodExpensesForOnePersonForADay = double.Parse(Console.ReadLine());
            double priceForRoomForOneNightPerPerson = double.Parse(Console.ReadLine());

            double totalFoodExpenses = people * foodExpensesForOnePersonForADay * daysForTrip;
            double totalHotelExpenses = people * priceForRoomForOneNightPerPerson * daysForTrip;

            if (people > 10)
            {
                totalHotelExpenses *= 0.75;
            }
            double currentExpenses = totalFoodExpenses + totalHotelExpenses;

            for (int i = 1; i <= daysForTrip; i++)
            {
                double distance = double.Parse(Console.ReadLine());
                currentExpenses += distance * priceForFuel;

                if (i % 7 == 0)
                {
                    double withdrawMoney = currentExpenses / people;
                    currentExpenses -= withdrawMoney;
                }
                else if (i % 3 == 0)
                {
                    currentExpenses += currentExpenses * 0.40;
                }
                else if (i % 5 == 0)
                {
                    currentExpenses += currentExpenses * 0.40;
                }

                if (currentExpenses > budget)
                {
                    break;
                }
            }

            if (budget >= currentExpenses)
            {
                Console.WriteLine($"You have reached the destination. You have {budget - currentExpenses:F2}$ budget left.");
            }
            else
            {
                Console.WriteLine($"Not enough money to continue the trip. You need {currentExpenses - budget:F2}$ more.");
            }

        }
    }
}
