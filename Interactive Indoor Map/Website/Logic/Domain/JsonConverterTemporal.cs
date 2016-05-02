using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Website.Logic.BO.Buildings;
using Website.Logic.BO.Floors;

namespace Website.Logic.Domain
{
    public class JsonConverterTemporal
    {
        public string ConvertBuilding(TemporalBuilding building)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            sb.Append("\"Name\":\"" + building.Name + "\",");
            sb.Append("\"SurfaceArea\":" + building.SurfaceArea + ",");

            sb.Append("\"NumberOfRooms\":" + JsonConvert.SerializeObject(building.NumberOfLiveRoom) + ",");

            sb.Append("\"AverageTemperature\":" + JsonConvert.SerializeObject(building.AverageTemperature) + ",");
            sb.Append("\"MaxObservedTemperature\":" + JsonConvert.SerializeObject(building.MaxObservedTemperature) + ",");
            sb.Append("\"MinObservedTemperature\":" + JsonConvert.SerializeObject(building.MinObservedTemperature) + ",");
            sb.Append("\"MaxTemperature\":" + JsonConvert.SerializeObject(building.MaxTemperature) + ",");

            sb.Append("\"AverageCO2\":" + JsonConvert.SerializeObject(building.AverageCO2) + ",");
            sb.Append("\"MaxObservedCO2\":" + JsonConvert.SerializeObject(building.MaxObservedCO2) + ",");
            sb.Append("\"MinObservedCO2\":" + JsonConvert.SerializeObject(building.MinObservedCO2) + ",");
            sb.Append("\"MaxCO2\":" + JsonConvert.SerializeObject(building.MaxCO2) + ",");


            sb.Append("\"AverageLight\":" + JsonConvert.SerializeObject(building.AverageLight) + ",");
            sb.Append("\"MaxObservedLight\":" + JsonConvert.SerializeObject(building.MaxObservedLight) + ",");
            sb.Append("\"MinObservedLight\":" + JsonConvert.SerializeObject(building.MinObservedLight) + ",");

            sb.Append("\"AverageLumen\":" + JsonConvert.SerializeObject(building.AverageLumen) + ",");
            sb.Append("\"MaxObservedLumen\":" + JsonConvert.SerializeObject(building.MaxObservedLumen) + ",");
            sb.Append("\"MinObservedLumen\":" + JsonConvert.SerializeObject(building.MinObservedLumen) + ",");
            sb.Append("\"MaxLumen\":" + JsonConvert.SerializeObject(building.MaxLumen) + ",");

            sb.Append("\"AverageHardwareConsumption\":" +
                      JsonConvert.SerializeObject(building.AverageHardwareConsumption) + ",");
            sb.Append("\"MaxObservedHardwareConsumption\":" +
                      JsonConvert.SerializeObject(building.MaxObservedHardwareConsumption) + ",");
            sb.Append("\"MinObservedHardwareConsumption\":" +
                      JsonConvert.SerializeObject(building.MinObservedHardwareConsumption) + ",");
            sb.Append("\"MaxHardwareConsumption\":" + JsonConvert.SerializeObject(building.MaxHardwareConsumption) + ",");

            sb.Append("\"AverageLightConsumption\":" + JsonConvert.SerializeObject(building.AverageLightConsumption) +
                      ",");
            sb.Append("\"MaxObservedLightConsumption\":" +
                      JsonConvert.SerializeObject(building.MaxObservedLightConsumption) + ",");
            sb.Append("\"MinObservedLightConsumption\":" +
                      JsonConvert.SerializeObject(building.MinObservedLightConsumption) + ",");
            sb.Append("\"MaxLightConsumption\":" + JsonConvert.SerializeObject(building.MaxLightConsumption) + ",");

            sb.Append("\"AverageVentilationConsumption\":" +
                      JsonConvert.SerializeObject(building.AverageVentilationConsumption) + ",");
            sb.Append("\"MaxObservedVentilationConsumption\":" +
                      JsonConvert.SerializeObject(building.MaxObservedVentilationConsumption) + ",");
            sb.Append("\"MinObservedVentilationConsumption\":" +
                      JsonConvert.SerializeObject(building.MinObservedVentilationConsumption) + ",");
            sb.Append("\"MaxVentilationConsumption\":" + JsonConvert.SerializeObject(building.MaxVentilationConsumption) +
                      ",");

            sb.Append("\"AverageOtherConsumption\":" + JsonConvert.SerializeObject(building.AverageOtherConsumption) +
                      ",");
            sb.Append("\"MaxObservedOtherConsumption\":" +
                      JsonConvert.SerializeObject(building.MaxObservedOtherConsumption) + ",");
            sb.Append("\"MinObservedOtherConsumption\":" +
                      JsonConvert.SerializeObject(building.MinObservedOtherConsumption) + ",");
            sb.Append("\"MaxOtherConsumption\":" + JsonConvert.SerializeObject(building.MaxOtherConsumption) + ",");


