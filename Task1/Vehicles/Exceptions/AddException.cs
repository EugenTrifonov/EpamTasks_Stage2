using System;

namespace Vehicles.Exceptions
{
    public class AddException : Exception
    {
        public AddException(string message) : base(message) { }
    }
}
