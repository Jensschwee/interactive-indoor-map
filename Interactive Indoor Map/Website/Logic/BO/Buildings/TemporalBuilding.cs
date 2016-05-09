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
        public double AverageTemperature => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.AverageTemperature)) / NumberOfSensorRooms);
        public double MaxObservedTemperature => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.MaxObservedTemperature)) / NumberOfSensorRooms);
        public double MinObservedTemperature => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.MinObservedTemperature)) / NumberOfSensorRooms);

        public double AverageCO2 => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.AverageCO2)) / NumberOfSensorRooms);
        public double MaxObservedCO2 => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.MaxObservedCO2)) / NumberOfSensorRooms);
        public double MinObservedCO2 => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.MinObservedCO2)) / NumberOfSensorRooms);

        public double AverageLight => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.AverageLux)) / NumberOfSensorRooms);
        public double MaxObservedLight = 1;
        public double MinObservedLight = 0;

        public double AverageLux => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.AverageLux)) / NumberOfSensorRooms);
        public double MaxObservedLux => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.MaxObservedLux)) / NumberOfSensorRooms);
        public double MinObservedLux => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.MinObservedLux)) / NumberOfSensorRooms);

        public double AverageHardwareConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.AverageHardwareConsumption);
        public double MaxObservedHardwareConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MaxObservedHardwareConsumption);
        public double MinObservedHardwareConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MinObservedHardwareConsumption);

        public double AverageLightConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.AverageLightConsumption);
        public double MaxObservedLightConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MaxObservedLightConsumption);
        public double MinObservedLightConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MinObservedTemperature);

        public double AverageVentilationConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.AverageVentilationConsumption);
        public double MaxObservedVentilationConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MaxObservedVentilationConsumption);
        public double MinObservedVentilationConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MinObservedVentilationConsumption);

        public double AverageOtherConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.AverageOtherConsumption);
        public double MaxObservedOtherConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MaxObservedOtherConsumption);
        public double MinObservedOtherConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MinObservedOtherConsumption);

        public double AverageTotalPowerConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.AverageTotalPowerConsumption);
        public double MaxObservedTotalPowerConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MaxObservedTotalPowerConsumption);
        public double MinObservedTotalPowerConsumption => Floors.Where(floor => floor.GetType() == typeof(TemporalFloor)).Cast<TemporalFloor>().Sum(floor => floor.MinObservedTotalPowerConsumption);

        public double AverageMotion => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.AverageMotion)) / NumberOfSensorRooms);
        public double MaxObservedMotion = 1;
        public double MinObservedMotion = 0;

        public double AverageOccupants { get; set; }
        public double MaxObservedOccupants { get; set; }
        public double MinObservedOccupants { get; set; }

        public double AverageWifiClients => Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.AverageWifiClients));
        public double MaxObservedWifiClients => Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.MaxObservedWifiClients));
        public double MinObservedWifiClients => Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(TemporalRoom)).Cast<TemporalRoom>().Sum(room => room.MinObservedWifiClients));

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