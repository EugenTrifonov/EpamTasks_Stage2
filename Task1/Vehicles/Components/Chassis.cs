using System;
using Vehicles.Exceptions;

namespace Vehicles.Components
{
    [Serializable]
    public class Chassis
    {
        private int _number;
        private int _numberOfWheels;
        private double _maxLoad;

        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InitializationException("Number can't be less or equals 0");
                }
                else
                {
                    _number = value;
                }
            }
        }

        public int NumberOfWheels
        {
            get
            {
                return _numberOfWheels;
            }
            set
            {
                if (value < 1)
                {
                    throw new InitializationException("NumberOfWheels can't be less then 1");
                }
                else
                {
                    _numberOfWheels = value;
                }
            }
        }

        public double MaxLoad
        {
            get
            {
                return _maxLoad;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InitializationException("MaxLoad can't be less or equals 0");
                }
                else
                {
                    _maxLoad = value;
                }
            }
        }

        // Empty constructor required for serialization
        public Chassis() { }

        public Chassis(int number, int numberOfWheels, int maxload)
        {
            Number = number;
            NumberOfWheels = numberOfWheels;
            MaxLoad = maxload;
        }

        /// <summary>
        /// Get full info about the Chassis
        /// </summary>
        /// <returns></returns>
        public string GetFullInfo()=> $"Chassis: Number of wheels:{NumberOfWheels} Number:{Number} Max load:{MaxLoad}";
    }
}