namespace _03._Last_Stop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var paintingNumbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split();

                switch (cmdArgs[0])
                {
                    case "Change":
                        Change(paintingNumbers, cmdArgs);
                        break;
                    case "Hide":
                        Hide(paintingNumbers, cmdArgs);
                        break;
                    case "Switch":
                        Switch(paintingNumbers, cmdArgs);
                        break;
                    case "Insert":
                        Insert(paintingNumbers, cmdArgs);
                        break;
                    case "Reverse":
                        paintingNumbers.Reverse();
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", paintingNumbers));
        }

        static void Insert(List<int> paintingNumbers, string[] cmdArgs)
        {
            int checkIndex = int.Parse(cmdArgs[1]);
            int paintNumber = int.Parse(cmdArgs[2]);
            if (checkIndex + 1 >= 0 && checkIndex < paintingNumbers.Count)
            {
                paintingNumbers.Insert(checkIndex+1, paintNumber);
            }
        }

        static void Switch(List<int> paintingNumbers, string[] cmdArgs)
        {
            int firstPaintingNumber = int.Parse(cmdArgs[1]);
            int secondPaintingNumber = int.Parse(cmdArgs[2]);
            int firstIndex = 0;
            int secondIndex = 0;
            if (paintingNumbers.Contains(firstPaintingNumber)
                && paintingNumbers.Contains(secondPaintingNumber))
            {
                for (int i = 0; i < paintingNumbers.Count; i++)
                {
                    if (paintingNumbers[i] == firstPaintingNumber)
                    {
                        firstIndex = i;
                    }
                    else if (paintingNumbers[i] == secondPaintingNumber)
                    {
                        secondIndex = i;
                    }
                }

                int temp = paintingNumbers[firstIndex];
                paintingNumbers[firstIndex] = paintingNumbers[secondIndex];
                paintingNumbers[secondIndex] = temp;
            }
        }

        static void Hide(List<int> paintingNumbers, string[] cmdArgs)
        {
            int currentPainting = int.Parse(cmdArgs[1]);
            if (paintingNumbers.Contains(currentPainting))
            {
                paintingNumbers.Remove(currentPainting);
            }
        }

        static void Change(List<int> paintingNumbers, string[] cmdArgs)
        {
            int numberToChange = int.Parse(cmdArgs[1]);
            int number = int.Parse(cmdArgs[2]);
            int index = 0;
            if (paintingNumbers.Contains(numberToChange))
            {
                for (int i = 0; i < paintingNumbers.Count; i++)
                {
                    int currentIndex = paintingNumbers[i];
                    if (currentIndex == numberToChange)
                    {
                        index = i;
                        break;
                    }
                }
                paintingNumbers.Remove(numberToChange);
                paintingNumbers.Insert(index, number);
            }
        }
    }
}
