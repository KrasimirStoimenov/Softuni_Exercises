using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int barcodeCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < barcodeCount; i++)
            {
                string currentBarcode = Console.ReadLine();
                string pattern = @"@#+([A-Z][A-Za-z0-9]+[A-Z])@#+";

                Match barcodeMatch = Regex.Match(currentBarcode, pattern);
                if (barcodeMatch.Success)
                {
                    string barcode = barcodeMatch.Groups[1].Value;
                    if (barcodeMatch.Groups[1].Length < 6)
                    {
                        Console.WriteLine($"Invalid barcode");
                    }
                    else
                    {
                        string codePattern = @"\d";
                        MatchCollection digits = Regex.Matches(barcode, codePattern);
                        if (digits.Count > 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            foreach (var digit in digits)
                            {
                                sb.Append(digit);
                            }
                            Console.WriteLine($"Product group: {sb}");
                        }
                        else
                        {
                            Console.WriteLine("Product group: 00");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid barcode");
                }
            }
        }
    }
}
