using System;
using System.Linq;

namespace _03.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidOperationException("Invalid number!");
            }
            return $"Calling... {number}";
        }

        public string Browse(string site)
        {
            if (site.Any(x => char.IsDigit(x)))
            {
                throw new InvalidOperationException("Invalid URL!");
            }
            return $"Browsing: {site}!";
        }

    }
}
