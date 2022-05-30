using System;

namespace BLL.Exceptions
{
    class InvalidOrderException : Exception
    {
        public InvalidOrderException(string message = "ERROR: Invalid order") : base(message)
        {

        }
    }
}
