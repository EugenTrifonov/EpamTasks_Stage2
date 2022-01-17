using System;

namespace Vehicles.Exceptions
{
    class GetAutoByParameterException : Exception
    {
        public GetAutoByParameterException(string message) : base(message) { }
    }
}