            sb.Append("\"AverageTotalPowerConsumption\":" +
                      JsonConvert.SerializeObject(building.AverageTotalPowerConsumption) + ",");
            sb.Append("\"MaxObservedTotalPowerConsumption\":" +
                      JsonConvert.SerializeObject(building.MaxObservedTotalPowerConsumption) + ",");
            sb.Append("\"MinObservedTotalPowerConsumption\":" +
                      JsonConvert.SerializeObject(building.MinObservedTotalPowerConsumption) + ",");
            sb.Append("\"MaxTotalPowerConsumption\":" + JsonConvert.SerializeObject(building.MaxTotalPowerConsumption) +
                      ",");

            sb.Append("\"AverageColdWaterConsumption\":" +
                      JsonConvert.SerializeObject(building.AverageColdWaterConsumption) + ",");
            sb.Append("\"MaxObservedColdWaterConsumption\":" +
                      JsonConvert.SerializeObject(building.MaxObservedColdWaterConsumption) + ",");
            sb.Append("\"MinObservedColdWaterConsumption\":" +
                      JsonConvert.SerializeObject(building.MinObservedColdWaterConsumption) + ",");
            sb.Append("\"MaxColdWaterConsumption\":" + JsonConvert.SerializeObject(building.MaxColdWaterConsumption) +
                      ",");

            sb.Append("\"AverageHotWaterConsumption\":" +
                      JsonConvert.SerializeObject(building.AverageHotWaterConsumption) + ",");
            sb.Append("\"MaxObservedHotWaterConsumption\":" +
                      JsonConvert.SerializeObject(building.MaxObservedHotWaterConsumption) + ",");
            sb.Append("\"MinObservedHotWaterConsumption\":" +
                      JsonConvert.SerializeObject(building.MinObservedHotWaterConsumption) + ",");
            sb.Append("\"MaxHotWaterConsumption\":" + JsonConvert.SerializeObject(building.MaxHotWaterConsumption) + ",");

            sb.Append("\"AverageMotion\":" + JsonConvert.SerializeObject(building.AverageMotion) + ",");
            sb.Append("\"MaxObservedMotion\":" + JsonConvert.SerializeObject(building.MaxObservedMotion) + ",");
            sb.Append("\"MinObservedMotion\":" + JsonConvert.SerializeObject(building.MinObservedMotion) + ",");

            sb.Append("\"AverageOccupants\":" + JsonConvert.SerializeObject(building.AverageOccupants) + ",");
            sb.Append("\"MaxObservedOccupants\":" + JsonConvert.SerializeObject(building.MaxObservedOccupants) + ",");
            sb.Append("\"MinObservedOccupants\":" + JsonConvert.SerializeObject(building.MinObservedOccupants) + ",");
            sb.Append("\"MaxOccupants\":" + JsonConvert.SerializeObject(building.MaxOccupants) + ",");

            sb.Append("\"AverageWifiClients\":" + JsonConvert.SerializeObject(building.AverageWifiClients) + ",");
            sb.Append("\"MaxObservedWifiClients\":" + JsonConvert.SerializeObject(building.MaxObservedWifiClients) + ",");
            sb.Append("\"MinObservedWifiClients\":" + JsonConvert.SerializeObject(building.MinObservedWifiClients) + ",");
            sb.Append("\"MaxWifiClients\":" + JsonConvert.SerializeObject(building.MaxWifiClients));

            return sb.ToString();
        }

        public string ConvertFloor(TemporalFloor floor)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            sb.Append("\"Level\":\"" + floor.FloorLevel + "\",");

            sb.Append("\"Name\":\"" + floor.FloorName + "\",");
            sb.Append("\"SurfaceArea\":" + floor.SurfaceArea + ",");

            sb.Append("\"NumberOfRooms\":" + JsonConvert.SerializeObject(floor.NumberOfLiveRoom) + ",");

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

            sb.Append("\"AverageLumen\":" + JsonConvert.SerializeObject(floor.AverageLumen) + ",");
            sb.Append("\"MaxObservedLumen\":" + JsonConvert.SerializeObject(floor.MaxObservedLumen) + ",");
            sb.Append("\"MinObservedLumen\":" + JsonConvert.SerializeObject(floor.MinObservedLumen) + ",");
            sb.Append("\"MaxLumen\":" + JsonConvert.SerializeObject(floor.MaxLumen) + ",");

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

            return sb.ToString();
        }
    }
}