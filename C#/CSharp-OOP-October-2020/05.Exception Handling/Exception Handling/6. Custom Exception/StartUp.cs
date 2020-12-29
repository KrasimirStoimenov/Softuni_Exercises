using _6._Custom_Exception.Exceptions;
using System;

namespace _6._Custom_Exception
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var student = new Student("Gin4o", "test@test");
            }
            catch (InvalidPersonNameException ipne)
            {
                Console.WriteLine(ipne.Message);
            }
        }
    }
}
