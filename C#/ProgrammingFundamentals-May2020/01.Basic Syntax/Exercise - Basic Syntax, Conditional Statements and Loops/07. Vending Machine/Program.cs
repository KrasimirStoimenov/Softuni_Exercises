using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            double sum = 0;
            while ((command = Console.ReadLine()) != "Start")
            {
                double coins = double.Parse(command);
                if (coins == 2 || coins == 1 || coins == 0.50 || coins == 0.20 || coins == 0.10)
                {
                    sum += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
            }

            string product;
            while ((product = Console.ReadLine()) != "End")
            {
                switch (product)
                {
                    case "Nuts":
                        if (sum < 2.00)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            sum -= 2.00;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        break;
                    case "Water":
                        if (sum < 0.70)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            sum -= 0.70;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        break;
                    case "Crisps":
                        if (sum < 1.50)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            sum -= 1.50;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        break;
                    case "Soda":
                        if (sum < 0.80)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            sum -= 0.80;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        break;
                    case "Coke":
                        if (sum < 1.00)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            sum -= 1.00;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
            }
            Console.WriteLine($"Change: {sum:F2}");

        }
    }
}
