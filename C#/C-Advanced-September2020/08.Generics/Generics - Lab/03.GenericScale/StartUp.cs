﻿using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> eq = new EqualityScale<int>(5,5);
            Console.WriteLine(eq.AreEqual());
        }
    }
}
