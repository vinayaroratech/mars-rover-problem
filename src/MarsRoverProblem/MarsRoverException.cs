using System;

namespace MarsRoverProblem
{
    public class MarsRoverException : Exception
    {
        public MarsRoverException(string message) : base(message)
        {
        }

        public MarsRoverException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
