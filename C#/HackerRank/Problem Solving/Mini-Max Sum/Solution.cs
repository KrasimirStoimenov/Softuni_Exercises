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

    // Complete the miniMaxSum function below.
    static void miniMaxSum(int[] arr)
    {
        long maxSum = long.MinValue;
        long minSum = long.MaxValue;

        for (int i = 0; i < arr.Length; i++)
        {
            long currentSum = 0;
            for (int j = 0; j < arr.Length; j++)
            {
                if (j == i)
                {
                    continue;
                }
                currentSum += arr[j];
            }
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }
            if (currentSum < minSum)
            {
                minSum = currentSum;
            }
        }
        Console.WriteLine($"{minSum} {maxSum}");

    }

    static void Main(string[] args)
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        miniMaxSum(arr);
    }
}
