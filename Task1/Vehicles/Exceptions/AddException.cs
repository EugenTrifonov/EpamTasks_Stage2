using System;

namespace Vehicles.Exceptions
{
    class AddException : Exception
    {
        public AddException(string message) : base(message) { }
    }
}
