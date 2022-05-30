using System;

namespace BLL.Exceptions
{
    class InvalidDayException : Exception
    {
        public InvalidDayException(string message = "ERROR: Invalid day") : base(message)
        {

        }
    }
}
