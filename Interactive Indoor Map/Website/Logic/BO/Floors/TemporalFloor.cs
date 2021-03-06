﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Website.Logic.BO.Rooms;

namespace Website.Logic.BO.Floors
{
    [NotMapped]
    public class TemporalFloor : Floor
    {

        public override List<Room> Rooms { get; set; }

        public double AverageTemperature =>
                (Rooms.Where(room => room.GetType() == typeof(TemporalRoom))
                    .Cast<TemporalRoom>()
                    .Sum(room => room.AverageTemperature) / NumberOfSensorRooms);

        public double MaxObservedTemperature =>
            (Rooms.Where(room => room.GetType() == typeof (TemporalRoom))
                .Cast<TemporalRoom>()
                .Max(room => room.MaxObservedTemperature));
        public double MinObservedTemperature => (Rooms.Where(room => room.GetType() == typeof(TemporalRoom))
                .Cast<TemporalRoom>()
                .Min(room => room.MinObservedTemperature));

        public double AverageCO2 =>
                (Rooms.Where(room => room.GetType() == typeof(TemporalRoom))
                    .Cast<TemporalRoom>()
                    .Sum(room => room.AverageCO2) / NumberOfSensorRooms);
        public double MaxObservedCO2 =>
            (Rooms.Where(room => room.GetType() == typeof(TemporalRoom))
                .Cast<TemporalRoom>()
                .Max(room => room.MaxObservedCO2));
        public double MinObservedCO2 => (Rooms.Where(room => room.GetType() == typeof(TemporalRoom))
                .Cast<TemporalRoom>()
                .Min(room => room.MinObservedCO2));

        public double AverageLight =>
                (Rooms.Where(room => room.GetType() == typeof(TemporalRoom))
                    .Cast<TemporalRoom>()
                    .Sum(room => room.AverageLight) / NumberOfSensorRooms);
        public double MaxObservedLight = 1;
        public double MinObservedLight = 0;

        public double AverageLux =>
                (Rooms.Where(room => room.GetType() == typeof(TemporalRoom))
                    .Cast<TemporalRoom>()
                    .Sum(room => room.AverageLux) / NumberOfSensorRooms);
        public double MaxObservedLux => (Rooms.Where(room => room.GetType() == typeof(TemporalRoom))
                .Cast<TemporalRoom>()
                .Max(room => room.MaxObservedLux));
        public double MinObservedLux => (Rooms.Where(room => room.GetType() == typeof(TemporalRoom))
                .Cast<TemporalRoom>()
                .Min(room => room.MinObservedLux));

        public double AverageHardwareConsumption { get; set; }
        public double MaxObservedHardwareConsumption { get; set; }
        public double MinObservedHardwareConsumption { get; set; }

        public double AverageLightConsumption { get; set; }
        public double MaxObservedLightConsumption { get; set; }
        public double MinObservedLightConsumption { get; set; }

        public double AverageVentilationConsumption { get; set; }
        public double MaxObservedVentilationConsumption { get; set; }
        public double MinObservedVentilationConsumption { get; set; }

        public double AverageOtherConsumption { get; set; }
        public double MaxObservedOtherConsumption { get; set; }
        public double MinObservedOtherConsumption { get; set; }

        public double AverageTotalPowerConsumption { get; set; }
        public double MaxObservedTotalPowerConsumption { get; set; }
        public double MinObservedTotalPowerConsumption { get; set; }

        public double AverageMotion =>
                (Rooms.Where(room => room.GetType() == typeof(TemporalRoom))
                    .Cast<TemporalRoom>()
                    .Sum(room => room.AverageMotion) / NumberOfSensorRooms);
        public double MaxObservedMotion = 1;
        public double MinObservedMotion = 0;

        public double AverageOccupants =>
                (Rooms.Where(room => room.GetType() == typeof(TemporalRoom))
                    .Cast<TemporalRoom>()
                    .Sum(room => room.AverageOccupants));
        public double MaxObservedOccupants =>
                (Rooms.Where(room => room.GetType() == typeof(TemporalRoom))
                    .Cast<TemporalRoom>()
                    .Sum(room => room.MaxObservedOccupants));
        public double MinObservedOccupants =>
                (Rooms.Where(room => room.GetType() == typeof(TemporalRoom))
                    .Cast<TemporalRoom>()
                    .Sum(room => room.MinObservedOccupants));

        public double AverageWifiClients { get; set; }
        public double MaxObservedWifiClients { get; set; }
        public double MinObservedWifiClients { get; set; }

        public double AverageHotWaterConsumption { get; set; }

        public double MaxObservedHotWaterConsumption { get; set; }

        public double MinObservedHotWaterConsumption { get; set; }

        public double AverageColdWaterConsumption { get; set; }

        public double MaxObservedColdWaterConsumption { get; set; }

        public double MinObservedColdWaterConsumption { get; set; }

        public TemporalFloor()
        {
            Rooms = new List<Room>();
        }

        public TemporalFloor(int floorLevel) : this()
        {
            FloorLevel = floorLevel;
        }

        public static explicit operator TemporalFloor(LiveFloor floor)
        {
                TemporalFloor temporalFloor = new TemporalFloor
                {
                    Id = floor.Id,
                    FloorName = floor.FloorName,
                    FloorLevel = floor.FloorLevel,
                    Endpoints = floor.Endpoints,
                    Rooms = floor.Rooms.ToList(),
                    SurfaceArea = floor.SurfaceArea,
                    MinColdWaterConsumption = floor.MinColdWaterConsumption,
                    MaxColdWaterConsumption = floor.MaxColdWaterConsumption,
                    MinHotWaterConsumption = floor.MinHotWaterConsumption,
                    MaxHotWaterConsumption = floor.MaxHotWaterConsumption,
                    MinOtherConsumption = floor.MinOtherConsumption,
                    MaxOtherConsumption = floor.MaxOtherConsumption,
                    MinVentilationConsumption = floor.MinVentilationConsumption,
                    MaxVentilationConsumption = floor.MaxVentilationConsumption,
                    MinLightConsumption = floor.MinLightConsumption,
                    MaxLightConsumption = floor.MaxLightConsumption,
                    MinHardwareConsumption = floor.MinHardwareConsumption,
                    MaxHardwareConsumption = floor.MaxHardwareConsumption,
                    MinLux = floor.MinLux
                };
                return temporalFloor;
        }
    }
}