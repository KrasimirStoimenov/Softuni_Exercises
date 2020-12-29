using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{

    /*
     * Complete the timeConversion function below.
     */
    static string timeConversion(string s)
    {
        /*
         * Write your code here.
         */
        string output = string.Empty;
        string type = s.Substring(8);
        if (type == "PM")
        {
            s = s.Remove(8);
            int hour = int.Parse(s.Substring(0, 2));
            if (hour < 10)
            {
                s = s.Remove(0, 1);
            }

            if (hour == 12)
            {
                output = s;
            }
            else
            {
                int newHour = hour + 12;
                output = s.Replace(hour.ToString(), newHour.ToString());
            }
        }
        else if (type == "AM")
        {
            s = s.Remove(8);
            int hour = int.Parse(s.Substring(0, 2));
            if (hour == 12)
            {
                output = s.Replace(hour.ToString(), "00");
            }
            else
            {
                output = s;
            }
        }
        return output;

    }

    static void Main(string[] args)
    {
        TextWriter tw = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = timeConversion(s);

        tw.WriteLine(result);

        tw.Flush();
        tw.Close();
    }
}
