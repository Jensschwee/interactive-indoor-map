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

        public string ConvertFloor(TemporalFloor floor)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            sb.Append("\"Level\":\"" + floor.FloorLevel + "\",");

            sb.Append("\"Name\":\"" + floor.FloorName + "\",");
            sb.Append("\"SurfaceArea\":" + floor.SurfaceArea + ",");

            sb.Append("\"NumberOfRooms\":" + JsonConvert.SerializeObject(floor.NumberOfSensorRooms) + ",");

            sb.Append("\"AverageTemperature\":" + JsonConvert.SerializeObject(floor.AverageTemperature) + ",");
            sb.Append("\"MaxObservedTemperature\":" + JsonConvert.SerializeObject(floor.MaxObservedTemperature) + ",");
            sb.Append("\"MinObservedTemperature\":" + JsonConvert.SerializeObject(floor.MinObservedTemperature) + ",");
            sb.Append("\"MaxTemperature\":" + JsonConvert.SerializeObject(floor.MaxTemperature) + ",");

            sb.Append("\"AverageCO2\":" + JsonConvert.SerializeObject(floor.AverageCO2) + ",");
            sb.Append("\"MaxObservedCO2\":" + JsonConvert.SerializeObject(floor.MaxObservedCO2) + ",");
            sb.Append("\"MinObservedCO2\":" + JsonConvert.SerializeObject(floor.MinObservedCO2) + ",");
            sb.Append("\"MaxCO2\":" + JsonConvert.SerializeObject(floor.MaxCO2) + ",");


            sb.Append("\"AverageLight\":" + JsonConvert.SerializeObject(floor.AverageLight) + ",");
            sb.Append("\"MaxObservedLight\":" + JsonConvert.SerializeObject(floor.MaxObservedLight) + ",");
            sb.Append("\"MinObservedLight\":" + JsonConvert.SerializeObject(floor.MinObservedLight) + ",");

            sb.Append("\"AverageLux\":" + JsonConvert.SerializeObject(floor.AverageLux) + ",");
            sb.Append("\"MaxObservedLux\":" + JsonConvert.SerializeObject(floor.MaxObservedLux) + ",");
            sb.Append("\"MinObservedLux\":" + JsonConvert.SerializeObject(floor.MinObservedLux) + ",");
            sb.Append("\"MaxLux\":" + JsonConvert.SerializeObject(floor.MaxLux) + ",");

            sb.Append("\"AverageHardwareConsumption\":" +
                      JsonConvert.SerializeObject(floor.AverageHardwareConsumption) + ",");
            sb.Append("\"MaxObservedHardwareConsumption\":" +
                      JsonConvert.SerializeObject(floor.MaxObservedHardwareConsumption) + ",");
            sb.Append("\"MinObservedHardwareConsumption\":" +
                      JsonConvert.SerializeObject(floor.MinObservedHardwareConsumption) + ",");
            sb.Append("\"MaxHardwareConsumption\":" + JsonConvert.SerializeObject(floor.MaxHardwareConsumption) + ",");

            sb.Append("\"AverageLightConsumption\":" + JsonConvert.SerializeObject(floor.AverageLightConsumption) +
                      ",");
            sb.Append("\"MaxObservedLightConsumption\":" +
                      JsonConvert.SerializeObject(floor.MaxObservedLightConsumption) + ",");
            sb.Append("\"MinObservedLightConsumption\":" +
                      JsonConvert.SerializeObject(floor.MinObservedLightConsumption) + ",");
            sb.Append("\"MaxLightConsumption\":" + JsonConvert.SerializeObject(floor.MaxLightConsumption) + ",");

            sb.Append("\"AverageVentilationConsumption\":" +
                      JsonConvert.SerializeObject(floor.AverageVentilationConsumption) + ",");
            sb.Append("\"MaxObservedVentilationConsumption\":" +
                      JsonConvert.SerializeObject(floor.MaxObservedVentilationConsumption) + ",");
            sb.Append("\"MinObservedVentilationConsumption\":" +
                      JsonConvert.SerializeObject(floor.MinObservedVentilationConsumption) + ",");
            sb.Append("\"MaxVentilationConsumption\":" + JsonConvert.SerializeObject(floor.MaxVentilationConsumption) +
                      ",");

            sb.Append("\"AverageOtherConsumption\":" + JsonConvert.SerializeObject(floor.AverageOtherConsumption) +
                      ",");
            sb.Append("\"MaxObservedOtherConsumption\":" +
                      JsonConvert.SerializeObject(floor.MaxObservedOtherConsumption) + ",");
            sb.Append("\"MinObservedOtherConsumption\":" +
                      JsonConvert.SerializeObject(floor.MinObservedOtherConsumption) + ",");
            sb.Append("\"MaxOtherConsumption\":" + JsonConvert.SerializeObject(floor.MaxOtherConsumption) + ",");


            sb.Append("\"AverageTotalPowerConsumption\":" +
                      JsonConvert.SerializeObject(floor.AverageTotalPowerConsumption) + ",");
            sb.Append("\"MaxObservedTotalPowerConsumption\":" +
                      JsonConvert.SerializeObject(floor.MaxObservedTotalPowerConsumption) + ",");
            sb.Append("\"MinObservedTotalPowerConsumption\":" +
                      JsonConvert.SerializeObject(floor.MinObservedTotalPowerConsumption) + ",");
            sb.Append("\"MaxTotalPowerConsumption\":" + JsonConvert.SerializeObject(floor.MaxTotalPowerConsumption) +
                      ",");

            sb.Append("\"AverageColdWaterConsumption\":" +
                      JsonConvert.SerializeObject(floor.AverageColdWaterConsumption) + ",");
            sb.Append("\"MaxObservedColdWaterConsumption\":" +
                      JsonConvert.SerializeObject(floor.MaxObservedColdWaterConsumption) + ",");
            sb.Append("\"MinObservedColdWaterConsumption\":" +
                      JsonConvert.SerializeObject(floor.MinObservedColdWaterConsumption) + ",");
            sb.Append("\"MaxColdWaterConsumption\":" + JsonConvert.SerializeObject(floor.MaxColdWaterConsumption) +
                      ",");

            sb.Append("\"AverageHotWaterConsumption\":" +
                      JsonConvert.SerializeObject(floor.AverageHotWaterConsumption) + ",");
            sb.Append("\"MaxObservedHotWaterConsumption\":" +
                      JsonConvert.SerializeObject(floor.MaxObservedHotWaterConsumption) + ",");
            sb.Append("\"MinObservedHotWaterConsumption\":" +
                      JsonConvert.SerializeObject(floor.MinObservedHotWaterConsumption) + ",");
            sb.Append("\"MaxHotWaterConsumption\":" + JsonConvert.SerializeObject(floor.MaxHotWaterConsumption) + ",");

            sb.Append("\"AverageMotion\":" + JsonConvert.SerializeObject(floor.AverageMotion) + ",");
            sb.Append("\"MaxObservedMotion\":" + JsonConvert.SerializeObject(floor.MaxObservedMotion) + ",");
            sb.Append("\"MinObservedMotion\":" + JsonConvert.SerializeObject(floor.MinObservedMotion) + ",");

            sb.Append("\"AverageOccupants\":" + JsonConvert.SerializeObject(floor.AverageOccupants) + ",");
            sb.Append("\"MaxObservedOccupants\":" + JsonConvert.SerializeObject(floor.MaxObservedOccupants) + ",");
            sb.Append("\"MinObservedOccupants\":" + JsonConvert.SerializeObject(floor.MinObservedOccupants) + ",");
            sb.Append("\"MaxOccupants\":" + JsonConvert.SerializeObject(floor.MaxOccupants) + ",");

            sb.Append("\"AverageWifiClients\":" + JsonConvert.SerializeObject(floor.AverageWifiClients) + ",");
            sb.Append("\"MaxObservedWifiClients\":" + JsonConvert.SerializeObject(floor.MaxObservedWifiClients) + ",");
            sb.Append("\"MinObservedWifiClients\":" + JsonConvert.SerializeObject(floor.MinObservedWifiClients) + ",");
            sb.Append("\"MaxWifiClients\":" + JsonConvert.SerializeObject(floor.MaxWifiClients));
            sb.Append("}");

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