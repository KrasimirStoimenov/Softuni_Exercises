using System;
using System.Linq;

namespace _03._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] leftSide = new int[initialArr.Length / 4];
            int[] rightSide = new int[initialArr.Length / 4];
            FillSideArrays(initialArr, leftSide, rightSide);

            int[] middleSide = new int[initialArr.Length / 2];
            FillMiddleSideArray(initialArr, middleSide);

            Array.Reverse(leftSide);
            Array.Reverse(rightSide);
            int[] mergeSides = MergeLeftAndRightSide(leftSide, rightSide);

            Console.WriteLine(string.Join(" ", GetFilledFinalArray(mergeSides, middleSide)));
        }

        static int[] GetFilledFinalArray(int[] firstMiddle, int[] secondMiddle)
        {
            int[] final = new int[firstMiddle.Length];
            for (int i = 0; i < final.Length; i++)
            {
                final[i] = firstMiddle[i] + secondMiddle[i];
            }

            return final;
        }

        static int[] MergeLeftAndRightSide(int[] left, int[] right)
        {
            int[] merge = new int[left.Length * 2];
            for (int i = 0; i < merge.Length; i++)
            {
                if (i < merge.Length / 2)
                {
                    merge[i] = left[i];
                }
                else
                {
                    merge[i] = right[i - merge.Length / 2];
                }
            }

            return merge;
        }

        static void FillMiddleSideArray(int[] initialArr, int[] middleSide)
        {
            int from = initialArr.Length / 4;
            int to = initialArr.Length - (from + 1);
            for (int i = from; i <= to; i++)
            {
                middleSide[i - from] = initialArr[i];
            }
        }

        static void FillSideArrays(int[] initialArr, int[] leftSide, int[] rightSide)
        {
            int count = initialArr.Length / 4;
            for (int i = 0; i < count; i++)
            {
                leftSide[i] = initialArr[i];
                rightSide[rightSide.Length - 1 - i] = initialArr[initialArr.Length - 1 - i];
            }
        }
    }
}
