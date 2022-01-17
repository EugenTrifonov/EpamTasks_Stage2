using System;

namespace Vehicles.Exceptions
{
    class RemoveAutoException : Exception
    {
        public RemoveAutoException(string message) : base(message) { }
    }
}
