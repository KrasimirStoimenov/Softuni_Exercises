using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaust = int.Parse(Console.ReadLine());
            double pokePower50Percent = (double)pokePower / 2;
            int pokeCounter = 0;

            while (true)
            {
                if (pokePower >= distance)
                {
                    pokePower -= distance;
                    pokeCounter++;
                }
                if (pokePower < distance)
                {
                    break;
                }
                if (pokePower == pokePower50Percent && exhaust > 0)
                {
                    pokePower /= exhaust;
                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(pokeCounter);
        }
    }
}
