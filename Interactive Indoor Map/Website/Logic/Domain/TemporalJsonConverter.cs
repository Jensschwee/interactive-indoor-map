using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Website.Logic.BO.Buildings;
using Website.Logic.BO.Floors;
using Website.Logic.BO.Rooms;

namespace Website.Logic.Domain
{
    public class TemporalJsonConverter : JsonConverter
    {
        public string GetBuildingInfobox(TemporalBuilding building)
        {
            StringBuilder sb = new StringBuilder();
            WriteFirstAttribute(sb, "Name", building.Name);
            WriteAttribute(sb, "SurfaceArea", building.SurfaceArea);
            WriteAttribute(sb, "NumberOfRooms", building.NumberOfSensorRooms);

            WriteAttribute(sb, "AverageTemperature", building.AverageTemperature);
            WriteAttribute(sb, "MaxObservedTemperature", building.MaxObservedTemperature);
            WriteAttribute(sb, "MinObservedTemperature", building.MinObservedTemperature);

            WriteAttribute(sb, "AverageCO2", building.AverageCO2);
            WriteAttribute(sb, "MaxObservedCO2", building.MaxObservedCO2);
            WriteAttribute(sb, "MinObservedCO2", building.MinObservedCO2);

            WriteAttribute(sb, "AverageLight", building.AverageLight);
            WriteAttribute(sb, "MaxObservedLight", building.MaxObservedLight);
            WriteAttribute(sb, "MinObservedLight", building.MinObservedLight);

            WriteAttribute(sb, "AverageLux", building.AverageLux);
            WriteAttribute(sb, "MaxObservedLux", building.MaxObservedLux);
            WriteAttribute(sb, "MinObservedLux", building.MinObservedLux);

            WriteAttribute(sb, "AverageHardwareConsumption", building.AverageHardwareConsumption);
            WriteAttribute(sb, "MaxObservedHardwareConsumption", building.MaxObservedHardwareConsumption);
            WriteAttribute(sb, "MinObservedHardwareConsumption", building.MinObservedHardwareConsumption);

            WriteAttribute(sb, "AverageLightConsumption", building.AverageLightConsumption);
            WriteAttribute(sb, "MaxObservedLightConsumption", building.MaxObservedLightConsumption);
            WriteAttribute(sb, "MinObservedLightConsumption", building.MinObservedLightConsumption);

            WriteAttribute(sb, "AverageVentilationConsumption", building.AverageVentilationConsumption);
            WriteAttribute(sb, "MaxObservedVentilationConsumption", building.MaxObservedVentilationConsumption);
            WriteAttribute(sb, "MinObservedVentilationConsumption", building.MinObservedVentilationConsumption);

            WriteAttribute(sb, "AverageOtherConsumption", building.AverageOtherConsumption);
            WriteAttribute(sb, "MaxObservedOtherConsumption", building.MaxObservedOtherConsumption);
            WriteAttribute(sb, "MinObservedOtherConsumption", building.MinObservedOtherConsumption);

            WriteAttribute(sb, "AverageTotalPowerConsumption", building.AverageTotalPowerConsumption);
            WriteAttribute(sb, "MaxObservedTotalPowerConsumption", building.MaxObservedTotalPowerConsumption);
            WriteAttribute(sb, "MinObservedTotalPowerConsumption", building.MinObservedTotalPowerConsumption);

            WriteAttribute(sb, "AverageColdWaterConsumption", building.AverageColdWaterConsumption);
            WriteAttribute(sb, "MaxObservedColdWaterConsumption", building.MaxObservedColdWaterConsumption);
            WriteAttribute(sb, "MinObservedColdWaterConsumption", building.MinObservedColdWaterConsumption);

            WriteAttribute(sb, "AverageHotWaterConsumption", building.AverageHotWaterConsumption);
            WriteAttribute(sb, "MaxObservedHotWaterConsumption", building.MaxObservedHotWaterConsumption);
            WriteAttribute(sb, "MinObservedHotWaterConsumption", building.MinObservedHotWaterConsumption);

            WriteAttribute(sb, "AverageMotion", building.AverageMotion);
            WriteAttribute(sb, "MaxObservedMotion", building.MaxObservedMotion);
            WriteAttribute(sb, "MinObservedMotion", building.MinObservedMotion);

            WriteAttribute(sb, "AverageOccupants", building.AverageOccupants);
            WriteAttribute(sb, "MaxObservedOccupants", building.MaxObservedOccupants);
            WriteAttribute(sb, "MinObservedOccupants", building.MinObservedOccupants);

            WriteAttribute(sb, "AverageWifiClients", building.AverageWifiClients);
            WriteAttribute(sb, "MaxObservedWifiClients", building.MaxObservedWifiClients);
            WriteLastAttribute(sb, "MinObservedWifiClients", building.MinObservedWifiClients);

            return sb.ToString();
        }

