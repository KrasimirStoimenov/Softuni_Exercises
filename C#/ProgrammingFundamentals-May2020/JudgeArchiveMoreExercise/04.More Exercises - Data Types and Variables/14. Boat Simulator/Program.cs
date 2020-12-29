using System;

namespace _14._Boat_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstBoat = char.Parse(Console.ReadLine());
            char secondBoat = char.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());
            int firstBoatMoves = 0;
            int secondBoatMoves = 0;

            for (int i = 1; i <= lines; i++)
            {
                string input = Console.ReadLine();
                if (input == "UPGRADE")
                {
                    firstBoat = (char)(firstBoat + 3);
                    secondBoat = (char)(secondBoat + 3);
                    continue;
                }
                if (i % 2 != 0)
                {
                    firstBoatMoves += input.Length;
                }
                else if (i % 2 == 0)
                {
                    secondBoatMoves += input.Length;
                }

                if (firstBoatMoves >= 50)
                {
                    Console.WriteLine(firstBoat);
                    return;
                }
                else if (secondBoatMoves >= 50)
                {
                    Console.WriteLine(secondBoat);
                    return;
                }
            }
            if (firstBoatMoves > secondBoatMoves)
            {
                Console.WriteLine(firstBoat);
            }
            else
            {
                Console.WriteLine(secondBoat);
            }
        }
    }
}
