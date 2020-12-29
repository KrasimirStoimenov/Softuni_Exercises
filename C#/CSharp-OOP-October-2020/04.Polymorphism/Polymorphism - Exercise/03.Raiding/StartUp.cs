using System;

using _03.Raiding.Core;
using _03.Raiding.Core.Contracts;

namespace _03.Raiding
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
