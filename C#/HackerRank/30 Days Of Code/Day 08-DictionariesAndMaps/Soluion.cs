using System;
using System.Collections.Generic;
using System.IO;

class Solution
{
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */

        var phoneBook = new Dictionary<string, string>();
        int entries = int.Parse(Console.ReadLine());

        for (int i = 0; i < entries; i++)
        {
            string[] cmdArgs = Console.ReadLine().Split();
            string name = cmdArgs[0];
            string number = cmdArgs[1];

            phoneBook.Add(name, number);
        }

        while (true)
        {
            string nameToRead = Console.ReadLine();
            if (nameToRead == null)
            {
                break;
            }

            if (phoneBook.ContainsKey(nameToRead))
            {
                Console.WriteLine($"{nameToRead}={phoneBook[nameToRead]}");
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }


    }
}