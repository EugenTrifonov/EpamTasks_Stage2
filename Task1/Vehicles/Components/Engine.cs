using System;
using Vehicles.Enums;
using Vehicles.Exceptions;

namespace Vehicles.Components
{
    [Serializable]
    public class Engine
    {
        private int _power;
        private string _serialNumber;
        private double _capacity;

        public EngineType Type { get; set; }

        public int Power
        {
            get
            {
                return _power;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InitializationException("Power cannot be less or equals 0");
                }
                else
                {
                    _power = value;
                }
            }
        }

        public string SerialNumber
        {
            get
            {
                return _serialNumber;
            }
            set
            {
                if (value == String.Empty)
                {
                    throw new InitializationException("Empty serial number");
                }
                else
                {
                    _serialNumber = value;
                }
            }
        }

        public double Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InitializationException("Capacity can't be less or equals 0");
                }
                else
                { 
                    _capacity = value;
                    }
            }
        }

        // Empty constructor required for serialization
        public Engine() { }

        public Engine(EngineType type, int power, double capacity, string serialNumber)
        {
            Type = type;
            Power = power;
            Capacity = capacity;
            SerialNumber = serialNumber;
        }

        /// <summary>
        /// Get full info about the Engine
        /// </summary>
        /// <returns></returns>
        public string GetFullInfo()=> $"Engine: Type:{Type} Power:{Power} Capacity:{Capacity} Serial number:{SerialNumber}";
    }
}