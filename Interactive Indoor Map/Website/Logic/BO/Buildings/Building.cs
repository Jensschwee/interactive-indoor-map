﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Website.Logic.BO.Floors;
using Website.Logic.BO.Rooms;
using Website.Logic.BO.Utility;

namespace Website.Logic.BO
{
    public abstract class Building
    {
        public List<Floor> Floors { get; set; }

        public Endpoints Endpoints { get; set; }

        [Key]
        public string Name { get; set; }

        [NotMapped]
        public double SurfaceArea => Floors.Sum(floor => floor.SurfaceArea);

        [NotMapped]
        public double NumberOfRooms => Floors.Sum(floor => floor.Rooms.Count);

        [NotMapped]
        public double NumberOfSensorRooms => Floors.Sum(floor => floor.NumberOfSensorRooms);

        [NotMapped]
        public double MaxTemperature => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>().Sum(room => room.MaxTemperature)) / NumberOfSensorRooms);

        [NotMapped]
        public double MaxCO2 => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>().Sum(room => room.MaxCO2)) / NumberOfSensorRooms);
        
        [NotMapped]
        public double MaxLux => (Floors.Sum(floor => floor.Rooms.Where(room => room.GetType() == typeof(LiveRoom)).Cast<LiveRoom>().Sum(room => room.MaxLux)) / NumberOfSensorRooms);
        
        [NotMapped]
        public double MaxHardwareConsumption => Floors.Sum(floor => floor.MaxHardwareConsumption);

        [NotMapped]
        public double MinHardwareConsumption => Floors.Sum(floor => floor.MinHardwareConsumption);

        [NotMapped]
        public double MaxLightConsumption => Floors.Sum(floor => floor.MaxLightConsumption);

        [NotMapped]
        public double MinLightConsumption => Floors.Sum(floor => floor.MinLightConsumption);

        [NotMapped]
        public double MaxOtherConsumption => Floors.Sum(floor => floor.MaxOtherConsumption);

        [NotMapped]
        public double MinOtherConsumption => Floors.Sum(floor => floor.MinOtherConsumption);
        
        [NotMapped]
        public double MaxVentilationConsumption => Floors.Sum(floor => floor.MaxVentilationConsumption);

        [NotMapped]
        public double   MinVentilationConsumption => Floors.Sum(floor => floor.MinVentilationConsumption);
        
        [NotMapped]
        public double MaxTotalPowerConsumption => Floors.Sum(floor => floor.MaxTotalPowerConsumption);

        [NotMapped]
        public double MinTotalPowerConsumption => Floors.Sum(floor => floor.MinTotalPowerConsumption);


        public int MaxOccupants { get; set; }
        
        [NotMapped]
        public int MaxWifiClients => Floors.Sum(floor => floor.MaxWifiClients);

        [NotMapped]
        public double MaxHotWaterConsumption => Floors.Sum(floor => floor.MaxHotWaterConsumption);

        [NotMapped]
        public double MinHotWaterConsumption => Floors.Sum(floor => floor.MinHotWaterConsumption);

        [NotMapped]
        public double MaxColdWaterConsumption => Floors.Sum(floor => floor.MaxColdWaterConsumption);

        [NotMapped]
        public double MinColdWaterConsumption => Floors.Sum(floor => floor.MinColdWaterConsumption);
    }
}