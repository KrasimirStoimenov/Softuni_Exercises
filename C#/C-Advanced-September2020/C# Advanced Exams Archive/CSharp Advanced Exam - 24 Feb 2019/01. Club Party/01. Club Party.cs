using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Hall> halls = new List<Hall>();

            int capacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Stack<string> stack = new Stack<string>(input);

            while (stack.Count > 0)
            {
                var argument = stack.Peek();
                int reservation;
                if (int.TryParse(argument, out reservation))
                {
                    if (halls.Count > 0)
                    {
                        Hall currentHall = halls[0];
                        if (reservation <= currentHall.Capacity)
                        {
                            currentHall.Capacity -= reservation;
                            currentHall.AddReservation(reservation);
                            stack.Pop();
                        }
                        else
                        {
                            Console.WriteLine($"{currentHall.Name} -> {string.Join(", ", currentHall.Reservations)}");
                            halls.Remove(currentHall);
                        }
                    }
                    else
                    {
                        stack.Pop();
                    }

                }
                else
                {
                    Hall hall = new Hall(argument, capacity);
                    halls.Add(hall);
                    stack.Pop();
                }
            }
        }
    }

}
