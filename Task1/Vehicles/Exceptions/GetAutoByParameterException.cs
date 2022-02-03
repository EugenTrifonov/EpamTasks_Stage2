using System;

namespace Vehicles.Exceptions
{
    public class GetAutoByParameterException : Exception
    {
        public GetAutoByParameterException(string parameter) : base($"Parameter {parameter} hasn't been found") { }
    }
}
