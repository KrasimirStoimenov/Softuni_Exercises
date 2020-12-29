using System;
using System.Collections.Generic;
using System.IO;

class Solution
{
    static void Main(String[] args)
    {
        int i = 4;
        double d = 4.0;
        string s = "HackerRank ";


        int secondInteger = int.Parse(Console.ReadLine());
        double secondDouble = double.Parse(Console.ReadLine());
        string currentString = Console.ReadLine();

        Console.WriteLine(i + secondInteger);
        Console.WriteLine($"{d + secondDouble:F1}");
        Console.WriteLine(s + currentString);

    }
}