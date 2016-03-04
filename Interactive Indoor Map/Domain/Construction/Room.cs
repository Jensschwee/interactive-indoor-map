using Domain.Sensors;
using Domain.Utility;
using System.Collections.Generic;

namespace Domain.Construction
{
    class Room
    {
        public string Name { get; set; }
        public Area Area { get; set; }
        public List<SensorWifi> WifiSensors { get; set; }
        public List<SensorPIR> PIRSensors { get; set; }
        //public List<SensorTemperature> TemperatureSensors { get; set; }
        public List<SensorCO2> CO2Sensors { get; set; }
        public List<SensorLightActivated> LightActivatedSensors { get; set; }
        public List<SensorLumen> LumenSensors { get; set; }

        public Room(string name, Area area, List<SensorWifi> wifiSensors, List<SensorPIR> pirSensors, /*List<SensorTemperature> temperatureSensors,*/ List<SensorCO2> co2Sensors, List<SensorLightActivated> lightActivatedSensors, List<SensorLumen> lumenSensors)
        {
            Name = name;
            Area = area;
            WifiSensors = wifiSensors;
            PIRSensors = pirSensors;
            //TemperatureSensors = temperatureSensors;
            CO2Sensors = co2Sensors;
            LightActivatedSensors = lightActivatedSensors;
            LumenSensors = lumenSensors;
        }
    }
}
