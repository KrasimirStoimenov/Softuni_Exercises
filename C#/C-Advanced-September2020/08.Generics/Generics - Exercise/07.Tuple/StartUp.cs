using System;
using System.Linq;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstLineArgs = ReadInput();
            string firstAndLastName = $"{firstLineArgs[0]} {firstLineArgs[1]}";
            string address = firstLineArgs[2];
            Tuple<string, string> personArgs = new Tuple<string, string>(firstAndLastName, address);

            string[] secondLineArgs = ReadInput();
            string name = secondLineArgs[0];
            int littersOfBeerPersonCanDrink = int.Parse(secondLineArgs[1]);
            Tuple<string, int> personBeerPair = new Tuple<string, int>(name, littersOfBeerPersonCanDrink);

            string[] thirdLineArgs = ReadInput();
            int integer = int.Parse(thirdLineArgs[0]);
            double doubleInteger = double.Parse(thirdLineArgs[1]);
            Tuple<int, double> integerDoublePair = new Tuple<int, double>(integer, doubleInteger);

            Console.WriteLine(personArgs);
            Console.WriteLine(personBeerPair);
            Console.WriteLine(integerDoublePair);
        }

        public static string[] ReadInput() => Console.ReadLine()
            .Split(" ")
            .ToArray();
    }
}
