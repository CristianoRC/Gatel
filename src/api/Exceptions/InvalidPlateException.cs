using System;

namespace Exceptions
{
    public class InvalidPlateException : Exception
    {
        public InvalidPlateException()
        {
        }

        public InvalidPlateException(string message) : base(message)
        {
        }

        public InvalidPlateException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}