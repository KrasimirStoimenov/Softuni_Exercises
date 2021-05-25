using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Chronometer___Asynchronous_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();

            Task.Run(() =>
            {
                chronometer.Start();
            });

            string command;
            while ((command = Console.ReadLine().ToLower()) != "exit")
            {
                Console.WriteLine(chronometer.GetTime);
            }

            chronometer.Stop();
        }
    }
}
