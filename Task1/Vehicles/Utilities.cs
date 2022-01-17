using System;
using System.Collections.Generic;
using System.Linq;
using Vehicles.Vehicles;
using System.Xml.Serialization;
using System.IO;
using Vehicles.Components;

namespace Vehicles
{
    class Utilities
    {
        /// <summary>
        /// Serialize Vehicle full info  to xml if engine capacity>value
        /// </summary>
        /// <param Vehicles list="list"></param>
        /// <param Value="value"></param>
        public static void SerializeVehiclesFullInfoWithVolumeMoreThen(List<Vehicle> list, double value)
        {
            List<string> result = (from item in list
                                   where item.Engine.Capacity > value
                                   select item.GetFullInfo()).ToList();

            XmlSerializer formatter = new XmlSerializer(typeof(List<string>));
            using (FileStream fileStream = new FileStream("GetVehiclesWithVolumeMoreThen.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, result);
            }
        }

        /// <summary>
        /// Serialize Engine serial number,type,capacity to xml
        /// </summary>
        /// <param Vehicles list="list"></param>
        public static void SerializeEngineTypeNumberCapacityForTruckBus(List<Vehicle> list)
        {
                List<Helper> result = (from item in list
                         where item.GetType() == typeof(Bus) || item.GetType() == typeof(Truck)
                         select new Helper{ Type = item.Engine.Type, SerialNumber = item.Engine.SerialNumber, Capacity = item.Engine.Capacity }).ToList();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Helper>));
            using (FileStream fileStream = new FileStream("GetEngineTypeNumberCapacityForTruckBus.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, result);
            }

        }
        
        /// <summary>
        /// Serialize Vehicles to xml and group by transmission type
        /// </summary>
        /// <param Vehicles list="list"></param>
        public static void SerializeVehiclesFullInfoGroupByTransmissionType(List<Vehicle> list)
        {
            List<string> result = (from item in list
                                   group item by item.Transmission.Type into groups
                                   from items in groups.ToList()
                                   select items.GetFullInfo()).ToList();
            XmlSerializer formatter = new XmlSerializer(typeof(List <string>));
            using (FileStream fileStream = new FileStream("GetVehiclesGroupByTransmissionType.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, result);
            }
        }
    }
}