using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main()
        {
            Shape circle = new Circle(4);

            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.Draw());

            Shape rectangle = new Rectangle(3, 5);

            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.Draw());
        }
    }
}
