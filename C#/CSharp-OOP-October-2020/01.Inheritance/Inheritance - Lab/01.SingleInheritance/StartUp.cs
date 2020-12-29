using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog doggy = new Dog();
            doggy.Bark();
            doggy.Eat();
            doggy.Bark();
        }
    }
}
