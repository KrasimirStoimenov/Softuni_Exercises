using System;
using System.Collections.Generic;

namespace _03._Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string key = Console.ReadLine();
                string synonuym = Console.ReadLine();

                if (dict.ContainsKey(key))
                {
                    dict[key].Add(synonuym);
                }
                else
                {
                    dict.Add(key, new List<string>());
                    dict[key].Add(synonuym);
                }

            }

            foreach (var el in dict)
            {
                Console.WriteLine($"{el.Key} - {string.Join(", ", el.Value)}");
            }
        }
    }
}
