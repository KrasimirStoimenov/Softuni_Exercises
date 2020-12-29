using System;

namespace _10._Cube_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideOfCube = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();
            double result = 0;
            switch (parameter)
            {
                case "face":
                    result = GetFaceDiagonal(sideOfCube);
                    break;
                case "space":
                    result = GetSpaceDiagonal(sideOfCube);
                    break;
                case "volume":
                    result = GetVolume(sideOfCube);
                    break;
                case "area":
                    result = GetArea(sideOfCube);
                    break;
            }

            Console.WriteLine($"{result:F2}");

        }
        static double GetFaceDiagonal(double side)
        {
            return Math.Sqrt(2 * (side * side));
        }
        static double GetSpaceDiagonal(double side)
        {
            return Math.Sqrt(3 * (side * side));
        }

        static double GetVolume(double side)
        {
            return side * side * side;
        }

        static double GetArea(double side)
        {
            return 6 * (side * side);
        }
    }
}
