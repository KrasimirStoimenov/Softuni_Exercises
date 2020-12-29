using System;

namespace _06._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            bool isBalanced = true;
            bool hasOpening = false;

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    if (!hasOpening)
                    {
                        hasOpening = true;
                    }
                    else
                    {
                        isBalanced = false;
                    }
                }
                else if (input == ")")
                {
                    if (hasOpening)
                    {
                        hasOpening = false;
                    }
                    else
                    {
                        isBalanced = false;
                    }
                }
            }
            if (isBalanced && !hasOpening)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
