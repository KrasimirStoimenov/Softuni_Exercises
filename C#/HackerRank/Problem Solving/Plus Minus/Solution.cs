using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the plusMinus function below.
    static void plusMinus(int[] arr)
    {
        int positiveNumbersCount = 0;
        int negativeNumbersCount = 0;
        int zeroNumbersCount = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > 0)
            {
                positiveNumbersCount++;
            }
            else if (arr[i] < 0)
            {
                negativeNumbersCount++;
            }
            else
            {
                zeroNumbersCount++;
            }
        }

        double positiveRatio = (double)positiveNumbersCount / arr.Length;
        double negativeRatio = (double)negativeNumbersCount / arr.Length;
        double zerosRatio = (double)zeroNumbersCount / arr.Length;

        Console.WriteLine($"{positiveRatio:F6}");
        Console.WriteLine($"{negativeRatio:F6}");
        Console.WriteLine($"{zerosRatio:F6}");


    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        plusMinus(arr);
    }
}
