using System;

namespace _01._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                bool integer = long.TryParse(input, out long resultInt);
                bool floatingPointNumber = float.TryParse(input, out float resultDouble);
                bool character = char.TryParse(input, out char resultChar);
                bool boolean = bool.TryParse(input, out bool resultBool);
                string type = string.Empty;
                if (integer)
                {
                    type = "integer";
                }
                else if (floatingPointNumber)
                {
                    type = "floating point";
                }
                else if (character)
                {
                    type = "character";
                }
                else if (boolean)
                {
                    type = "boolean";
                }
                else
                {
                    type = "string";
                }

                Console.WriteLine($"{input} is {type} type");

            }
        }
    }
}
