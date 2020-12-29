using System;

namespace _01._Biscuits_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerWorker = int.Parse(Console.ReadLine());
            int workersInFactory = int.Parse(Console.ReadLine());
            int otherFactoryProduce = int.Parse(Console.ReadLine());

            int biscuitsForAMonth = 0;
            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 == 0)
                {
                    biscuitsForAMonth += (int)((workersInFactory * biscuitsPerWorker) * 0.75);
                }
                else
                {
                    biscuitsForAMonth += workersInFactory * biscuitsPerWorker;
                }
            }

            Console.WriteLine($"You have produced {biscuitsForAMonth} biscuits for the past month.");

            double difference = Math.Abs(biscuitsForAMonth - otherFactoryProduce);

            if (biscuitsForAMonth > otherFactoryProduce)
            {
                double percentage = difference / otherFactoryProduce * 100;
                Console.WriteLine($"You produce {percentage:F2} percent more biscuits.");
            }
            else
            {
                double percentage = difference / otherFactoryProduce * 100;
                Console.WriteLine($"You produce {percentage:F2} percent less biscuits.");
            }
        }
    }
}
