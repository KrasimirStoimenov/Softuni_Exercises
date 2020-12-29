using System;
using System.Linq;

namespace _08.Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstLineArgs = ReadInput();
            string firstAndLastName = $"{firstLineArgs[0]} {firstLineArgs[1]}";
            string address = firstLineArgs[2];
            string town = firstLineArgs[3];
            if (firstLineArgs.Length > 4)
            {
                town = $"{firstLineArgs[3]} {firstLineArgs[4]}";
            }
            Threeuple<string, string, string> personArgs = new Threeuple<string, string, string>(firstAndLastName, address, town);

            string[] secondLineArgs = ReadInput();
            string name = secondLineArgs[0];
            int littersOfBeerPersonCanDrink = int.Parse(secondLineArgs[1]);
            string drunkOrNot = secondLineArgs[2];
            bool isDrunk = false;
            if (drunkOrNot == "drunk")
            {
                isDrunk = true;
            }
            Threeuple<string, int,bool> personBeerPair = new Threeuple<string, int, bool>(name, littersOfBeerPersonCanDrink,isDrunk);

            string[] thirdLineArgs = ReadInput();
            string personName = thirdLineArgs[0];
            double doubleInteger = double.Parse(thirdLineArgs[1]);
            string bankName = thirdLineArgs[2];
            Threeuple<string, double,string> integerDoublePair = new Threeuple<string, double, string>(personName, doubleInteger,bankName);

            Console.WriteLine(personArgs);
            Console.WriteLine(personBeerPair);
            Console.WriteLine(integerDoublePair);
        }

        public static string[] ReadInput() => Console.ReadLine()
            .Split(" ")
            .ToArray();
    }
}
