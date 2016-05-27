using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Website.Logic.BO;
using Website.Logic.BO.Floors;
using Website.Logic.BO.Rooms;

namespace Website.Logic.BO.Buildings
{ 

    [NotMapped]
    public class TemporalBuilding : Building
    {
        public int NumberOfTemperatureRooms => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Sum(f =>((TemporalFloor)f).NumberOfTemperatureRooms);

        public double AverageTemperature => (Floors
            .Sum(floor => floor.Rooms
            .Where(room => room.GetType() == typeof(TemporalRoom))
            .Cast<TemporalRoom>()
            .Sum(room => room.AverageTemperature ?? 0.0)) / (NumberOfTemperatureRooms.Equals(0) ? 1 : NumberOfTemperatureRooms));
        public double MaxObservedTemperature => (Floors
            .Where(floor => floor.GetType() == typeof(TemporalFloor))
            .Cast<TemporalFloor>()
            .Max(f => f.MaxObservedTemperature));
        public double MinObservedTemperature => (Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Min(f => f.MinObservedTemperature));

        public int NumberOfCO2Rooms => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Sum(f => ((TemporalFloor)f).NumberOfCO2Rooms);

        public double AverageCO2 => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.AverageCO2 ?? 0.0)) / (NumberOfCO2Rooms.Equals(0) ? 1 : NumberOfCO2Rooms));
        public double MaxObservedCO2 => (Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Max(f => f.MaxObservedCO2));
        public double MinObservedCO2 => (Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Min(f => f.MinObservedCO2));

        public int NumberOfLightRooms => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Sum(f => ((TemporalFloor)f).NumberOfLightRooms);

        public double AverageLight => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.AverageLight ?? 0.0)) / (NumberOfLightRooms.Equals(0) ? 1 : NumberOfLightRooms));
        public double MaxObservedLight = 1;
        public double MinObservedLight = 0;

        public int NumberOfLuxRooms => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Sum(f => ((TemporalFloor)f).NumberOfLuxRooms);

        public double AverageLux => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.AverageLux ?? 0.0)) / (NumberOfLuxRooms.Equals(0) ? 1 : NumberOfLuxRooms));
        public double MaxObservedLux => (Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Max(f => f.MaxObservedLux));
        public double MinObservedLux => (Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Min(f => f.MinObservedLux));

        public double AverageHardwareConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.AverageHardwareConsumption);
        public double MaxObservedHardwareConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MaxObservedHardwareConsumption);
        public double MinObservedHardwareConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MinObservedHardwareConsumption);

        public double AverageLightConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.AverageLightConsumption);
        public double MaxObservedLightConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MaxObservedLightConsumption);
        public double MinObservedLightConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MinObservedLightConsumption);

        public double AverageVentilationConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.AverageVentilationConsumption);
        public double MaxObservedVentilationConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MaxObservedVentilationConsumption);
        public double MinObservedVentilationConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MinObservedVentilationConsumption);

        public double AverageOtherConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.AverageOtherConsumption);
        public double MaxObservedOtherConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MaxObservedOtherConsumption);
        public double MinObservedOtherConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MinObservedOtherConsumption);

        public double AverageTotalPowerConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.AverageTotalPowerConsumption);
        public double MaxObservedTotalPowerConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MaxObservedTotalPowerConsumption);
        public double MinObservedTotalPowerConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MinObservedTotalPowerConsumption);

        public int NumberOfMotionRooms => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Sum(f => ((TemporalFloor)f).NumberOfMotionRooms);

        public double AverageMotion => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.AverageMotion ?? 0.0)) / NumberOfMotionRooms);
        public double MaxObservedMotion = 1;
        public double MinObservedMotion = 0;

        public double AverageOccupants { get; set; }
        public double MaxObservedOccupants { get; set; }
        public double MinObservedOccupants { get; set; }

        public double AverageWifiClients => Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => (double)room.AverageWifiClients));
        public double MaxObservedWifiClients => Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => (double)room.MaxObservedWifiClients));
        public double MinObservedWifiClients => Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => (double)room.MinObservedWifiClients));

        public double AverageHotWaterConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.AverageHotWaterConsumption);

        public double MaxObservedHotWaterConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MaxObservedHotWaterConsumption);

        public double MinObservedHotWaterConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MinObservedHotWaterConsumption);

        public double AverageColdWaterConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.AverageColdWaterConsumption);

        public double MaxObservedColdWaterConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MaxObservedColdWaterConsumption);

        public double MinObservedColdWaterConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MinObservedColdWaterConsumption);

        public TemporalBuilding()
        {
            Floors = new List<Floor>();
        }

        public static explicit operator TemporalBuilding(LiveBuilding building)
        {
                TemporalBuilding temporalBuilding = new TemporalBuilding
                {
                    Name = building.Name,
                    Floors = building.Floors.ToList(),
                    Endpoints = building.Endpoints,
                    MaxOccupants = building.MaxOccupants
                };
                return temporalBuilding;
        }
    }
}