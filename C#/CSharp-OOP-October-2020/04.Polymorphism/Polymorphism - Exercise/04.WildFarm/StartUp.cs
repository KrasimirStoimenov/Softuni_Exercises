using System;

using _04.WildFarm.Core;
using _04.WildFarm.Core.Contracts;

namespace _04.WildFarm
{
    public class StartUp
    {
        static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
