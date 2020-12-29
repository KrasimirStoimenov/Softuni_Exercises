using System;
using System.Linq;

namespace _03.Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidOperationException("Invalid number!");
            }
            return $"Dialing... {number}";
        }
    }
}
