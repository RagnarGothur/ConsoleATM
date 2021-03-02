using System;

namespace ConsoleATM
{
    public class CannotDispenseCashException : Exception
    {
        public CannotDispenseCashException() : base()
        { }

        public CannotDispenseCashException(string message) : base(message)
        { }

        public CannotDispenseCashException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
