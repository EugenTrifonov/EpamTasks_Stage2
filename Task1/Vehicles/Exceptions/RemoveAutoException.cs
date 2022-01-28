using System;

namespace Vehicles.Exceptions
{
    public class RemoveAutoException : Exception
    {
        public RemoveAutoException(string message) : base(message) { }
    }
}
