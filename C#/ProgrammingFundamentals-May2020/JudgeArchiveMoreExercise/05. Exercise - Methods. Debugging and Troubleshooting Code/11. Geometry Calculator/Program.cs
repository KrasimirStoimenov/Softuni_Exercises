using System;

namespace _11._Geometry_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine();
            double result = 0;
            switch (figureType)
            {
                case "triangle":
                    result = GetTriangleArea();
                    break;
                case "square":
                    result = GetSquareArea();
                    break;
                case "rectangle":
                    result = GetRectangleArea();
                    break;
                case "circle":
                    result = GetCircleArea();
                    break;
            }

            Console.WriteLine($"{result:F2}");
        }

        static double GetTriangleArea()
        {
            double side = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            return (side * height)*0.5;
        }

        static double GetSquareArea()
        {
            double side = double.Parse(Console.ReadLine());
            return side * side;
        }

        static double GetRectangleArea()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            return width * height;
        }

        static double GetCircleArea()
        {
            double radius = double.Parse(Console.ReadLine());

            return Math.PI * (radius * radius);
        }
    }
}
