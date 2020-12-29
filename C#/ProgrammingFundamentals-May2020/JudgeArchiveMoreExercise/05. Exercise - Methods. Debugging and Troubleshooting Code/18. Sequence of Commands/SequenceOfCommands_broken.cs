using System;
using System.Linq;

public class SequenceOfCommands_broken
{

    public static void Main()
    {
        int sizeOfArray = int.Parse(Console.ReadLine());

        long[] array = Console.ReadLine()
            .Split()
            .Select(long.Parse)
            .ToArray();

        string command;
        while ((command = Console.ReadLine()) != "stop")
        {
            string[] stringParams = command.Split();
            if (stringParams[0] == "lshift")
            {
                ArrayShiftLeft(array);
            }
            else if (stringParams[0] == "rshift")
            {
                ArrayShiftRight(array);

            }
            else
            {
                PerformAction(array, stringParams[0], stringParams[1], stringParams[2]);
            }

            Console.WriteLine(PrintArray(array));

        }
    }

    static void PerformAction(long[] arr, string action, string element, string val)
    {
        int pos = int.Parse(element);
        int value = int.Parse(val);

        switch (action)
        {
            case "multiply":
                arr[pos - 1] *= value;
                break;
            case "add":
                arr[pos - 1] += value;
                break;
            case "subtract":
                arr[pos - 1] -= value;
                break;
        }
    }

    private static void ArrayShiftRight(long[] array)
    {
        long temp = array.Last();
        for (int i = array.Length - 1; i >= 1; i--)
        {
            array[i] = array[i - 1];
        }
        array[0] = temp;
    }

    private static void ArrayShiftLeft(long[] array)
    {
        long temp = array[0];
        for (int i = 0; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }
        array[array.Length - 1] = temp;
    }

    private static string PrintArray(long[] array)
    {
        string result = string.Join(" ", array);
        return result;
    }
}
