using System;

namespace _01._Easter_Cozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            // for one cozonac - 1 pack eggs \ 1 kg floor \0.25l Milk
            double budget = double.Parse(Console.ReadLine());
            double priceForKgFloor = double.Parse(Console.ReadLine());

            double priceForPackEggs = priceForKgFloor * 0.75;
            double priceForLiterMilk = priceForKgFloor * 1.25;
            double priceMilkForOneCozonac = priceForLiterMilk * 0.25;

            double oneCozonacPrice = priceForKgFloor + priceForPackEggs + priceMilkForOneCozonac;
            int coloredEggs = 0;
            int counter = 0;
            while (budget > oneCozonacPrice)
            {
                budget -= oneCozonacPrice;
                counter++;
                coloredEggs += 3;
                if (counter % 3 == 0)
                {
                    coloredEggs -= counter - 2;
                }
            }

            Console.WriteLine($"You made {counter} cozonacs! Now you have {coloredEggs} eggs and {budget:F2}BGN left.");

        }
    }
}
