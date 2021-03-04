using System;

namespace ConsoleATM
{
    /// <summary>
    /// Ошибка при операциях банкомата
    /// </summary>
    public class AtmException : Exception
    {
        /// <summary>
        /// .ctor
        /// </summary>
        public AtmException() : base()
        { }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="message"></param>
        public AtmException(string message) : base(message)
        { }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public AtmException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
