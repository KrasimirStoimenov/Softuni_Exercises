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


            string command;
            while ((command = Console.ReadLine().ToLower()) != "exit")
            {
                switch (command)
                {
                    case "start":
                        Task.Run(() =>
                        {
                            chronometer.Start();
                        });
                        break;
                    case "stop":
                        chronometer.Stop();
                        break;
                    case "lap":
                        chronometer.Lap();
                        break;
                    case "laps":
                        break;
                    case "time":
                        break;
                    case "reset":
                        break;
                }
            }

            chronometer.Stop();
        }
    }
}
