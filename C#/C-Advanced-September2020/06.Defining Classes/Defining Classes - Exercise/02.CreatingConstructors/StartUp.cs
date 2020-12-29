using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person first = new Person();
            Console.WriteLine(first.Name);
            Console.WriteLine(first.Age);

            Person second = new Person(18);
            Console.WriteLine(second.Name);
            Console.WriteLine(second.Age);

            Person third = new Person("Dimitrichko", 20);
            Console.WriteLine(third.Name);
            Console.WriteLine(third.Age);
        }
    }
}
