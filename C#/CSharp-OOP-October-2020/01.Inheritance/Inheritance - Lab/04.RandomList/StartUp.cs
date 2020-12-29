using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("A");
            list.Add("B");
            list.Add("C");
            list.Add("D");

            Console.WriteLine(list.RandomString()); 
        }
    }
}
