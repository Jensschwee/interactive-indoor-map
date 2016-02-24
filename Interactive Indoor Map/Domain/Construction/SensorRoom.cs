using Domain.Sensors;
using System.Collections.Generic;
using Domain.Utility;

namespace Domain.Construction
{
    class SensorRoom : Room
    {
        public List<Sensor3DScanner> ThreeDScannerSensors { get; set; }
        public List<SensorPower> PowerSensors { get; set; }

        public SensorRoom(string name, Area area, List<SensorWifi> wifiSensors, List<SensorPIR> pirSensors, /*List<SensorTemperature> temperatureSensors,*/ List<SensorCO2> co2Sensors, List<SensorLightActivated> lightActivatedSensors, List<SensorLumen> lumenSensors, List<Sensor3DScanner> threeDScannerSensors, List<SensorPower> powerSensors) : base(name, area, wifiSensors, pirSensors, /*temperatureSensors,*/ co2Sensors, lightActivatedSensors, lumenSensors)
        {
            ThreeDScannerSensors = threeDScannerSensors;
            PowerSensors = powerSensors;
        }

        public int SensorRoomPowerConsumption()
        {
            var totalConsumption = 0;

            foreach (var sensor in PowerSensors)
            {
                totalConsumption += sensor.TotalConsumption;
            }

            return totalConsumption;
        }

        public int GetOccupants()
        {
            var occupants = 0;

            foreach (var sensor in ThreeDScannerSensors)
            {
                occupants += sensor.Occupants;
            }

            return occupants;
        }
    }
}
