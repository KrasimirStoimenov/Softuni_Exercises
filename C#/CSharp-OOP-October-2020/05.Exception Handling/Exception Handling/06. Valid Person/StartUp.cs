using System;

namespace _06._Valid_Person
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {

                var person = new Person("Test", "Testov", 121);
            }
            catch (ArgumentNullException ane)
            {

                Console.WriteLine(ane.Message);
            }
            catch (ArgumentOutOfRangeException aoue)
            {
                Console.WriteLine(aoue.Message);
            }
        }
    }
}
