using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Logic.BO.Utility
{
    public class Endpoints
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Dictionary <SensorType, string> SmapEndponts { get; set; }

        public string WifiEndpoint { get; set; }

        //public string TemperatureUUID { get; set; }
        //public string CO2UUID { get; set; }
        //public string LightUUID { get; set; }
        //public string LumenUUID { get; set; }
        ////public string TotalPowerConsumptionUUID { get; set; }
        //public string HardwarePowerConsumptionUUID { get; set; }
        //public string LightPowerConsumptionUUID { get; set; }
        //public string VentilationPowerConsumptionUUID { get; set; }
        //public string OtherPowerConsumptionUUID { get; set; }
        //public string HotWaterConsumptionUUID { get; set; }
        //public string ColdWaterConsumptionUUID { get; set; }
        //public string MotionDetectionUUID { get; set; }
        //public string OccupantsUUID { get; set; }
        //public string WifiClientsUUID { get; set; }

        //public SensorType Type { get; set; }

    }
}