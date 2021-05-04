using System;
using System.Collections.Generic;
using System.IO;

namespace _02.Active_Traders
{
    class Solution
    {
        public static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int customersCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> customers = new List<string>();

            for (int i = 0; i < customersCount; i++)
            {
                string customersItem = Console.ReadLine();
                customers.Add(customersItem);
            }

            List<string> result = Result.mostActive(customers);

            //textWriter.WriteLine(String.Join("\n", result));
            //
            //textWriter.Flush();
            //textWriter.Close();

            Console.WriteLine(string.Join("\n", result));
        }
    }

}
