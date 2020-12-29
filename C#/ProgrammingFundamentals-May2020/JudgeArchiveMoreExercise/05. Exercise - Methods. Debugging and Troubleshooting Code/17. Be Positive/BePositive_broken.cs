using System;
using System.Collections.Generic;

public class BePositive_broken
{
    public static void Main()
    {
        int countSequences = int.Parse(Console.ReadLine());

        for (int i = 0; i < countSequences; i++)
        {
            string[] input = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var numbers = new List<int>();

            bool found = false;

            for (int j = 0; j < input.Length; j++)
            {
                int currentNum = int.Parse(input[j]);

                if (currentNum >= 0)
                {
                    numbers.Add(currentNum);
                    found = true;
                }
                else
                {
                    if (j + 1 > input.Length-1)
                    {
                        continue;
                    }
                    currentNum += int.Parse(input[j + 1]);
                    j++;
                    if (currentNum >= 0)
                    {
                        numbers.Add(currentNum);
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("(empty)");
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}