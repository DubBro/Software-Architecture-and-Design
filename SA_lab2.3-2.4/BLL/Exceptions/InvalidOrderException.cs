using System;

namespace BLL.Exceptions
{
    public class InvalidOrderException : Exception
    {
        public InvalidOrderException(string message = "ERROR: Invalid order") : base(message)
        {

        }
    }
}
