using System;

namespace Vehicles.Exceptions
{
    public class UpdateAutoException : Exception
    {
        public UpdateAutoException(string message) : base(message) { }
    }
}
