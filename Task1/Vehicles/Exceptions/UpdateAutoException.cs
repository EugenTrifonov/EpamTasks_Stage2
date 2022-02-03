using System;

namespace Vehicles.Exceptions
{
    public class UpdateAutoException : Exception
    {
        public UpdateAutoException(int id) : base($"There is no vehicle with id = {id}") { }
    }
}
