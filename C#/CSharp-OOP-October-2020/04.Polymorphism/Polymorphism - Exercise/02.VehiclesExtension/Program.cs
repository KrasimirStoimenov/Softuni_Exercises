using System;

using _02.VehiclesExtension.Core;
using _02.VehiclesExtension.Models;
using _02.VehiclesExtension.Core.Contracts;

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
