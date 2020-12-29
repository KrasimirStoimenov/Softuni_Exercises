using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int minutesAfter30Minutes = minutes + 30;

            if (minutesAfter30Minutes > 59)
            {
                hours++;
                minutesAfter30Minutes -= 60;
            }
            if (hours > 23)
            {
                hours = 0;
            }
            Console.WriteLine("{0}:{1:D2}", hours, minutesAfter30Minutes);

        }
    }
}
