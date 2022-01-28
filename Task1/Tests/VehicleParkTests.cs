using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Vehicles;
using Vehicles.Components;
using Vehicles.Enums;
using Vehicles.Exceptions;
using Vehicles.Vehicles;

namespace Tests
{
    [TestClass]
    public class VehicleParkTests
    {
        private static VehiclePark _park;
        private static Vehicle _testcar;

        [TestInitialize]
        public void TestInitialization()
        {
            _park = new VehiclePark();

            _testcar = new Car(
                     new Engine(EngineType.Petrol, 500, 1.7, "5BSDR"),
                     new Chassis(4, 4, 50),
                     new Transmission(TransmissionType.Automatic, 7, "KGD43"),
                     1500);
        }

        [TestMethod]
        public void PositiveAddTest()
        {
            _park.AddVehicle(_testcar);

            Assert.AreEqual(1, _park.VehicleList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(AddException))]
        public void NegativeAddTest()
        {
            _park.AddVehicle(_testcar);
            _park.AddVehicle(_testcar);
        }

        [TestMethod]
        public void PositiveRemoveTest() 
        {
            _park.AddVehicle(_testcar);
            _park.RemoveAuto(_testcar.Id);

            Assert.AreEqual(0,_park.VehicleList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(RemoveAutoException))]
        public void NegativeRemoveTest()
        {
            _park.RemoveAuto(4);
        }

        [TestMethod]
        public void PositiveGetAutoByParameterTest()
        {
            Vehicle testBus = new Bus(
                    new Engine(EngineType.Diesel, 300, 2.5, "A1C83"),
                    new Chassis(4, 4, 50),
                    new Transmission(TransmissionType.Mechanic, 7, "FDBGF4"),
                    20);

            _park.AddVehicle(_testcar);
            _park.AddVehicle(testBus);

            List<Vehicle> selectedVehicles = new List<Vehicle>(_park.GetAutoByParameter("NumberOfSeats", "20"));

            Assert.AreEqual(1, selectedVehicles.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(GetAutoByParameterException))]
        public void NegativeGetAutoByParameterTest()
        {
            _park.AddVehicle(_testcar);
            _park.GetAutoByParameter("NumberOfSeats", "20");
        }

        [TestMethod]
        public void PositiveUpdateAutoTest()
        {
            Vehicle testBus = new Bus(
                new Engine(EngineType.Diesel, 300, 2.5, "A1C83"),
                new Chassis(4, 4, 50),
                new Transmission(TransmissionType.Mechanic, 7, "FDBGF4"),
                 20);

            _park.AddVehicle(_testcar);
            _park.UpdateAuto(testBus, _testcar.Id);

            Assert.AreEqual(1,_park.VehicleList.Count);
            Assert.AreNotEqual(_testcar.Id,_park.VehicleList[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(UpdateAutoException))]
        public void NegativeUpdateAutoTest()
        {
            _park.UpdateAuto(_testcar,4);
        }
    }
}
