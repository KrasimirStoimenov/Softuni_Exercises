using System;

namespace GiftboxCoverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double sizeOfSide = double.Parse(Console.ReadLine());
            int numberOfSheets = int.Parse(Console.ReadLine());
            double areaSingleSheetCover = double.Parse(Console.ReadLine());

            double areaOfGiftBox = sizeOfSide * sizeOfSide * 6;
            double totalAreaSheetCover = 0;

            for (int i = 1; i <= numberOfSheets; i++)
            {
                if (i % 3 == 0)
                {
                    totalAreaSheetCover += areaSingleSheetCover * 0.25;
                    continue;
                }
                totalAreaSheetCover += areaSingleSheetCover;
            }

            double percentage = totalAreaSheetCover / areaOfGiftBox * 100;

            Console.WriteLine($"You can cover {percentage:F2}% of the box.");
        }
    }
}