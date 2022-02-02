using System;

namespace Vehicles.Exceptions
{
    public class RemoveAutoException : Exception
    {
        public RemoveAutoException(int id) : base($"There is no vehicle with id = {id}") { }
    }
}
