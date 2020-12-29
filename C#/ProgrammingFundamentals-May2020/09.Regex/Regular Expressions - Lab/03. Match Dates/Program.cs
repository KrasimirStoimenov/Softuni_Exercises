using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b(?<day>\d{2})(\/|\.|\-)(?<month>[A-Z]{1}[a-z]{2})\1(?<year>\d{4})\b";

            MatchCollection dates = Regex.Matches(input, pattern);

            foreach (Match date in dates)
            {
                string day = date.Groups["day"].Value;
                string month = date.Groups["month"].Value;
                string year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }


        }
    }
}