        public string GetFloorInfobox(TemporalFloor floor)
        {
            StringBuilder sb = new StringBuilder();
            WriteFirstAttribute(sb,"Level", floor.FloorLevel);
            WriteAttribute(sb, "Name", floor.FloorName);
            WriteAttribute(sb, "SurfaceArea", floor.SurfaceArea);
            WriteAttribute(sb, "NumberOfRooms", floor.NumberOfSensorRooms);

            WriteAttribute(sb, "AverageTemperature", floor.AverageTemperature);
            WriteAttribute(sb, "MaxObservedTemperature", floor.MaxObservedTemperature);
            WriteAttribute(sb, "MinObservedTemperature", floor.MinObservedTemperature);

            WriteAttribute(sb, "AverageCO2", floor.AverageCO2);
            WriteAttribute(sb, "MaxObservedCO2", floor.MaxObservedCO2);
            WriteAttribute(sb, "MinObservedCO2", floor.MinObservedCO2);

            WriteAttribute(sb, "AverageLight", floor.AverageLight);
            WriteAttribute(sb, "MaxObservedLight", floor.MaxObservedLight);
            WriteAttribute(sb, "MinObservedLight", floor.MinObservedLight);

            WriteAttribute(sb, "AverageLux", floor.AverageLux);
            WriteAttribute(sb, "MaxObservedLux", floor.MaxObservedLux);
            WriteAttribute(sb, "MinObservedLux", floor.MinObservedLux);

            WriteAttribute(sb, "AverageHardwareConsumption", floor.AverageHardwareConsumption);
            WriteAttribute(sb, "MaxObservedHardwareConsumption", floor.MaxObservedHardwareConsumption);
            WriteAttribute(sb, "MinObservedHardwareConsumption", floor.MinObservedHardwareConsumption);

            WriteAttribute(sb, "AverageLightConsumption", floor.AverageLightConsumption);
            WriteAttribute(sb, "MaxObservedLightConsumption", floor.MaxObservedLightConsumption);
            WriteAttribute(sb, "MinObservedLightConsumption", floor.MinObservedLightConsumption);

            WriteAttribute(sb, "AverageVentilationConsumption", floor.AverageVentilationConsumption);
            WriteAttribute(sb, "MaxObservedVentilationConsumption", floor.MaxObservedVentilationConsumption);
            WriteAttribute(sb, "MinObservedVentilationConsumption", floor.MinObservedVentilationConsumption);

            WriteAttribute(sb, "AverageOtherConsumption", floor.AverageOtherConsumption);
            WriteAttribute(sb, "MaxObservedOtherConsumption", floor.MaxObservedOtherConsumption);
            WriteAttribute(sb, "MinObservedOtherConsumption", floor.MinObservedOtherConsumption);

            WriteAttribute(sb, "AverageTotalPowerConsumption", floor.AverageTotalPowerConsumption);
            WriteAttribute(sb, "MaxObservedTotalPowerConsumption", floor.MaxObservedTotalPowerConsumption);
            WriteAttribute(sb, "MinObservedTotalPowerConsumption", floor.MinObservedTotalPowerConsumption);

            WriteAttribute(sb, "AverageColdWaterConsumption", floor.AverageColdWaterConsumption);
            WriteAttribute(sb, "MaxObservedColdWaterConsumption", floor.MaxObservedColdWaterConsumption);
            WriteAttribute(sb, "MinObservedColdWaterConsumption", floor.MinObservedColdWaterConsumption);

            WriteAttribute(sb, "AverageHotWaterConsumption", floor.AverageHotWaterConsumption);
            WriteAttribute(sb, "MaxObservedHotWaterConsumption", floor.MaxObservedHotWaterConsumption);
            WriteAttribute(sb, "MinObservedHotWaterConsumption", floor.MinObservedHotWaterConsumption);

            WriteAttribute(sb, "AverageMotion", floor.AverageMotion);
            WriteAttribute(sb, "MaxObservedMotion", floor.MaxObservedMotion);
            WriteAttribute(sb, "MinObservedMotion", floor.MinObservedMotion);

            WriteAttribute(sb, "AverageOccupants", floor.AverageOccupants);
            WriteAttribute(sb, "MaxObservedOccupants", floor.MaxObservedOccupants);
            WriteAttribute(sb, "MinObservedOccupants", floor.MinObservedOccupants);

            WriteAttribute(sb, "AverageWifiClients", floor.AverageWifiClients);
            WriteAttribute(sb, "MaxObservedWifiClients", floor.MaxObservedWifiClients);
            WriteLastAttribute(sb, "MinObservedWifiClients", floor.MinObservedWifiClients);

            return sb.ToString();
        }

