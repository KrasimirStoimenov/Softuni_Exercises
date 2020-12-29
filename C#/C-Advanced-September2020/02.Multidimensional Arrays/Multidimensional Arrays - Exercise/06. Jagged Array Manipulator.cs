using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[rows][];
            ReadJaggedArray(jaggedArray);
            AnalyzingJaggedArray(jaggedArray);
            ProccessedWithCommands(jaggedArray);
            PrintJaggedArray(jaggedArray);
        }

        static void PrintJaggedArray(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }
        }

        static void ProccessedWithCommands(double[][] jaggedArray)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(" ").ToArray();
                string action = cmdArgs[0];
                int rowIndex = int.Parse(cmdArgs[1]);
                int colIndex = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if ((IndexValidator(rowIndex, jaggedArray.Length))
                    && (IndexValidator(colIndex, jaggedArray[rowIndex].Length)))
                {
                    if (action == "Add")
                    {
                        jaggedArray[rowIndex][colIndex] += value;
                    }
                    else if (action == "Subtract")
                    {
                        jaggedArray[rowIndex][colIndex] -= value;
                    }
                }
            }
        }

        static void AnalyzingJaggedArray(double[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length.Equals(jaggedArray[row + 1].Length))
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                    for (int next = 0; next < jaggedArray[row + 1].Length; next++)
                    {
                        jaggedArray[row + 1][next] /= 2;
                    }
                }
            }
        }

        static void ReadJaggedArray(double[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                string input = Console.ReadLine();
                char firstChar = input[0];

                double[] numbers = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                jaggedArray[i] = new double[numbers.Length];
                for (int j = 0; j < numbers.Length; j++)
                {
                    jaggedArray[i][j] = numbers[j];
                }
            }
        }

        static bool IndexValidator(int index, int jaggedArrayLength)
        {
            if (index >= 0 && index < jaggedArrayLength)
            {
                return true;
            }
            return false;
        }
    }
}
