using System;

namespace Vehicles.Exceptions
{
    public class InitializationException : Exception
    {
        public InitializationException(string message) : base(message) { }
    }
}
