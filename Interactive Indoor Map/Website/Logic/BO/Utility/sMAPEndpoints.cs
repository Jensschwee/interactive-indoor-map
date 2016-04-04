using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Logic.BO.Utility
{
    public class SmapEndpoints
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RealTimeEndpoint { get; set; }
        public string TemporalEndpoint { get; set; }
        public string RealTimeBody { get; set; }
        public string TemporalBody { get; set; }
        public SensorType SensorType { get; set; }
    }

    public enum SensorType
    {
        Temperature, CO2, Light, Lumen, TotalPowerConsumption, HardwarePowerConsumption, LightPowerConsumption, VentilationPowerConsumption,
        OtherPowerConsumption, Motion, Occupants, WifiClients
    } 
}