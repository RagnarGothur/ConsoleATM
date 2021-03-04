using System;

namespace ConsoleATM
{
    /// <summary>
    /// Ошибка, возникающая при выдаче средств алгоритмом
    /// </summary>
    public class CannotDispenseCashException : Exception
    {
        /// <summary>
        /// .ctor
        /// </summary>
        public CannotDispenseCashException() : base()
        { }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="message"></param>
        public CannotDispenseCashException(string message) : base(message)
        { }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public CannotDispenseCashException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
