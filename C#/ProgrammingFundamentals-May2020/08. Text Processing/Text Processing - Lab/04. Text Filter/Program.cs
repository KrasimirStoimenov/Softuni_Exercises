using System;
using System.Linq;
using System.Text;

namespace _04._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banWords = Console.ReadLine()
                .Split(", ")
                .ToArray();

            string sentence = Console.ReadLine();

            for (int i = 0; i < banWords.Length; i++)
            {
                while (sentence.Contains(banWords[i]))
                {
                    sentence = sentence.Replace(banWords[i], new string('*', banWords[i].Length));
                }
            }
            Console.WriteLine(sentence);

        }
    }
}
