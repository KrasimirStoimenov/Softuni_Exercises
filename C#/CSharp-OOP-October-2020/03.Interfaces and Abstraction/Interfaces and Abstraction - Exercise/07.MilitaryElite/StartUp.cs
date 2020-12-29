using System;
using System.Collections.Generic;

using _07.MilitaryElite.Core;
using _07.MilitaryElite.Models;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite
{
    public class StartUp
    {
        static void Main()
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
