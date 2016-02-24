using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Construction;
using Domain.Sensors;
using Domain.Utility;

namespace Domain
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                InitializeSensors();
                InitializeBuilding();
            }
        }

        private static void InitializeBuilding()
        {
            Area buildingArea = new Area();
            buildingArea.Vertices.Add(new Point(10.4, 55.3));
            buildingArea.Vertices.Add(new Point(10.5, 55.4));
            buildingArea.Vertices.Add(new Point(10.6, 55.5));
            buildingArea.Vertices.Add(new Point(10.7, 55.6));
            //Building building44 = new Building("Building 44", buildingArea);
        }

        private static void InitializeSensors()
        {
            List<Sensor3DScanner> ThreeDSensorScanners = new List<Sensor3DScanner>();
            //ThreeDSensorScanners.Add(new Sensor3DScanner());
        }
    }
}
