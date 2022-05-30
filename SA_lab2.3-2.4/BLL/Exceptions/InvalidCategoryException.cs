using System;

namespace BLL.Exceptions
{
    class InvalidCategoryException : Exception
    {
        public InvalidCategoryException(string message = "ERROR: Invalid category") : base(message)
        {

        }
    }
}
