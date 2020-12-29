using System;

namespace _01._Hello__Name_
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintGreetings(Console.ReadLine());
        }
        static void PrintGreetings(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
