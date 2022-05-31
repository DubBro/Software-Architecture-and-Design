using System;

namespace BLL.Exceptions
{
    public class InvalidDayException : Exception
    {
        public InvalidDayException(string message = "ERROR: Invalid day") : base(message)
        {

        }
    }
}
