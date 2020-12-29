using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = new List<string>();

            Proccessing(guests);
            Console.WriteLine(string.Join("\n", guests));
        }

        static void Proccessing(List<string> guests)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] command = Console.ReadLine().Split();

                FillGuestList(guests, command[0], command.Length);
            }


        }
        static void FillGuestList(List<string> guests, string name, int length)
        {
            if (length == 3) // name is Going
            {
                if (guests.Contains(name))
                {
                    Console.WriteLine($"{name} is already in the list!");
                }
                else
                {
                    guests.Add(name);
                }
            }
            else if (length == 4)
            {
                if (guests.Contains(name))
                {
                    guests.Remove(name);
                }
                else
                {
                    Console.WriteLine($"{name} is not in the list!");
                }
            }
        }
    }
}
