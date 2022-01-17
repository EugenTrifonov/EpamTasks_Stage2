using System;

namespace Vehicles.Exceptions
{
    class UpdateAutoException : Exception
    {
        public UpdateAutoException(string message) : base(message) { }
    }
}
