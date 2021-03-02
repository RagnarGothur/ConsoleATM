using System;

namespace ConsoleATM
{
    public class AtmException : Exception
    {
        public AtmException() : base()
        { }

        public AtmException(string message) : base(message)
        { }

        public AtmException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
