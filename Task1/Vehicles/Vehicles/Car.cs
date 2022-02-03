using System;
using Vehicles.Components;
using Vehicles.Exceptions;

namespace Vehicles.Vehicles
{
    [Serializable]
    public class Car : Vehicle
    {
        private int _weight;

        public int Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InitializationException("Weight cannot be less or equals 0");
                }
                else
                {
                    _weight = value;
                }
            }
        }

        // Empty constructor required for serialization
        public Car() { }

        public Car(Engine engine, Chassis chassis, Transmission transmission, int weight) : base(engine, chassis, transmission)
        {
            Weight = weight;
        }

        /// <summary>
        /// Get full info about the Car
        /// </summary>
        /// <returns></returns>
        public override string GetFullInfo() => base.GetFullInfo() + $"\nWeight: {Weight}\n";
    }
}
