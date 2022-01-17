using System;
using Vehicles.Components;
using Vehicles.Exceptions;

namespace Vehicles.Vehicles
{
    [Serializable]
    public class Truck : Vehicle
    {
        private int _maxLoad;
        public int MaxLoad
        {
            get
            {
                return _maxLoad;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InitializationException("MaxLoad cannot be less or equals 0");
                }
                else
                {
                    _maxLoad = value;
                }
            }
        }

        // Empty constructor required for serialization
        public Truck() { }

        public Truck(Engine engine, Chassis chassis, Transmission transmission, int maxLoad) : base(engine, chassis, transmission)
        {
            MaxLoad = maxLoad;
        }

        /// <summary>
        /// Get full info about the Truck
        /// </summary>
        /// <returns></returns>
        public override string GetFullInfo() => base.GetFullInfo() + $"\nMaxLoad: {MaxLoad}\n";
    }
}