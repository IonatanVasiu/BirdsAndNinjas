using System;

namespace BirdsAndNinjas.Exceptions
{
    internal class InvalidMoveException : Exception
    {
        public InvalidMoveException(string message) : base(message)
        {
        }
    }
}