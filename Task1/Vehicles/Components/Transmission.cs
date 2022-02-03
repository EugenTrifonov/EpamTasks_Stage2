using System;
using Vehicles.Enums;
using Vehicles.Exceptions;

namespace Vehicles.Components
{
    [Serializable]
    public class Transmission
    {
        private int _numberOfGears;
        private string _manufacturer;

        public TransmissionType Type { get; set; }

        public int NumberOfGears
        {
            get
            {
                return _numberOfGears;
            }
            set
            {
                if (value < 1)
                {
                    throw new InitializationException(" The number of gears can't be less then 1");
                }
                else
                {
                    _numberOfGears = value;
                }
            }
        }

        public string Manufacturer
        {
            get
            {
                return _manufacturer;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new InitializationException("MaxLoad can't be less or equals 0");
                }
                else
                {
                    _manufacturer = value;
                }
            }
        }

        // Empty constructor required for serialization
        public Transmission() { }

        public Transmission(TransmissionType type, int numberOfGears, string manufacturer)
        {
            Type = type;
            NumberOfGears = numberOfGears;
            Manufacturer = manufacturer;
        }

        public string GetFullInfo()=> $"Transmisssion: Type:{Type} Number of gears:{NumberOfGears} Manufacturer:{Manufacturer}";
    }
}