using System;
using System.Collections.Generic;
using System.IO;

namespace _01.Road_Repair
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int crew_idCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> crew_id = new List<int>();

            for (int i = 0; i < crew_idCount; i++)
            {
                int crew_idItem = Convert.ToInt32(Console.ReadLine().Trim());
                crew_id.Add(crew_idItem);
            }

            int job_idCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> job_id = new List<int>();

            for (int i = 0; i < job_idCount; i++)
            {
                int job_idItem = Convert.ToInt32(Console.ReadLine().Trim());
                job_id.Add(job_idItem);
            }

            long result = Result.getMinCost(crew_id, job_id);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}

