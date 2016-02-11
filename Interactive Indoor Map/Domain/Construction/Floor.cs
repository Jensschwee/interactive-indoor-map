using Domain.Sensors;
using Domain.Utility;
using System.Collections.Generic;

namespace Domain.Construction
{
    class Floor
    {
        public string Name { get; set; }
        public Area Area { get; set; }
        public int FloorNumber { get; set; }
        public List<Room> Rooms { get; set; }
        public List<SensorPower> PowerSensors { get; set; }

        public Floor(string name, Area area, int floorNumber, List<Room> rooms, List<SensorPower> powerSensors)
        {
            Name = name;
            Area = area;
            FloorNumber = floorNumber;
            Rooms = rooms;
            PowerSensors = powerSensors;
        }

        public int FloorPowerConsumption()
        {
            var totalConsumption = 0;

            foreach (var sensor in PowerSensors)
            {
                totalConsumption += sensor.TotalConsumption;
            }

            return totalConsumption;
        }
    }
}
