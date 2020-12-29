using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Wizard_Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> deck = Console.ReadLine()
                .Split(':')
                .ToList();
            List<string> newDeck = new List<string>();

            string command;
            while ((command = Console.ReadLine()) != "Ready")
            {
                string[] cmdArgs = command.Split();
                string cardName = cmdArgs[1];

                switch (cmdArgs[0])
                {
                    case "Add":
                        if (deck.Contains(cardName))
                        {
                            newDeck.Add(cardName);
                        }
                        else
                        {
                            Console.WriteLine("Card not found.");
                        }
                        break;
                    case "Insert":
                        int index = int.Parse(cmdArgs[2]);
                        if (deck.Contains(cardName) && (index >= 0 && index < newDeck.Count))
                        {
                            newDeck.Insert(index, cardName);
                        }
                        else
                        {
                            Console.WriteLine("Error!");
                        }
                        break;
                    case "Remove":
                        if (newDeck.Contains(cardName))
                        {
                            newDeck.Remove(cardName);
                        }
                        else
                        {
                            Console.WriteLine("Card not found.");
                        }
                        break;
                    case "Swap":
                        string cardName2 = cmdArgs[2];
                        int firstCardIndex = -1;
                        int secondCardIndex = -1;
                        firstCardIndex = newDeck.IndexOf(cardName);
                        secondCardIndex = newDeck.IndexOf(cardName2);

                        newDeck.Insert(firstCardIndex, cardName2);
                        newDeck.Insert(secondCardIndex+1, cardName);
                        newDeck.RemoveAt(firstCardIndex + 1);
                        newDeck.RemoveAt(secondCardIndex + 1);
                        break;
                    case "Shuffle":
                        newDeck.Reverse();
                        break;
                }
            }

            Console.WriteLine(string.Join(' ',newDeck));
        }
    }
}
