using System;
using System.Xml.Serialization;
using Vehicles.Components;

namespace Vehicles.Vehicles
{
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Scooter))]
    [XmlInclude(typeof(Truck))]
    [Serializable]
    public abstract class Vehicle
    {
        public static int id = 0;

        public int Id { get; set; }

        public Engine Engine { get; set; }

        public Transmission Transmission { get; set; }

        public Chassis Chassis { get; set; }

        // Empty constructor required for serialization
        public Vehicle() { }

        public Vehicle(Engine engine, Chassis chassis, Transmission transmission)
        {
            Engine = engine ?? throw new Exception("The vehicle needs an engine");
            Chassis = chassis ?? throw new Exception("The vehicle needs a chassis");
            Transmission = transmission ?? throw new Exception("The vehicle needs a transmission");
            Id = id++;
        }

        /// <summary>
        /// Get full info about the Vehicle
        /// </summary>
        /// <returns></returns>
        public virtual string GetFullInfo() => $"{Engine.GetFullInfo()}\n {Chassis.GetFullInfo()}\n {Transmission.GetFullInfo()}";
    }
}