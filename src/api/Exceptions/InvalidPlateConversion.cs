using System;

namespace Exceptions
{
    public class InvalidPlateConversion : Exception
    {
        public InvalidPlateConversion()
        {
        }

        public InvalidPlateConversion(string message) : base(message)
        {
        }

        public InvalidPlateConversion(string message, Exception inner) : base(message, inner)
        {
        }
    }
}