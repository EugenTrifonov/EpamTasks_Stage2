using System;

namespace Vehicles.Exceptions
{
    public class GetAutoByParameterException : Exception
    {
        public GetAutoByParameterException(string message) : base(message) { }
    }
}
