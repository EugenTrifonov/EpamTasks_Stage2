using System;

namespace Vehicles.Exceptions
{
    public class AddAutoException : Exception
    {
        public AddAutoException(int id) : base($"Vehicle with id {id} already exists") { }
    }
}
