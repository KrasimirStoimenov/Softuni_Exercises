using System;

namespace _02._Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] gifts = Console.ReadLine()
                .Split(" ");

            string command;
            while ((command = Console.ReadLine()) != "No Money")
            {
                string[] cmdArgs = command.Split(" ");

                switch (cmdArgs[0])
                {
                    case "OutOfStock":
                        OutOfStockMethod(gifts, cmdArgs);
                        break;
                    case "Required":
                        GetRequired(gifts, cmdArgs);
                        break;
                    case "JustInCase":
                        GetJustInCase(gifts, cmdArgs);
                        break;
                }
            }
            foreach (var gift in gifts)
            {
                if (gift != "None")
                {
                    Console.Write(gift + " ");
                }
            }
        }
        static void GetJustInCase(string[] gifts, string[] cmdArgs)
        {
            string currentGift = cmdArgs[1];
            gifts[gifts.Length - 1] = currentGift;
        }
        static void GetRequired(string[] gifts, string[] cmdArgs)
        {
            string gift = cmdArgs[1];
            int index = int.Parse(cmdArgs[2]);

            if (index >= 0 && index < gifts.Length)
            {
                gifts[index] = gift;
            }
        }

        static void OutOfStockMethod(string[] gifts, string[] cmdArgs)
        {
            for (int i = 0; i < gifts.Length; i++)
            {
                if (gifts[i] == cmdArgs[1])
                {
                    gifts[i] = "None";
                }
            }
        }
    }
}
