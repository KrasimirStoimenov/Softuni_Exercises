using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._TakeSkip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Proccessing(input);

        }

        static void Proccessing(string input)
        {
            List<char> lettersList = new List<char>();
            List<int> numbersList = new List<int>();
            GetListsFilled(input, lettersList, numbersList);
            List<int> skipList = new List<int>();
            List<int> takeList = new List<int>();
            GetSkipAndTakeLists(numbersList, skipList, takeList);
            StringBuilder sb = new StringBuilder();
            while (lettersList.Any())
            {
                for (int j = 0; j < takeList[0]; j++)
                {
                    if (j > lettersList.Count - 1)
                    {
                        break;
                    }
                    sb.Append(lettersList[j]);

                }
                if (takeList[0] > lettersList.Count - 1)
                {
                    takeList[0] = lettersList.Count - 1;
                }
                
                lettersList.RemoveRange(0, takeList[0]);
                lettersList.RemoveRange(0, skipList[0]);
                takeList.RemoveAt(0);
                skipList.RemoveAt(0);
                if (takeList.Count == 0)
                {
                    break;
                }

            }


            Console.WriteLine(sb);
        }

        static void GetSkipAndTakeLists(List<int> numbers, List<int> skip, List<int> take)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    take.Add(numbers[i]);
                }
                else
                {
                    skip.Add(numbers[i]);
                }
            }
        }

        static void GetListsFilled(string input, List<char> letters, List<int> numbers)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    numbers.Add(c - '0');
                }
                else
                {
                    letters.Add(c);
                }
            }
        }
    }
}
