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

    static void Main(string[] args)
    {
        int[][] arr = new int[6][];

        for (int i = 0; i < 6; i++)
        {
            arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        }

        int maxSum = int.MinValue;
        for (int row = 1; row < arr.GetLength(0) - 1; row++)
        {
            int currentSum = int.MinValue;
            for (int col = 1; col < arr[row].Length - 1; col++)
            {
                int upperLeft = arr[row - 1][col - 1];
                int upperMiddle = arr[row - 1][col];
                int upperRight = arr[row - 1][col + 1];
                int currentPosition = arr[row][col];
                int downLeft = arr[row + 1][col - 1];
                int downMiddle = arr[row + 1][col];
                int downRight = arr[row + 1][col + 1];
                currentSum = upperLeft + upperMiddle + upperRight + currentPosition + downLeft + downMiddle + downRight;

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }

        }

        Console.WriteLine(maxSum);
    }
}
