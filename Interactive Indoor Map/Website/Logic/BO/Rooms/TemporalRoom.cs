using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Website.Logic.BO.Utility;

namespace Website.Logic.BO.Rooms
{
    [NotMapped]
    public class TemporalRoom : SensorRoom
    {
        public double AverageTemperature { get; set; }
        public double MaxObservedTemperature { get; set; }
        public double MinObservedTemperature { get; set; }

        public double AverageCO2 { get; set; }
        public double MaxObservedCO2 { get; set; }
        public double MinObservedCO2 { get; set; }

        public double AverageLight { get; set; }
        public double MaxObservedLight = 1;
        public double MinObservedLight = 0;

        public double AverageLumen { get; set; }
        public double MaxObservedLumen { get; set; }
        public double MinObservedLumen { get; set; }

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

        public double AverageTotalPowerConsumption => AverageVentilationConsumption + AverageLightConsumption + AverageHardwareConsumption + AverageOtherConsumption;
        public double MaxObservedTotalPowerConsumption => MaxObservedVentilationConsumption + MaxObservedLightConsumption + MaxObservedHardwareConsumption + MaxObservedOtherConsumption;
        public double MinObservedTotalPowerConsumption => MinObservedVentilationConsumption + MinObservedLightConsumption + MinObservedHardwareConsumption + MinObservedOtherConsumption;

        public double AverageMotion { get; set; }
        public double MaxObservedMotion = 1;
        public double MinObservedMotion = 0;

        public double AverageOccupants { get; set; }
        public double MaxObservedOccupants { get; set; }
        public double MinObservedOccupants { get; set; }

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

        public static explicit operator TemporalRoom(LiveRoom room)
        {
                TemporalRoom temporalRoom = new TemporalRoom();
                temporalRoom.Id = room.Id;
                temporalRoom.Name = room.Name;
                temporalRoom.Alias = room.Alias;
                temporalRoom.Endpoints = room.Endpoints;
                temporalRoom.SurfaceArea = room.SurfaceArea;
                temporalRoom.RoomType = room.RoomType;
                temporalRoom.Corners = room.Corners;
                temporalRoom.MaxTemperature = room.MaxTemperature;
                temporalRoom.MinTemperature = room.MinTemperature;
                temporalRoom.MaxCO2 = room.MaxCO2;
                temporalRoom.MinCO2 = room.MinCO2;
                temporalRoom.MinOtherConsumption = room.MinOtherConsumption;
                temporalRoom.MaxOtherConsumption = room.MaxOtherConsumption;
                temporalRoom.MaxLumen = room.MaxLumen;
                temporalRoom.MaxLumen = room.MaxLumen;

                temporalRoom.MaxHardwareConsumption = room.MaxHardwareConsumption;
                temporalRoom.MinHardwareConsumption = room.MinHardwareConsumption;

                temporalRoom.MaxLightConsumption = room.MaxLightConsumption;
                temporalRoom.MinLightConsumption = room.MinLightConsumption;

                temporalRoom.MaxVentilationConsumption = room.MaxVentilationConsumption;
                temporalRoom.MinVentilationConsumption = room.MinVentilationConsumption;

                temporalRoom.MaxOtherConsumption = room.MaxOtherConsumption;
                temporalRoom.MinOtherConsumption = room.MinOtherConsumption;

                temporalRoom.MaxOccupants = room.MaxOccupants;
                temporalRoom.MinOccupants = room.MinOccupants;

                temporalRoom.MaxWifiClients = room.MaxWifiClients;
                temporalRoom.MinWifiClients = room.MinWifiClients;

                temporalRoom.MinLumen = room.MinLumen;

                return temporalRoom;
        }
    }
}