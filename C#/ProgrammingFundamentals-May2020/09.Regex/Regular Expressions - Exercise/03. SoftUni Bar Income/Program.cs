using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal totalPrice = 0;
            string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>\d+\.?\d+)\$";
            string input;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match currentMatch = Regex.Match(input, pattern);

                if (currentMatch.Success)
                {
                    string customer = currentMatch.Groups["customer"].Value;
                    string product = currentMatch.Groups["product"].Value;
                    int quantity = int.Parse(currentMatch.Groups["quantity"].Value);
                    decimal price = decimal.Parse(currentMatch.Groups["price"].Value);
                    totalPrice += quantity * price;

                    Console.WriteLine($"{customer}: {product} - {quantity * price:F2}");
                }
            }

            Console.WriteLine($"Total income: {totalPrice:F2}");
        }
    }
}
