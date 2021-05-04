using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Active_Traders
{
    class Result
    {

        /*
         * Complete the 'mostActive' function below.
         *
         * The function is expected to return a STRING_ARRAY.
         * The function accepts STRING_ARRAY customers as parameter.
         */

        public static List<string> mostActive(List<string> customers)
        {
            var count = customers.Count;

            var activeCustomers = new Dictionary<string, int>();

            foreach (var customer in customers)
            {
                if (activeCustomers.ContainsKey(customer))
                {
                    activeCustomers[customer]++;
                }
                else
                {
                    activeCustomers.Add(customer, 1);
                }
            }

            var mostActiveCustomers = new List<string>();

            foreach (var customer in activeCustomers)
            {
                var customerContibute = customer.Value / (count * 1.0) * 100;

                if (customerContibute >= 5)
                {
                    mostActiveCustomers.Add(customer.Key);
                }
            }

            return mostActiveCustomers.OrderBy(x => x).ToList();
        }
    }
}
