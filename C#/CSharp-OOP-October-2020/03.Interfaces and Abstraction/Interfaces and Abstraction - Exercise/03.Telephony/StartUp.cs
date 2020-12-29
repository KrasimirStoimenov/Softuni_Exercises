using System;

namespace _03.Telephony
{
    public class StartUp
    {
        static void Main()
        {

            string[] telephoneNumbers = Console.ReadLine().Split(" ");
            string[] sites = Console.ReadLine().Split(" ");

            foreach (var telephoneNumber in telephoneNumbers)
            {
                try
                {
                    ICallable phone;
                    if (telephoneNumber.Length == 10)
                    {
                        phone = new Smartphone();
                    }
                    else
                    {
                        phone = new StationaryPhone();
                    }
                    Console.WriteLine(phone.Call(telephoneNumber));
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            foreach (var site in sites)
            {
                try
                {
                    IBrowsable browse = new Smartphone();
                    Console.WriteLine(browse.Browse(site));
                }
                catch (InvalidOperationException ioe)
                {

                    Console.WriteLine(ioe.Message);
                }

            }
        }

    }
}

