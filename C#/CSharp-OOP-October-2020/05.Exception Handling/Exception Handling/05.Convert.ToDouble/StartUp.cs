using System;

namespace _05.Convert.ToDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var someDouble = System.Convert.ToDouble("");

            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
        }
    }
}
