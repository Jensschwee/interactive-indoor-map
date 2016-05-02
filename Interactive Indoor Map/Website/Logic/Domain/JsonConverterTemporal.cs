using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Website.Logic.BO.Buildings;

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
            sb.Append("\"MaxTemperature\":" + JsonConvert.SerializeObject(building.TemperatureMax) + ",");

            sb.Append("\"AverageCO2\":" + JsonConvert.SerializeObject(building.AverageCO2) + ",");
            sb.Append("\"MaxObservedCO2\":" + JsonConvert.SerializeObject(building.MaxObservedCO2) + ",");
            sb.Append("\"MinObservedCO2\":" + JsonConvert.SerializeObject(building.MinObservedCO2) + ",");
            sb.Append("\"MaxCO2\":" + JsonConvert.SerializeObject(building.CO2Max) + ",");


            sb.Append("\"AverageLight\":" + JsonConvert.SerializeObject(building.AverageLight) + ",");
            sb.Append("\"MaxObservedLight\":" + JsonConvert.SerializeObject(building.MaxObservedLight) + ",");
            sb.Append("\"MinObservedLight\":" + JsonConvert.SerializeObject(building.MinObservedLight) + ",");

            sb.Append("\"AverageLumen\":" + JsonConvert.SerializeObject(building.AverageLumen) + ",");
            sb.Append("\"MaxObservedLumen\":" + JsonConvert.SerializeObject(building.MaxObservedLumen) + ",");
            sb.Append("\"MinObservedLumen\":" + JsonConvert.SerializeObject(building.MinObservedLumen) + ",");
            sb.Append("\"MaxLumen\":" + JsonConvert.SerializeObject(building.LumenMax) + ",");

            sb.Append("\"AverageHardwareConsumption\":" +
                      JsonConvert.SerializeObject(building.AverageHardwareConsumption) + ",");
            sb.Append("\"MaxObservedHardwareConsumption\":" +
                      JsonConvert.SerializeObject(building.MaxObservedHardwareConsumption) + ",");
            sb.Append("\"MinObservedHardwareConsumption\":" +
                      JsonConvert.SerializeObject(building.MinObservedHardwareConsumption) + ",");
            sb.Append("\"MaxHardwareConsumption\":" + JsonConvert.SerializeObject(building.HardwareConsumptionMax) + ",");

            sb.Append("\"AverageLightConsumption\":" + JsonConvert.SerializeObject(building.AverageLightConsumption) +
                      ",");
            sb.Append("\"MaxObservedLightConsumption\":" +
                      JsonConvert.SerializeObject(building.MaxObservedLightConsumption) + ",");
            sb.Append("\"MinObservedLightConsumption\":" +
                      JsonConvert.SerializeObject(building.MinObservedLightConsumption) + ",");
            sb.Append("\"MaxLightConsumption\":" + JsonConvert.SerializeObject(building.LightConsumptionMax) + ",");

            sb.Append("\"AverageVentilationConsumption\":" +
                      JsonConvert.SerializeObject(building.AverageVentilationConsumption) + ",");
            sb.Append("\"MaxObservedVentilationConsumption\":" +
                      JsonConvert.SerializeObject(building.MaxObservedVentilationConsumption) + ",");
            sb.Append("\"MinObservedVentilationConsumption\":" +
                      JsonConvert.SerializeObject(building.MinObservedVentilationConsumption) + ",");
            sb.Append("\"MaxVentilationConsumption\":" + JsonConvert.SerializeObject(building.VentilationConsumptionMax) +
                      ",");

            sb.Append("\"AverageOtherConsumption\":" + JsonConvert.SerializeObject(building.AverageOtherConsumption) +
                      ",");
            sb.Append("\"MaxObservedOtherConsumption\":" +
                      JsonConvert.SerializeObject(building.MaxObservedOtherConsumption) + ",");
            sb.Append("\"MinObservedOtherConsumption\":" +
                      JsonConvert.SerializeObject(building.MinObservedOtherConsumption) + ",");
            sb.Append("\"MaxOtherConsumption\":" + JsonConvert.SerializeObject(building.OtherConsumptionMax) + ",");


            sb.Append("\"AverageTotalPowerConsumption\":" +
                      JsonConvert.SerializeObject(building.AverageTotalPowerConsumption) + ",");
            sb.Append("\"MaxObservedTotalPowerConsumption\":" +
                      JsonConvert.SerializeObject(building.MaxObservedTotalPowerConsumption) + ",");
            sb.Append("\"MinObservedTotalPowerConsumption\":" +
                      JsonConvert.SerializeObject(building.MinObservedTotalPowerConsumption) + ",");
            sb.Append("\"MaxTotalPowerConsumption\":" + JsonConvert.SerializeObject(building.TotalPowerConsumptionMax) +
                      ",");

            sb.Append("\"AverageColdWaterConsumption\":" +
                      JsonConvert.SerializeObject(building.AverageColdWaterConsumption) + ",");
            sb.Append("\"MaxObservedColdWaterConsumption\":" +
                      JsonConvert.SerializeObject(building.MaxObservedColdWaterConsumption) + ",");
            sb.Append("\"MinObservedColdWaterConsumption\":" +
                      JsonConvert.SerializeObject(building.MinObservedColdWaterConsumption) + ",");
            sb.Append("\"MaxColdWaterConsumption\":" + JsonConvert.SerializeObject(building.ColdWaterConsumptionMax) +
                      ",");

            sb.Append("\"AverageHotWaterConsumption\":" +
                      JsonConvert.SerializeObject(building.AverageHotWaterConsumption) + ",");
            sb.Append("\"MaxObservedHotWaterConsumption\":" +
                      JsonConvert.SerializeObject(building.MaxObservedHotWaterConsumption) + ",");
            sb.Append("\"MinObservedHotWaterConsumption\":" +
                      JsonConvert.SerializeObject(building.MinObservedHotWaterConsumption) + ",");
            sb.Append("\"MaxHotWaterConsumption\":" + JsonConvert.SerializeObject(building.HotWaterConsumptionMax) + ",");

            sb.Append("\"AverageMotion\":" + JsonConvert.SerializeObject(building.AverageMotion) + ",");
            sb.Append("\"MaxObservedMotion\":" + JsonConvert.SerializeObject(building.MaxObservedMotion) + ",");
            sb.Append("\"MinObservedMotion\":" + JsonConvert.SerializeObject(building.MinObservedMotion) + ",");

            sb.Append("\"AverageOccupants\":" + JsonConvert.SerializeObject(building.AverageOccupants) + ",");
            sb.Append("\"MaxObservedOccupants\":" + JsonConvert.SerializeObject(building.MaxObservedOccupants) + ",");
            sb.Append("\"MinObservedOccupants\":" + JsonConvert.SerializeObject(building.MinObservedOccupants) + ",");
            sb.Append("\"MaxOccupants\":" + JsonConvert.SerializeObject(building.OccupantsMax) + ",");

            sb.Append("\"AverageWifiClients\":" + JsonConvert.SerializeObject(building.AverageWifiClients) + ",");
            sb.Append("\"MaxObservedWifiClients\":" + JsonConvert.SerializeObject(building.MaxObservedWifiClients) + ",");
            sb.Append("\"MinObservedWifiClients\":" + JsonConvert.SerializeObject(building.MinObservedWifiClients) + ",");
            sb.Append("\"MaxWifiClients\":" + JsonConvert.SerializeObject(building.WifiClientsMax));

            return sb.ToString();
        }
    }
}