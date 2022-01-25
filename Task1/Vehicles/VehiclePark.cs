using System;
using System.Collections.Generic;
using System.Linq;
using Vehicles.Exceptions;
using Vehicles.Vehicles;


namespace Vehicles
{
    [Serializable]
    public class VehiclePark
    {
        public List<Vehicle> VehicleList { get; private set; }

        public VehiclePark() => VehicleList = new List<Vehicle>();

        public bool CheckId(int id)
        {
            return VehicleList.Select(x => x.Id).Contains(id);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (!CheckId(vehicle.Id))
            {
                VehicleList.Add(vehicle);
            }

            else throw new AddException($"Vehicle with id {vehicle.Id} already exists");
        }

        public List<string> GetAllParameters()
        {
            return VehicleList.SelectMany(x => x.GetType().GetProperties()).Select(x => x.Name).Distinct().ToList();
        }

        public List<Vehicle> GetAutoByParameter(string parameter, string value)
        {
            if (!GetAllParameters().Contains(parameter))
            {
                throw new GetAutoByParameterException($"Parameter {parameter} hasn't been found");
            }

            List<Vehicle> selectedVehicles = new List<Vehicle>();

            selectedVehicles = (from vehicle in VehicleList
                                where vehicle.GetType().GetProperty(parameter)?.GetValue(vehicle).ToString() == value
                                select vehicle).ToList();
            
            return selectedVehicles;
        }

        public void UpdateAuto(Vehicle vehicle, int id)
        {
            if (!CheckId(id))
            {
                throw new UpdateAutoException($"There is no vehicle with id = {id}");
            }

            int index = VehicleList.IndexOf(VehicleList.Where(x => x.Id == id).FirstOrDefault());
            VehicleList[index] = vehicle;
        }

        public void RemoveAuto(int id)
        {
            if (!CheckId(id))
            {
                throw new RemoveAutoException($"There is no vehicle with id = {id}");
            }

            VehicleList.Remove(VehicleList.Find(x => x.Id == id));
        }
    }
}
