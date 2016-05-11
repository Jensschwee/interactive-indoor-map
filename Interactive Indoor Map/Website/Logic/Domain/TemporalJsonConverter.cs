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
            sb.Append("{\"type\": \"FeatureCollection\", \"features\": [");
            foreach (TemporalRoom room in floor.Rooms.Where(r => r.GetType() == typeof (TemporalRoom)).Cast<TemporalRoom>())
            {
                sb.Append("{ \"type\": \"Feature\", \"properties\": {");
                sb.Append("\"Name\":" + JsonConvert.SerializeObject(room.Name) + ",");
                sb.Append("\"SurfaceArea\":" + JsonConvert.SerializeObject(room.SurfaceArea) + ",");
                sb.Append("\"Alias\":" + JsonConvert.SerializeObject(room.Alias) + ",");

                sb.Append("\"AverageTemperature\":" + JsonConvert.SerializeObject(room.AverageTemperature) + ",");
                sb.Append("\"MaxObservedTemperature\":" + JsonConvert.SerializeObject(room.MaxObservedTemperature) + ",");
                sb.Append("\"MinObservedTemperature\":" + JsonConvert.SerializeObject(room.MinObservedTemperature) + ",");
                sb.Append("\"MaxTemperature\":" + JsonConvert.SerializeObject(room.MaxTemperature) + ",");
                sb.Append("\"MinTemperature\":" + JsonConvert.SerializeObject(room.MinTemperature) + ",");

                sb.Append("\"AverageCO2\":" + JsonConvert.SerializeObject(room.AverageCO2) + ",");
                sb.Append("\"MaxObservedCO2\":" + JsonConvert.SerializeObject(room.MaxObservedCO2) + ",");
                sb.Append("\"MinObservedCO2\":" + JsonConvert.SerializeObject(room.MinObservedCO2) + ",");
                sb.Append("\"MaxCO2\":" + JsonConvert.SerializeObject(room.MaxCO2) + ",");
                sb.Append("\"MinCO2\":" + JsonConvert.SerializeObject(room.MinCO2) + ",");

                sb.Append("\"AverageLight\":" + JsonConvert.SerializeObject(room.AverageLight) + ",");
                sb.Append("\"MaxObservedLight\":" + JsonConvert.SerializeObject(room.MaxObservedLight) + ",");
                sb.Append("\"MinObservedLight\":" + JsonConvert.SerializeObject(room.MinObservedLight) + ",");

                sb.Append("\"AverageLux\":" + JsonConvert.SerializeObject(room.AverageLux) + ",");
                sb.Append("\"MaxObservedLux\":" + JsonConvert.SerializeObject(room.MaxObservedLux) + ",");
                sb.Append("\"MinObservedLux\":" + JsonConvert.SerializeObject(room.MinObservedLux) + ",");
                sb.Append("\"MaxLux\":" + JsonConvert.SerializeObject(room.MaxLux) + ",");

                sb.Append("\"AverageHardwareConsumption\":" + JsonConvert.SerializeObject(room.AverageHardwareConsumption) + ",");
                sb.Append("\"MaxObservedHardwareConsumption\":" + JsonConvert.SerializeObject(room.MaxObservedHardwareConsumption) + ",");
                sb.Append("\"MinObservedHardwareConsumption\":" + JsonConvert.SerializeObject(room.MinObservedHardwareConsumption) + ",");
                sb.Append("\"MaxHardwareConsumption\":" + JsonConvert.SerializeObject(room.MaxHardwareConsumption) + ",");
                sb.Append("\"MinHardwareConsumption\":" + JsonConvert.SerializeObject(room.MinHardwareConsumption) + ",");

                sb.Append("\"AverageLightConsumption\":" + JsonConvert.SerializeObject(room.AverageLightConsumption) + ",");
                sb.Append("\"MaxObservedLightConsumption\":" + JsonConvert.SerializeObject(room.MaxObservedLightConsumption) + ",");
                sb.Append("\"MinObservedLightConsumption\":" + JsonConvert.SerializeObject(room.MinObservedLightConsumption) + ",");
                sb.Append("\"MaxLightConsumption\":" + JsonConvert.SerializeObject(room.MaxLightConsumption) + ",");
                sb.Append("\"MinLightConsumption\":" + JsonConvert.SerializeObject(room.MinLightConsumption) + ",");

                sb.Append("\"AverageVentilationConsumption\":" + JsonConvert.SerializeObject(room.AverageVentilationConsumption) + ",");
                sb.Append("\"MaxObservedVentilationConsumption\":" + JsonConvert.SerializeObject(room.MaxObservedVentilationConsumption) + ",");
                sb.Append("\"MinObservedVentilationConsumption\":" + JsonConvert.SerializeObject(room.MinObservedVentilationConsumption) + ",");
                sb.Append("\"MaxVentilationConsumption\":" + JsonConvert.SerializeObject(room.MaxVentilationConsumption) + ",");
                sb.Append("\"MinVentilationConsumption\":" + JsonConvert.SerializeObject(room.MinVentilationConsumption) + ",");

                sb.Append("\"AverageOtherConsumption\":" + JsonConvert.SerializeObject(room.AverageOtherConsumption) + ",");
                sb.Append("\"MaxObservedOtherConsumption\":" + JsonConvert.SerializeObject(room.MaxObservedOtherConsumption) + ",");
                sb.Append("\"MinObservedOtherConsumption\":" + JsonConvert.SerializeObject(room.MinObservedOtherConsumption) + ",");
                sb.Append("\"MaxOtherConsumption\":" + JsonConvert.SerializeObject(room.MaxOtherConsumption) + ",");
                sb.Append("\"MinOtherConsumption\":" + JsonConvert.SerializeObject(room.MinOtherConsumption) + ",");

                sb.Append("\"AverageTotalPowerConsumption\":" + JsonConvert.SerializeObject(room.AverageTotalPowerConsumption) + ",");
                sb.Append("\"MaxObservedTotalPowerConsumption\":" + JsonConvert.SerializeObject(room.MaxObservedTotalPowerConsumption) + ",");
                sb.Append("\"MinObservedTotalPowerConsumption\":" + JsonConvert.SerializeObject(room.MinObservedTotalPowerConsumption) + ",");
                sb.Append("\"MaxTotalPowerConsumption\":" + JsonConvert.SerializeObject(room.MaxTotalPowerConsumption) + ",");
                sb.Append("\"MinTotalPowerConsumption\":" + JsonConvert.SerializeObject(room.MinTotalPowerConsumption) + ",");

                sb.Append("\"AverageMotion\":" + JsonConvert.SerializeObject(room.AverageMotion) + ",");
                sb.Append("\"MaxObservedMotion\":" + JsonConvert.SerializeObject(room.MaxObservedMotion) + ",");
                sb.Append("\"MinObservedMotion\":" + JsonConvert.SerializeObject(room.MinObservedMotion) + ",");

                sb.Append("\"AverageOccupants\":" + JsonConvert.SerializeObject(room.AverageOccupants) + ",");
                sb.Append("\"MaxObservedOccupants\":" + JsonConvert.SerializeObject(room.MaxObservedOccupants) + ",");
                sb.Append("\"MinObservedOccupants\":" + JsonConvert.SerializeObject(room.MinObservedOccupants) + ",");
                sb.Append("\"MaxOccupants\":" + JsonConvert.SerializeObject(room.MaxOccupants) + ",");

                sb.Append("\"AverageWifiClients\":" + JsonConvert.SerializeObject(room.AverageWifiClients) + ",");
                sb.Append("\"MaxObservedWifiClients\":" + JsonConvert.SerializeObject(room.MaxObservedWifiClients) + ",");
                sb.Append("\"MinObservedWifiClients\":" + JsonConvert.SerializeObject(room.MinObservedWifiClients) + ",");
                sb.Append("\"MaxWifiClients\":" + JsonConvert.SerializeObject(room.MaxWifiClients));

                sb.Append("},\"geometry\": { \"type\": \"Polygon\", \"coordinates\": [ [");
                sb.Append("[" + JsonConvert.SerializeObject(room.Corners.TopLeftCorner.XCoordinate) + "," + JsonConvert.SerializeObject(room.Corners.TopLeftCorner.YCoordinate) + "],");
                sb.Append("[" + JsonConvert.SerializeObject(room.Corners.BottomLeftCorner.XCoordinate) + "," + JsonConvert.SerializeObject(room.Corners.BottomLeftCorner.YCoordinate) + "],");
                sb.Append("[" + JsonConvert.SerializeObject(room.Corners.BottomRightCorner.XCoordinate) + "," + JsonConvert.SerializeObject(room.Corners.BottomRightCorner.YCoordinate) + "],");
                sb.Append("[" + JsonConvert.SerializeObject(room.Corners.TopRightCorner.XCoordinate) + "," + JsonConvert.SerializeObject(room.Corners.TopRightCorner.YCoordinate) + "],");
                sb.Remove(sb.Length - 1, 1);
                sb.Append("]]}},");
            }
            sb.Remove(sb.Length - 1, 1);

            sb.Append("]}");
            return sb.ToString();
        }
    }
}