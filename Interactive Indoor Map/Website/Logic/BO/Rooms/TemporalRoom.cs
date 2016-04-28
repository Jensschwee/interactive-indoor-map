using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Website.Logic.BO.Utility;

namespace Website.Logic.BO.Temporal
{
    public class TemporalRoom : SensorRoom
    {
        [NotMapped]
        public double AverageTemperature { get; set; }
        public double MaxObservedTemperature { get; set; }
        public double MinObservedTemperature { get; set; }

        [NotMapped]
        public double AverageCO2 { get; set; }
        public double MaxObservedCO2 { get; set; }
        public double MinObservedCO2 { get; set; }

        [NotMapped]
        public double AverageLight { get; set; }
        public double MaxObservedLight = 1;
        public double MinObservedLight = 0;

        [NotMapped]
        public double AverageLumen { get; set; }
        public double MaxObservedLumen { get; set; }
        public double MinObservedLumen { get; set; }

        [NotMapped]
        public double AverageHardwareConsumption { get; set; }
        public double MaxObservedHardwareConsumption { get; set; }
        public double MinObservedHardwareConsumption { get; set; }

        [NotMapped]
        public double AverageLightConsumption { get; set; }
        public double MaxObservedLightConsumption { get; set; }
        public double MinObservedLightConsumption { get; set; }

        [NotMapped]
        public double AverageVentilationConsumption { get; set; }
        public double MaxObservedVentilationConsumption { get; set; }
        public double MinObservedVentilationConsumption { get; set; }

        [NotMapped]
        public double AverageOtherConsumption { get; set; }
        public double MaxObservedOtherConsumption { get; set; }
        public double MinObservedOtherConsumption { get; set; }

        [NotMapped]
        public double AverageTotalPowerConsumption => AverageVentilationConsumption + AverageLightConsumption + AverageHardwareConsumption + AverageOtherConsumption;
        public double MaxObservedTotalPowerConsumption => MaxObservedVentilationConsumption + MaxObservedLightConsumption + MaxObservedHardwareConsumption + MaxObservedOtherConsumption;
        public double MinObservedTotalPowerConsumption => MinObservedVentilationConsumption + MinObservedLightConsumption + MinObservedHardwareConsumption + MinObservedOtherConsumption;

        [NotMapped]
        public double AverageMotion { get; set; }
        public double MaxObservedMotion = 1;
        public double MinObservedMotion = 0;

        [NotMapped]
        public double AverageOccupants { get; set; }
        public double MaxObservedOccupants { get; set; }
        public double MinObservedOccupants { get; set; }

        [NotMapped]
        public double AverageWifiClients { get; set; }
        public double MaxObservedWifiClients { get; set; }
        public double MinObservedWifiClients { get; set; }

        public TemporalRoom() { }

        public TemporalRoom(string name, Corners corners)
        {
            Name = name;
            Corners = corners;
            RoomType = RoomType.Classroom;
        }
    }
}