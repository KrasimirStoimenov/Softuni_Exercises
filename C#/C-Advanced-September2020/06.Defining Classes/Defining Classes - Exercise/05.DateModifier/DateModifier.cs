using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public int CalculateDays(string firstDate, string secondDate)
        {
            string[] firstDateArgs = firstDate.Split(" ").ToArray();
            int firstYear = int.Parse(firstDateArgs[0]);
            int firstMonth = int.Parse(firstDateArgs[1]);
            int firstDay = int.Parse(firstDateArgs[2]);
            DateTime first = new DateTime(firstYear, firstMonth, firstDay);

            string[] secondDateArgs = secondDate.Split(" ").ToArray();
            int secondYear = int.Parse(secondDateArgs[0]);
            int secondMonth = int.Parse(secondDateArgs[1]);
            int secondDay = int.Parse(secondDateArgs[2]);
            DateTime second = new DateTime(secondYear, secondMonth, secondDay);

            int result = Math.Abs((first - second).Days);
            return result;
        }
    }
}
