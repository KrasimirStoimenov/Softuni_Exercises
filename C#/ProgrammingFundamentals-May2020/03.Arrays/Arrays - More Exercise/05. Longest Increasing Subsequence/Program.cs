namespace P05_LongestIncreasingSubsequence
{
    using System;
    using System.Linq;

    class P05_LongestIncreasingSubsequence
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            int maxLength = 0;
            int lastIndex = -1;
            int[] length = new int[nums.Length];
            int[] previous = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                length[i] = 1;
                previous[i] = -1;

                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i] && length[j] + 1 > length[i])
                    {
                        length[i] = length[j] + 1;
                        previous[i] = j;
                    }
                }

                if (length[i] > maxLength)
                {
                    maxLength = length[i];
                    lastIndex = i;
                }
            }

            int[] longestSubsequence = new int[maxLength];
            int currentIndex = maxLength - 1;

            while (lastIndex != -1)
            {
                longestSubsequence[currentIndex] = nums[lastIndex];
                currentIndex--;
                lastIndex = previous[lastIndex];
            }

            Console.WriteLine(string.Join(" ", longestSubsequence));
        }
    }
}