using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Base;

namespace Task5.Utilities
{
    public class ConfigurationCreator
    {
        private static readonly string _numberOfInstances = DataReeder.GetDataFromJsonByKey("testdata.numberOfInstances");

        private static readonly string _operatingSystem = DataReeder.GetDataFromJsonByKey("testdata.operatingSystem");

        private static readonly string _machineClass = DataReeder.GetDataFromJsonByKey("testdata.machineClass");

        private static readonly string _machineSeries = DataReeder.GetDataFromJsonByKey("testdata.machineSeries");

        private static readonly string _machineType = DataReeder.GetDataFromJsonByKey("testdata.machineType");

        private static readonly string _gPU = DataReeder.GetDataFromJsonByKey("testdata.GPU");

        private static readonly string _gPUAmount = DataReeder.GetDataFromJsonByKey("testdata.GPUAmount");

        private static readonly string _localSSD = DataReeder.GetDataFromJsonByKey("testdata.localSSD");

        private static readonly string _dataCenterLocation = DataReeder.GetDataFromJsonByKey("testdata.DataCenterLocation");

        public static Configuration FullConfiguration() 
        {
            return new Configuration()
            {
                NumberOfInstances = _numberOfInstances,
                OperatingSystem = _operatingSystem,
                MachineClass = _machineClass,
                MachineSeries = _machineSeries,
                MachineType=_machineType,
                GPU=_gPU,
                GPUAmount=_gPUAmount,
                LocalSSD=_localSSD,
                DataCenterLocation=_dataCenterLocation
            };
        
        }
    }
}
