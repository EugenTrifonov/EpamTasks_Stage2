using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vehicles.Components;
using Vehicles.Enums;
using Vehicles.Vehicles;

namespace FifthTaskTests
{
    [TestClass]
    public class FifthTaskTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void CreateCarWithoutEngine()
        {
            Vehicle car = new Car(
                null,
                new Chassis(234, 23423, 32432),
                new Transmission(TransmissionType.Automatic, 123, "fdg"), 4);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void CreateCarWithoutChassis()
        {
            Vehicle car = new Car(
                new Engine(EngineType.Diesel, 123, 123, "sdfsd"),
                null,
                new Transmission(TransmissionType.Automatic, 25, "gfdg"), 4);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void CreateCarWithoutTransmission()
        {
            Vehicle car = new Car(
                new Engine(EngineType.Diesel, 123, 123, "sdfsd"),
                new Chassis(234, 23423, 32432),
                null, 2);
        }
    }
}