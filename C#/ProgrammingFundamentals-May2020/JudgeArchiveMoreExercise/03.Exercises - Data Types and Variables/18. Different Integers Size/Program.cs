using System;

namespace _18._Different_Integers_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            bool @sbyte = sbyte.TryParse(number, out sbyte result);
            bool @byte = byte.TryParse(number, out byte resultByte);
            bool @short = short.TryParse(number, out short resultShort);
            bool @ushort = ushort.TryParse(number, out ushort resultUshort);
            bool @int = int.TryParse(number, out int resultInt);
            bool @uint = uint.TryParse(number, out uint resultUint);
            bool @long = long.TryParse(number, out long resultLong);

            if (!@sbyte && !@byte && !@short && !@ushort && !@int && !@uint && !@long)
            {
                Console.WriteLine($"{number} can't fit in any type");
            }
            else
            {
                Console.WriteLine($"{number} can fit in:");
                if (@sbyte)
                {
                    Console.WriteLine("* sbyte");
                }
                if (@byte)
                {
                    Console.WriteLine("* byte");
                }
                if (@short)
                {
                    Console.WriteLine("* short");
                }
                if (@ushort)
                {
                    Console.WriteLine("* ushort");
                }
                if (@int)
                {
                    Console.WriteLine("* int");
                }
                if (@uint)
                {
                    Console.WriteLine("* uint");
                }
                if (@long)
                {
                    Console.WriteLine("* long");
                }
            }
        }
    }
}
