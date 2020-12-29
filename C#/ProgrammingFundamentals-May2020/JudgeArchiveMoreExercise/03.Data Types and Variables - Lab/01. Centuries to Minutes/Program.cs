using System;

namespace _01._Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            uint centuri = uint.Parse(Console.ReadLine());
            ulong years = centuri * 100;
            decimal days = years * 365.2422m;
            ulong hours = (ulong)days * 24;
            ulong minutes = hours * 60;

            Console.WriteLine($"{centuri} centuries = {years} years = {(long)days} days = {hours} hours = {minutes} minutes");
        }
    }
}
