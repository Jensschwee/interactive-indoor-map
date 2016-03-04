using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.BO;
using Website.BO.Utility;

namespace Website.Domain
{
    public class BuildingSetup
    {
        private Building building;
        private Floor cellarFloor;
        private Floor groundFloor;
        private Floor firstFloor;
        private Floor secondFloor;
        private Room Ø22_508_0;
        private Room Ø22_604_0;
        private Room Ø20_604_0;
        private Room Ø20_508a_0;
        private Sensor testSensor;


        public void SetupBuilding()
        {
            CreateBuilding();

            CreateFloors();

            CreateRooms();

            AssembleBuilding();

            HttpContext.Current.Application["Building"] = building;
        }

        private void CreateBuilding()
        {
            building = new Building();
            building.BuildingName = "Building 44";
            building.Occupants = 200;
            building.ColdWaterConsumption = 2200;
            building.HotWaterConsumption = 2100;
        }

        private void CreateFloors()
        {
            cellarFloor = new Floor(-1);
            cellarFloor.HardwareConsumption = 3500;
            cellarFloor.LightConsumption = 2400;
            cellarFloor.OtherConsumption = 700;
            cellarFloor.VentilationConsumption = 1300;
            cellarFloor.ColdWaterConsumption = 500;
            cellarFloor.HotWaterConsumption = 400;

            groundFloor = new Floor(0);
            groundFloor.HardwareConsumption = 4000;
            groundFloor.LightConsumption = 2000;
            groundFloor.OtherConsumption = 500;
            groundFloor.VentilationConsumption = 1500;
            groundFloor.ColdWaterConsumption = 700;
            groundFloor.HotWaterConsumption = 800;

            firstFloor = new Floor(1);
            firstFloor.HardwareConsumption = 5000;
            firstFloor.LightConsumption = 1500;
            firstFloor.OtherConsumption = 1000;
            firstFloor.VentilationConsumption = 2500;
            firstFloor.ColdWaterConsumption = 300;
            firstFloor.HotWaterConsumption = 250;

            secondFloor = new Floor(2);
            secondFloor.HardwareConsumption = 3200;
            secondFloor.LightConsumption = 900;
            secondFloor.OtherConsumption = 200;
            secondFloor.VentilationConsumption = 1800;
            secondFloor.ColdWaterConsumption = 1100;
            secondFloor.HotWaterConsumption = 1000;

            CreateSensors();
        }

        private void CreateSensors()
        {
            testSensor = new Sensor("Test Sensor", "Laptop");
            cellarFloor.Sensors.Add(testSensor);
        }

        private void CreateRooms()
        {
            Ø20_508a_0 = new Room("Ø20-508a-0", new Area(new List<Coordinates>
            {
                new Coordinates(10.430732667446136, 55.367447995895),
                new Coordinates(10.430542230606079, 55.36744037424566),
                new Coordinates(10.43051540851593, 55.36767054740808),
                new Coordinates(10.430711209774017, 55.367673596050246),
                new Coordinates(10.430732667446136, 55.367447995895)
            }))
            {
                Temperature = 24,
                CO2 = 100,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                IsLightActivated = true,
                Lumen = 90,
                IsMotionDetected = true,
                Occupants = 7
            };

            Ø22_508_0 = new Room("Ø22-508-0", new Area(new List<Coordinates>
            {
                new Coordinates(10.43104112148285, 55.36767664469221),
                new Coordinates(10.430856049060822, 55.36767207172922),
                new Coordinates(10.430874824523926, 55.367451044554315),
                new Coordinates(10.431067943572998, 55.36746171486007),
                new Coordinates(10.43104112148285, 55.36767664469221)
            }))
            {
                Temperature = 20.5,
                CO2 = 85,
                HardwareConsumption = 3700,
                VentilationConsumption = 2300,
                LightConsumption = 1100,
                OtherConsumption = 700,
                IsLightActivated = false,
                Lumen = 0,
                IsMotionDetected = false,
                Occupants = 0
            };

            Ø22_604_0 = new Room("Ø22-604-0", new Area(new List<Coordinates>
            {
                new Coordinates(10.430928468704224, 55.36698916998991),
                new Coordinates(10.431126952171324, 55.3669983160732),
                new Coordinates(10.431097447872162, 55.367223918792),
                new Coordinates(10.430896282196045, 55.36721629709953),
                new Coordinates(10.430928468704224, 55.36698916998991)
            }))
            {
                Temperature = 21.5,
                CO2 = 80,
                HardwareConsumption = 4200,
                VentilationConsumption = 1900,
                LightConsumption = 1900,
                OtherConsumption = 500,
                Lumen = 50,
                IsLightActivated = true,
                IsMotionDetected = true,
                Occupants = 5
            };

            Ø20_604_0 = new Room("Ø20_604_0", new Area(new List<Coordinates>
            {
                new Coordinates(10.430603921413422, 55.36697392651307),
                new Coordinates(10.430810451507568, 55.36698307259987),
                new Coordinates(10.430764853954315, 55.367210199744484),
                new Coordinates(10.430574417114258, 55.36719952937089),
                new Coordinates(10.430603921413422, 55.36697392651307)
            }))
            {
                Temperature = 22,
                CO2 = 70,
                HardwareConsumption = 2700,
                VentilationConsumption = 1700,
                LightConsumption = 1200,
                Lumen = 65,
                IsLightActivated = true,
                IsMotionDetected = false,
                Occupants = 1
            };
        }

        private void AssembleBuilding()
        {
            cellarFloor.Rooms.Add(Ø20_604_0);
            groundFloor.Rooms.Add(Ø22_508_0);
            groundFloor.Rooms.Add(Ø20_508a_0);
            groundFloor.Rooms.Add(Ø22_604_0);
            groundFloor.Rooms.Add(Ø20_604_0);
            firstFloor.Rooms.Add(Ø20_508a_0);
            firstFloor.Rooms.Add(Ø22_508_0);
            secondFloor.Rooms.Add(Ø22_604_0);

            building.Floors.Add(cellarFloor);
            building.Floors.Add(groundFloor);
            building.Floors.Add(firstFloor);
            building.Floors.Add(secondFloor);
        }
    }
}