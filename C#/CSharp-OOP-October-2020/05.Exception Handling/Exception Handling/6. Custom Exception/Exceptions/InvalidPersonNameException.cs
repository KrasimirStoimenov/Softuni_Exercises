using System;

namespace _6._Custom_Exception.Exceptions
{
    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException(string message) 
            : base(message)
        {
        }
    }
}
