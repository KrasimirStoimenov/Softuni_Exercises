﻿using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "BMW";
            car.Model = "E90";
            car.Year = 2008;

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear:{car.Year}");
        }
    }
}
