using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Road_Repair
{
    class Result
    {

        /*
         * Complete the 'getMinCost' function below.
         *
         * The function is expected to return a LONG_INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY crew_id
         *  2. INTEGER_ARRAY job_id
         */

        public static long getMinCost(List<int> crew_id, List<int> job_id)
        {
            var minCost = 0;

            var sortedCrew = crew_id.OrderBy(x => x).ToList();
            var sortedJob = job_id.OrderBy(x => x).ToList();

            for (int i = 0; i < sortedCrew.Count; i++)
            {
                var currentCrew = sortedCrew[i];
                var currentJob = sortedJob[i];

                if (currentJob >= currentCrew)
                {
                    minCost += currentJob - currentCrew;
                }

                else if (currentJob < currentCrew)

                {
                    minCost += currentCrew - currentJob;
                }
            }

            if (minCost < 0)
            {
                minCost = 0;
            }

            return minCost;

        }
    }
}
