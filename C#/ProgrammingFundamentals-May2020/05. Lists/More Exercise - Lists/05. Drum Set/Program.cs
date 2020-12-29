namespace _05._Drum_Set
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());

            List<int> drumSet = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> drumSetPrice = new List<int>();
            drumSetPrice = GetDrumSetPrice(drumSetPrice, drumSet);

            Proccessing(savings, drumSet, drumSetPrice);

        }

        static void Proccessing(double savings, List<int> drumSet, List<int> drumSetPrice)
        {
            List<int> keepDrumSet = drumSet.GetRange(0, drumSet.Count);
            string command;
            while ((command = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(command);

                for (int i = 0; i < drumSet.Count; i++)      //Get Hit All Elements
                {
                    drumSet[i] -= hitPower;
                    if (drumSet[i] <= 0)             //Broke Drum;
                    {
                        if (savings >= drumSetPrice[i])
                        {
                            savings -= drumSetPrice[i];
                            drumSet[i] = keepDrumSet[i];
                        }
                        else
                        {
                            drumSet.RemoveAt(i);
                            keepDrumSet.RemoveAt(i);
                            drumSetPrice.RemoveAt(i);
                            i--;

                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {savings:F2}lv.");

        }

        static List<int> GetDrumSetPrice(List<int> drumSetPrice, List<int> drumSet)
        {
            for (int i = 0; i < drumSet.Count; i++)
            {
                int currentDrumPrice = drumSet[i] * 3;
                drumSetPrice.Add(currentDrumPrice);
            }
            return drumSetPrice;
        }
    }
}
