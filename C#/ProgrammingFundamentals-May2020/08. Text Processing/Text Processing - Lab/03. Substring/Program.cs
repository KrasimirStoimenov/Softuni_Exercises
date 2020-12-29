using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyWord = Console.ReadLine();
            string word = Console.ReadLine();

            while (true)
            {
                int index = word.IndexOf(keyWord.ToLower());
                if (index == -1)
                {
                    break;
                }
                word = word.Remove(index, keyWord.Length);
            }
            Console.WriteLine(word);
        }
    }
}
