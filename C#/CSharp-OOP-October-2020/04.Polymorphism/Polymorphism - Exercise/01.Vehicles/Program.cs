using System;

using _01.Vehicles.Core;
using _01.Vehicles.Models;
using _01.Vehicles.Core.Contracts;

namespace _01.Vehicles
{
    public class Program
    {
        static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
