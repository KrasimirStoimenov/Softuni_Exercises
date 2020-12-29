using System;
using System.Collections.Generic;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pointCount = int.Parse(Console.ReadLine());
            Queue<string> stops = new Queue<string>();
            AddPointsInQueue(stops, pointCount);
            int pointCounter = 0;
            while (true)
            {
                bool hasCompleteCircle = true;
                int currentPetrol = 0;

                for (int i = 0; i < pointCount; i++)
                {
                    string currentPoint = stops.Dequeue();
                    string[] pointArgs = currentPoint.Split(" ");
                    int petrol = int.Parse(pointArgs[0]);
                    int distance = int.Parse(pointArgs[1]);

                    currentPetrol += petrol;
                    currentPetrol -= distance;
                    if (currentPetrol < 0)
                    {
                        hasCompleteCircle = false;
                    }
                    stops.Enqueue(currentPoint);
                }

                if (hasCompleteCircle)
                {
                    Console.WriteLine(pointCounter);
                    break;
                }

                stops.Enqueue(stops.Dequeue());
                pointCounter++;
            }
        }

        static void AddPointsInQueue(Queue<string> stops, int pointCount)
        {
            for (int i = 0; i < pointCount; i++)
            {
                string point = Console.ReadLine();
                stops.Enqueue(point);
            }
        }
    }
}