        public string GetDrawableFloor(TemporalFloor floor)
        {
            StringBuilder sb = new StringBuilder();
            WriteGeoJsonHeader(sb);
            foreach (TemporalRoom room in floor.Rooms.Where(r => r.GetType() == typeof (TemporalRoom)).Cast<TemporalRoom>())
            {
                WriteGeoJsonPropertiesHeader(sb);
                WriteFirstAttribute(sb, "Name", room.Name);
                WriteAttribute(sb, "SurfaceArea", room.SurfaceArea);
                WriteAttribute(sb, "Alias", room.Alias);

                WriteAttribute(sb, "AverageTemperature", room.AverageTemperature);
                WriteAttribute(sb, "MaxObservedTemperature", room.MaxObservedTemperature);
                WriteAttribute(sb, "MinObservedTemperature", room.MinObservedTemperature);
                WriteAttribute(sb, "MaxTemperature", room.MaxTemperature);
                WriteAttribute(sb, "MinTemperature", room.MinTemperature);

                WriteAttribute(sb, "AverageCO2", room.AverageCO2);
                WriteAttribute(sb, "MaxObservedCO2", room.MaxObservedCO2);
                WriteAttribute(sb, "MinObservedCO2", room.MinObservedCO2);
                WriteAttribute(sb, "MaxCO2", room.MaxCO2);
                WriteAttribute(sb, "MinCO2", room.MinCO2);

                WriteAttribute(sb, "AverageLight", room.AverageLight);
                WriteAttribute(sb, "MaxObservedLight", room.MaxObservedLight);
                WriteAttribute(sb, "MinObservedLight", room.MinObservedLight);

                WriteAttribute(sb, "AverageLux", room.AverageLux);
                WriteAttribute(sb, "MaxObservedLux", room.MaxObservedLux);
                WriteAttribute(sb, "MinObservedLux", room.MinObservedLux);
                WriteAttribute(sb, "MaxLux", room.MaxLux);

                WriteAttribute(sb, "AverageHardwareConsumption", room.AverageHardwareConsumption);
                WriteAttribute(sb, "MaxObservedHardwareConsumption", room.MaxObservedHardwareConsumption);
                WriteAttribute(sb, "MinObservedHardwareConsumption", room.MinObservedHardwareConsumption);
                WriteAttribute(sb, "MaxHardwareConsumption", room.MaxHardwareConsumption);
                WriteAttribute(sb, "MinHardwareConsumption", room.MinHardwareConsumption);

                WriteAttribute(sb, "AverageLightConsumption", room.AverageLightConsumption);
                WriteAttribute(sb, "MaxObservedLightConsumption", room.MaxObservedLightConsumption);
                WriteAttribute(sb, "MinObservedLightConsumption", room.MinObservedLightConsumption);
                WriteAttribute(sb, "MaxLightConsumption", room.MaxLightConsumption);
                WriteAttribute(sb, "MinLightConsumption", room.MinLightConsumption);

                WriteAttribute(sb, "AverageVentilationConsumption", room.AverageVentilationConsumption);
                WriteAttribute(sb, "MaxObservedVentilationConsumption", room.MaxObservedVentilationConsumption);
                WriteAttribute(sb, "MinObservedVentilationConsumption", room.MinObservedVentilationConsumption);
                WriteAttribute(sb, "MaxVentilationConsumption", room.MaxVentilationConsumption);
                WriteAttribute(sb, "MinVentilationConsumption", room.MinVentilationConsumption);

                WriteAttribute(sb, "AverageOtherConsumption", room.AverageOtherConsumption);
                WriteAttribute(sb, "MaxObservedOtherConsumption", room.MaxObservedOtherConsumption);
                WriteAttribute(sb, "MaxOtherConsumption", room.MaxOtherConsumption);
                WriteAttribute(sb, "MaxOtherConsumption", room.MaxOtherConsumption);
                WriteAttribute(sb, "MinOtherConsumption", room.MinOtherConsumption);

                WriteAttribute(sb, "AverageTotalPowerConsumption", room.AverageTotalPowerConsumption);
                WriteAttribute(sb, "MaxObservedTotalPowerConsumption", room.MaxObservedTotalPowerConsumption);
                WriteAttribute(sb, "MinObservedTotalPowerConsumption", room.MinObservedTotalPowerConsumption);
                WriteAttribute(sb, "MaxTotalPowerConsumption", room.MaxTotalPowerConsumption);
                WriteAttribute(sb, "MinTotalPowerConsumption", room.MinTotalPowerConsumption);

                WriteAttribute(sb, "AverageMotion", room.AverageMotion);
                WriteAttribute(sb, "MaxObservedMotion", room.MaxObservedMotion);
                WriteAttribute(sb, "MinObservedMotion", room.MinObservedMotion);

                WriteAttribute(sb, "AverageOccupants", room.AverageOccupants);
                WriteAttribute(sb, "MaxObservedOccupants", room.MaxObservedOccupants);
                WriteAttribute(sb, "MinObservedOccupants", room.MinObservedOccupants);
                WriteAttribute(sb, "MaxOccupants", room.MaxOccupants);

                WriteAttribute(sb, "AverageWifiClients", room.AverageWifiClients);
                WriteAttribute(sb, "MaxObservedWifiClients", room.MaxObservedWifiClients);
                WriteAttribute(sb, "MinObservedWifiClients", room.MinObservedWifiClients);
                WriteLastAttribute(sb, "MaxWifiClients", room.MaxWifiClients);
                WriteGeoJsonPropertiesFooter(sb);
                WriteGeoJsonGeometryHeader(sb);
                WriteGeoJsonCoordinates(sb, room.Corners.TopLeftCorner.XCoordinate, room.Corners.TopLeftCorner.YCoordinate);
                WriteGeoJsonCoordinates(sb, room.Corners.BottomLeftCorner.XCoordinate, room.Corners.BottomLeftCorner.YCoordinate);
                WriteGeoJsonCoordinates(sb, room.Corners.BottomRightCorner.XCoordinate, room.Corners.BottomRightCorner.YCoordinate);
                WriteGeoJsonCoordinatesLast(sb, room.Corners.TopRightCorner.XCoordinate, room.Corners.TopRightCorner.YCoordinate);
                WriteGeoJsonGeometryFooter(sb);
            }
            sb.Remove(sb.Length - 1, 1);

            WriteGeoJsonFooter(sb);

            return sb.ToString();
        }
    }
}