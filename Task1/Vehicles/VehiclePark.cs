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

        /// <summary>
        /// Check for vehicle with such id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckId(int id)
        {
            return VehicleList.Select(x => x.Id).Contains(id);
        }

        /// <summary>
        /// Add new vehicle to the list
        /// </summary>
        /// <param name="vehicle"></param>
        public void AddVehicle(Vehicle vehicle)
        {
            if (!CheckId(vehicle.Id))
            {
                VehicleList.Add(vehicle);
            }

            else throw new AddAutoException(vehicle.Id);
        }

        /// <summary>
        /// Get all parameters of vehicles in list
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllParameters()
        {
            return VehicleList.SelectMany(x => x.GetType().GetProperties()).Select(x => x.Name).Distinct().ToList();
        }

        /// <summary>
        /// Get vehicles by parameter name and it's value
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<Vehicle> GetAutoByParameter(string parameter, string value)
        {
            if (!GetAllParameters().Contains(parameter))
            {
                throw new GetAutoByParameterException(parameter);
            }

            List<Vehicle> selectedVehicles = new List<Vehicle>();

            selectedVehicles = (from vehicle in VehicleList
                                where vehicle.GetType().GetProperty(parameter)?.GetValue(vehicle).ToString() == value
                                select vehicle).ToList();
            
            return selectedVehicles;
        }

        /// <summary>
        /// Update auto with provided id
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="id"></param>
        public void UpdateAuto(Vehicle vehicle, int id)
        {
            if (!CheckId(id))
            {
                throw new UpdateAutoException(id);
            }

            int index = VehicleList.IndexOf(VehicleList.Where(x => x.Id == id).FirstOrDefault());
            VehicleList[index] = vehicle;
        }

        /// <summary>
        /// Delete auto from the list with provided id 
        /// </summary>
        /// <param name="id"></param>
        public void RemoveAuto(int id)
        {
            if (!CheckId(id))
            {
                throw new RemoveAutoException(id);
            }

            VehicleList.Remove(VehicleList.Find(x => x.Id == id));
        }
    }
}