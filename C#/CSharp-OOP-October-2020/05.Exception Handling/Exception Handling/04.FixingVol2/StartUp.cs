using System;

namespace _04.FixingVol2
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int num1, num2;
            byte result;

            num1 = 30;
            num2 = 60;
            try
            {
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
                Console.ReadLine();
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);

            }
        }
    }
}
