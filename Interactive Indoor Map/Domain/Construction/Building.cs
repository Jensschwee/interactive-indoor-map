using Domain.Sensors;
using Domain.Utility;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace Domain.Construction
{
    class Building
    {
        public string Name { get; set; }
        public Area Area { get; set; }
        public List<Floor> Floors { get; set; }
        public List<Sensor3DScanner> ThreeDScannerSensors { get; set; }

        public Building(string name, Area area, List<Floor> floors, List<Sensor3DScanner> threeDScannerSensors)
        {
            Name = name;
            Area = area;
            Floors = floors;
            ThreeDScannerSensors = threeDScannerSensors;
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
