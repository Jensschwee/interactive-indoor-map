using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Timers;
using System.Web;
using Website.Logic.BO;
using Website.Logic.BO.Utility;

namespace Website.Logic.Domain
{
    public class BuildingSetup
    {
        private Building building;
        private Floor cellarFloor;
        private Floor parterreFloor;
        private Floor groundFloor;
        private Floor firstFloor;
        private SensorRoom _testSensorRoomCellar1;
        private SensorRoom _testSensorRoomFirstFloor1;
        private SensorRoom _testSensorRoomFirstFloor2;
        private SensorRoom _testSensorRoomSecondFloor1;
        private SensorRoom _testSensorRoomSecondFloor2;
        private SensorRoom Ø22_606c_1;

        //Parterre Floor Rooms
        private SensorRoom Ø20_604_0;
        private SensorRoom Ø20_603_0;
        private SensorRoom Ø20_601b_0;
        private SensorRoom Ø20_511_0;
        private SensorRoom Ø20_510a_0;
        private SensorRoom Ø20_508a_0;
        private SensorRoom Ø22_604_0;
        private SensorRoom Ø22_603_0;
        private SensorRoom Ø22_601b_0;
        private SensorRoom Ø22_512a_0;
        private SensorRoom Ø22_511_0;
        private SensorRoom Ø22_510_0;
        private SensorRoom Ø22_508_0;

        //Ground Floor Rooms
        private SensorRoom Ø20_604b_1;
        private SensorRoom Ø20_603_1; 
        private SensorRoom Ø20_601b_1; 
        private SensorRoom Ø20_511_1; 
        private SensorRoom Ø20_510_1; 
        private SensorRoom Ø20_508a_1;
        private SensorRoom Ø22_508_1;
        private SensorRoom Ø22_510_1; 
        private SensorRoom Ø22_511_1; 
        private SensorRoom Ø22_601b_1; 
        private SensorRoom Ø22_603_1;
        private SensorRoom Ø22_604_1;
        private SensorlessRoom Ø21_602_1;
        private SensorlessRoom Ø21_511b_1;
        private SensorlessRoom Ø21_508b_1;
        private SensorlessRoom Ø21_600b_1;
        private SensorlessRoom Ø22_507_1;
        private SensorlessRoom Ø21_600c_1;
        private SensorlessRoom Ø20_606_1;
        private SensorlessRoom Ø20_600b_1;
        private SensorlessRoom Ø20_601a_1;
        private SensorlessRoom Ø21_600a_1;
        private SensorlessRoom Ø22_601a;
        private SensorlessRoom Ø22_512b_1;
        private SensorlessRoom UpperLeftUtilities;
        private SensorlessRoom Toilets;
        private SensorlessRoom LowerRightUtilities;

        //First Floor Rooms
        private SensorRoom Ø20_603c_2;
        private SensorRoom Ø20_601b_2;
        private SensorRoom Ø20_511_2;
        private SensorRoom Ø20_510b_2;
        private SensorRoom Ø22_603b_2;
        private SensorRoom Ø22_601b_2;
        private SensorRoom Ø22_511_2;
        private SensorRoom Ø22_510b_2;

        public void SetupBuilding()
        {
            //buildingDAL = new BuildingDAL();
            //building = buildingDAL.GetBuilding("Building 44");

            CreateBuilding();

            CreateFloors();

            CreateRooms();

            CreateParterreFloorRooms();
            CreateGroundFloorRooms();
            CreateGroundFloorSensorlessRooms();
            CreateFirstFloorRooms();

            //AssembleBuilding();
            AssembleActualBuilding();

            HttpContext.Current.Application["Building"] = building;

            //TestTimer();
            //saveDataToDB();
        }

        private void CreateBuilding()
        {
            building = new Building
            {
                ColdWaterConsumptionMax = 100000,
                HotWaterConsumptionMax = 100000,
                OccupantsMax = 10000,
                Name = "Building 44",
                Occupants = 200,
                ColdWaterConsumption = 2200,
                HotWaterConsumption = 2100
            };
        }

        private void CreateFloors()
        {
            cellarFloor = new Floor(-1)
            {
                FloorName = "Cellar",
                SurfaceArea = 2400,
                HardwareConsumptionMax = 10000,
                LightConsumptionMax = 10000,
                VentilationConsumptionMax = 10000,
                OtherConsumptionMax = 10000,
                ColdWaterConsumptionMax = 10000,
                HotWaterConsumptionMax = 10000,
                HardwareConsumption = 3500,
                LightConsumption = 2400,
                OtherConsumption = 700,
                VentilationConsumption = 1300,
                ColdWaterConsumption = 500,
                HotWaterConsumption = 400
            };

            parterreFloor = new Floor(0)
            {
                FloorName = "Parterre",
                SurfaceArea = 2400,
                HardwareConsumptionMax = 10000,
                LightConsumptionMax = 10000,
                VentilationConsumptionMax = 10000,
                OtherConsumptionMax = 10000,
                ColdWaterConsumptionMax = 10000,
                HotWaterConsumptionMax = 10000,
                HardwareConsumption = 4000,
                LightConsumption = 2000,
                OtherConsumption = 500,
                VentilationConsumption = 1500,
                ColdWaterConsumption = 700,
                HotWaterConsumption = 800
            };

            groundFloor = new Floor(1)
            {
                FloorName = "Ground Floor",
                SurfaceArea = 2400,
                HardwareConsumptionMax = 10000,
                LightConsumptionMax = 10000,
                VentilationConsumptionMax = 10000,
                OtherConsumptionMax = 10000,
                ColdWaterConsumptionMax = 10000,
                HotWaterConsumptionMax = 10000,
                HardwareConsumption = 5000,
                LightConsumption = 1500,
                OtherConsumption = 1000,
                VentilationConsumption = 2500,
                ColdWaterConsumption = 300,
                HotWaterConsumption = 250
            };

            firstFloor = new Floor(2)
            {
                FloorName = "First Floor",
                SurfaceArea = 2400,
                HardwareConsumptionMax = 10000,
                LightConsumptionMax = 10000,
                VentilationConsumptionMax = 10000,
                OtherConsumptionMax = 10000,
                ColdWaterConsumptionMax = 10000,
                HotWaterConsumptionMax = 10000,
                HardwareConsumption = 3200,
                LightConsumption = 900,
                OtherConsumption = 200,
                VentilationConsumption = 1800,
                ColdWaterConsumption = 1100,
                HotWaterConsumption = 1000
            };

        }

        private void CreateParterreFloorRooms()
        {
            Ø20_604_0 = new SensorRoom("Ø20-604-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.430841441,55.366968517),
                new Coordinates(10.430653052,55.3669603690001),
                new Coordinates(10.430635802,55.367089175),
                new Coordinates(10.430824193,55.367097324)
            }))
            {
                RoomType = RoomType.Studyzone,
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 162
            };

            Ø20_603_0 = new SensorRoom("Ø20-603-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.430824193,55.367097324),
                new Coordinates(10.430635802,55.367089175),
                new Coordinates(10.4306243130001,55.3671749660001),
                new Coordinates(10.4308127080001,55.367183089)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 108
            };

            Ø20_601b_0 = new SensorRoom("Ø20-601b-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.430612384,55.367264042),
                new Coordinates(10.4308007770001,55.3672721890001),
                new Coordinates(10.4308127080001,55.367183089),
                new Coordinates(10.4306243130001,55.3671749660001)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 111
            };

            Ø20_511_0 = new SensorRoom("Ø20-511-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4307828560001,55.367406014),
                new Coordinates(10.430594462,55.367397866),
                new Coordinates(10.4305840530001,55.367475588),
                new Coordinates(10.430772448,55.367483737)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 98
            };

            Ø20_510a_0 = new SensorRoom("Ø20-510a-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4305754280001,55.3675399900001),
                new Coordinates(10.4307638240001,55.3675481390001),
                new Coordinates(10.430772448,55.367483737),
                new Coordinates(10.4305840530001,55.367475588)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 80
            };

            Ø20_508a_0 = new SensorRoom("Ø20-508a-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4307638240001,55.3675481390001),
                new Coordinates(10.4305754280001,55.3675399900001),
                new Coordinates(10.4305581780001,55.3676687940001),
                new Coordinates(10.4307465750001,55.367676943)
            }))
            {
                RoomType = RoomType.Studyzone,
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 162
            };

            Ø22_604_0 = new SensorRoom("Ø22-604-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4311268000001,55.366980862),
                new Coordinates(10.430940122,55.3669727860001),
                new Coordinates(10.430922874,55.3671015880001),
                new Coordinates(10.43110955,55.367109665)
            }))
            {
                RoomType = RoomType.Studyzone,
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 162
            };

            Ø22_603_0 = new SensorRoom("Ø22-603-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.43110955,55.367109665),
                new Coordinates(10.430922874,55.3671015880001),
                new Coordinates(10.4309142490001,55.3671659950001),
                new Coordinates(10.4311009250001,55.367174069)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 80
            };

            Ø22_601b_0 = new SensorRoom("Ø22-601b-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4308994830001,55.367276254),
                new Coordinates(10.431086158,55.367284328),
                new Coordinates(10.4311009250001,55.367174069),
                new Coordinates(10.4309142490001,55.3671659950001)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 139
            };

            Ø22_512a_0= new SensorRoom("Ø22-512a-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.43107259,55.3673856410001),
                new Coordinates(10.430885916,55.3673775670001),
                new Coordinates(10.4308797510001,55.3674236040001),
                new Coordinates(10.431066425,55.3674316780001)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 57
            };

            Ø22_511_0 = new SensorRoom("Ø22-511-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.431066425,55.3674316780001),
                new Coordinates(10.4308797510001,55.3674236040001),
                new Coordinates(10.430871127,55.367488006),
                new Coordinates(10.4310578000001,55.3674960800001)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 80
            };

            Ø22_510_0 = new SensorRoom("Ø22-510-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4310578000001,55.3674960800001),
                new Coordinates(10.430871127,55.367488006),
                new Coordinates(10.4308625030001,55.3675524080001),
                new Coordinates(10.4310491750001,55.367560482)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 80
            };

            Ø22_508_0 = new SensorRoom("Ø22-508-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4310491750001,55.367560482),
                new Coordinates(10.4308625030001,55.3675524080001),
                new Coordinates(10.4308452550001,55.367681212),
                new Coordinates(10.4310319250001,55.367689286)
            }))
            {
                RoomType = RoomType.Studyzone,
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 162
            };
        }

        private void CreateGroundFloorRooms()
        {
            Ø20_604b_1 = new SensorRoom("Ø20-604b-1", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.430624295, 55.3671750980001),
                new Coordinates(10.430809507, 55.3671831080001),
                new Coordinates(10.430821, 55.3670972850001),
                new Coordinates(10.4306357890001, 55.3670892740001)
            }))
            {
                RoomType = RoomType.Studyzone,
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 24,
                CO2 = 650,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = true,
                Lumen = 400,
                Motion = true,
                Occupants = 15,
                WifiClients = 10,
                SurfaceArea = 125
            };

            Ø22_603_1 = new SensorRoom("Ø22-603-1", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.430624295,55.3671750980001),
                new Coordinates(10.430809507,55.3671831080001),
                new Coordinates(10.430821,55.3670972850001),
                new Coordinates(10.4306357890001,55.3670892740001)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 40,
                WifiClientsMax = 25,
                Temperature = 22,
                CO2 = 600,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = true,
                Lumen = 200,
                Motion = true,
                Occupants = 17,
                WifiClients = 26,
                SurfaceArea = 80
            };

            Ø20_601b_1 = new SensorRoom("Ø20-601b-1", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.430795946, 55.3672843740001),
                new Coordinates(10.430610734, 55.367276363),
                new Coordinates(10.430600079, 55.367355918),
                new Coordinates(10.4307852920001, 55.3673639290001)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 23,
                CO2 = 400,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = true,
                Lumen = 200,
                Motion = true,
                Occupants = 25,
                WifiClients = 26,
                SurfaceArea = 111
            };

            Ø20_510_1 = new SensorRoom("Ø20-510-1", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.43076928, 55.36748349),
                new Coordinates(10.430584067, 55.3674754790001),
                new Coordinates(10.4305754100001, 55.367540122),
                new Coordinates(10.430760623, 55.3675481330001)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 20,
                WifiClientsMax = 25,
                Temperature = 23,
                CO2 = 600,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = false,
                Lumen = 0,
                Motion = false,
                Occupants = 0,
                WifiClients = 0,
                SurfaceArea = 80
            };

            Ø20_511_1 = new SensorRoom("Ø20-511-1", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.43077966,55.367405983),
                new Coordinates(10.430594447,55.367397972),
                new Coordinates(10.430584067,55.3674754790001),
                new Coordinates(10.43076928,55.36748349)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 20,
                WifiClientsMax = 25,
                Temperature = 24,
                CO2 = 700,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = true,
                Lumen = 200,
                Motion = true,
                Occupants = 27,
                WifiClients = 26,
                SurfaceArea = 97
            };

            Ø20_508a_1 = new SensorRoom("Ø20-508a-1", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.430723347,55.3675465210001),
                new Coordinates(10.4305754100001,55.367540122),
                new Coordinates(10.4305582060001,55.3676685890001),
                new Coordinates(10.4307061420001,55.367674987)
            }))
            {
                RoomType = RoomType.Studyzone,
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 25,
                Temperature = 24,
                CO2 = 400,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 3,
                SurfaceArea = 125
            };

            Ø22_508_1 = new SensorRoom("Ø22-508-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4309014460001, 55.367554225),
                new Coordinates(10.4308842190001, 55.3676828480001),
                new Coordinates(10.4310319320001, 55.367689237),
                new Coordinates(10.4310491580001, 55.3675606140001)
            }))
            {
                RoomType = RoomType.Studyzone,
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 24,
                CO2 = 100,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = true,
                Lumen = 90,
                Motion = true,
                Occupants = 7,
                WifiClients = 6,
                SurfaceArea = 125
            };

            Ø22_510_1 = new SensorRoom("Ø22-510-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.431057781, 55.3674962250001),
                new Coordinates(10.4308716730001, 55.3674881760001),
                new Coordinates(10.4308630510001, 55.3675525640001),
                new Coordinates(10.4310491580001, 55.3675606140001)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 24,
                CO2 = 100,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = true,
                Lumen = 90,
                Motion = true,
                Occupants = 7,
                WifiClients = 6,
                SurfaceArea = 80
            };

            Ø22_601b_1 = new SensorRoom("Ø22-601b-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4311009210001, 55.3671740930001),
                new Coordinates(10.43091481, 55.3671660420001),
                new Coordinates(10.4308999900001, 55.367276712),
                new Coordinates(10.4310861000001, 55.3672847620001)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 24,
                CO2 = 100,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = true,
                Lumen = 90,
                Motion = true,
                Occupants = 7,
                WifiClients = 6,
                SurfaceArea = 139
            };

            Ø22_604_1 = new SensorRoom("Ø22-604-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4309793780001,55.366974462),
                new Coordinates(10.430962113,55.3671033680001),
                new Coordinates(10.431109539,55.3671097450001),
                new Coordinates(10.431126803,55.3669808390001)
            }))
            {
                RoomType = RoomType.Studyzone,
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 24,
                CO2 = 100,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = true,
                Lumen = 90,
                Motion = true,
                Occupants = 7,
                WifiClients = 6,
                SurfaceArea = 125
            };

            Ø20_604b_1 = new SensorRoom("Ø20-604b-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.430801009,55.3669667990001),
                new Coordinates(10.4306530480001,55.366960399),
                new Coordinates(10.4306357890001,55.3670892740001),
                new Coordinates(10.43078375,55.367095674)
            }))
            {
                RoomType = RoomType.Studyzone,
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 25,
                Temperature = 23,
                CO2 = 450,
                HardwareConsumption = 950,
                VentilationConsumption = 750,
                OtherConsumption = 300,
                LightConsumption = 700,
                HardwareConsumptionMax = 1000,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 180,
                Motion = true,
                Occupants = 10,
                WifiClients = 15,
                SurfaceArea = 125
            };

            Ø20_603_1 = new SensorRoom("Ø20-603-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.43091481,55.3671660420001),
                new Coordinates(10.4311009210001,55.3671740930001),
                new Coordinates(10.431109539,55.3671097450001),
                new Coordinates(10.430923427,55.367101694)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 20,
                WifiClientsMax = 25,
                Temperature = 22.5,
                CO2 = 200,
                HardwareConsumption = 0,
                VentilationConsumption = 100,
                OtherConsumption = 0,
                LightConsumption = 0,
                HardwareConsumptionMax = 100,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = false,
                Lumen = 0,
                Motion = false,
                Occupants = 0,
                WifiClients = 0,
                SurfaceArea = 108
            };

            Ø20_601b_1 = new SensorRoom("Ø20-601b-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4306123600001,55.367264219),
                new Coordinates(10.4307975720001,55.36727223),
                new Coordinates(10.430809507,55.3671831080001),
                new Coordinates(10.430624295,55.3671750980001)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 20,
                WifiClientsMax = 25,
                Temperature = 22,
                CO2 = 280,
                HardwareConsumption = 200,
                VentilationConsumption = 450,
                OtherConsumption = 80,
                LightConsumption = 550,
                HardwareConsumptionMax = 1000,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 100,
                Light = true,
                Lumen = 150,
                Motion = true,
                Occupants = 3,
                WifiClients = 4,
                SurfaceArea = 111
            };

            Ø22_511_1 = new SensorRoom("Ø22-511-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.431072543,55.3673859940001),
                new Coordinates(10.4308864340001,55.3673779440001),
                new Coordinates(10.4308716730001,55.3674881760001),
                new Coordinates(10.431057781,55.3674962250001)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 139
            };
        }

        private void CreateFirstFloorRooms()
        {
            Ø20_603c_2 = new SensorRoom("Ø20-603c-2", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.431072543,55.3673859940001),
                new Coordinates(10.4308864340001,55.3673779440001),
                new Coordinates(10.4308716730001,55.3674881760001),
                new Coordinates(10.431057781,55.3674962250001)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 53
            };

            Ø20_601b_2 = new SensorRoom("Ø20-601b-2", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4308162180001,55.3671617540001),
                new Coordinates(10.4306271780001,55.3671535780001),
                new Coordinates(10.43061241,55.367263849),
                new Coordinates(10.430801452,55.3672720260001)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 139
            };
            
            Ø20_511_2 = new SensorRoom("Ø20-511-2", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.430783557,55.3674056510001),
                new Coordinates(10.4305945140001,55.367397474),
                new Coordinates(10.4305840530001,55.367475589),
                new Coordinates(10.430773097,55.367483765)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 98
            };

            Ø20_510b_2 = new SensorRoom("Ø20-510b-2", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.430773097,55.367483765),
                new Coordinates(10.4305840530001,55.367475589),
                new Coordinates(10.4305783130001,55.3675184460001),
                new Coordinates(10.430767358,55.36752662)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 53
            };

            Ø22_603b_2 = new SensorRoom("Ø22-603b-2", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.431106696,55.367130978),
                new Coordinates(10.4309197540001,55.3671228920001),
                new Coordinates(10.430913984,55.3671659830001),
                new Coordinates(10.4311009250001,55.367174069)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 53
            };

            Ø22_601b_2 = new SensorRoom("Ø22-601b-2", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4311009250001,55.367174069),
                new Coordinates(10.430913984,55.3671659830001),
                new Coordinates(10.430899213,55.367276288),
                new Coordinates(10.431086153,55.3672843740001)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 139
            };

            Ø22_601b_2 = new SensorRoom("Ø22-601b-2", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4310725510001,55.3673859370001),
                new Coordinates(10.430885613,55.3673778510001),
                new Coordinates(10.4308708630001,55.367487995),
                new Coordinates(10.4310578000001,55.3674960810001)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 139
            };

            Ø22_510b_2 = new SensorRoom("Ø22-510b-2", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.430865135,55.3675307730001),
                new Coordinates(10.4310520710001,55.367538859),
                new Coordinates(10.4310578000001,55.3674960810001),
                new Coordinates(10.4308708630001,55.367487995)
            }))
            {
                TemperatureMax = 25,
                TemperatureMin = 20,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                WifiClientsMax = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                HardwareConsumptionMax = 400,
                LightConsumptionMax = 800,
                OtherConsumptionMax = 500,
                VentilationConsumptionMax = 1000,
                Light = true,
                Lumen = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 8,
                SurfaceArea = 53
            };
        }

        private void CreateGroundFloorSensorlessRooms()
        {
            Ø21_602_1 = new SensorlessRoom("Ø21-602-1", new List<Coordinates>()
             {
                new Coordinates(10.4309046290001,55.3672420730001),
                new Coordinates(10.430923427,55.367101694),
                new Coordinates(10.430962113,55.3671033680001),
                new Coordinates(10.4309793780001,55.366974462),
                new Coordinates(10.4309406890001,55.3669727880001),
                new Coordinates(10.4309456570001,55.36693569),
                new Coordinates(10.4309397540001,55.3669354350001),
                new Coordinates(10.4309393720001,55.366938288),
                new Coordinates(10.430849659,55.366934407),
                new Coordinates(10.430850041,55.3669315540001),
                new Coordinates(10.4308432330001,55.3669312590001),
                new Coordinates(10.4308382580001,55.36696841),

                new Coordinates(10.430801009,55.3669667990001),
                new Coordinates(10.43078375,55.367095674),
                new Coordinates(10.430820999,55.3670972850001),
                new Coordinates(10.430802203,55.3672376430001),
                new Coordinates(10.4309046290001,55.3672420730001),
                new Coordinates(10.430823977,55.367075051),
                new Coordinates(10.4308353340001,55.3669902400001),
                new Coordinates(10.4309377590001,55.3669946700001),
                new Coordinates(10.4309264020001,55.3670794810001),
                new Coordinates(10.430823977,55.367075051),
            })
            {
                RoomType = RoomType.Hallway
            };
            Ø22_507_1 = new SensorlessRoom("Ø22-507-1", new List<Coordinates>()
             {
                new Coordinates(10.4306530480001,55.366960399),
                new Coordinates(10.4308382580001,55.36696841),
                new Coordinates(10.4308432330001,55.3669312590001),
                new Coordinates(10.430658023,55.366923248),
                new Coordinates(10.4306530480001,55.366960399)
            })
            {
                RoomType = RoomType.Stairs
            };

            Ø21_600c_1 = new SensorlessRoom("Ø22-507-1", new List<Coordinates>()
             {
                new Coordinates(10.4310844660001,55.3672969610001),
                new Coordinates(10.4308983560001,55.3672889100001),
                new Coordinates(10.43089724,55.3672972480001),
                new Coordinates(10.430911,55.3672978430001),
                new Coordinates(10.430911109,55.367297029),
                new Coordinates(10.430963816,55.367299309),
                new Coordinates(10.4309607220001,55.367322421),
                new Coordinates(10.430908013,55.367320142),
                new Coordinates(10.4309081230001,55.3673193230001),
                new Coordinates(10.430894364,55.367318728),
                new Coordinates(10.4308880140001,55.367366148),
                new Coordinates(10.431074123,55.3673741980001),
                new Coordinates(10.4310844660001,55.3672969610001)
            })
            {
                RoomType = RoomType.Stairs
            };

            Ø21_508b_1 = new SensorlessRoom("Ø21-508b-1", new List<Coordinates>()
            {
                new Coordinates(10.430835212,55.367715242),
                new Coordinates(10.4308398060001,55.367680927),
                new Coordinates(10.4308842190001,55.3676828480001),
                new Coordinates(10.4309014460001,55.367554225),
                new Coordinates(10.430723347,55.3675465210001),
                new Coordinates(10.4307061420001,55.367674987),
                new Coordinates(10.430750275,55.367676896),
                new Coordinates(10.430745659,55.3677113690001),
                new Coordinates(10.430835212,55.367715242),
                new Coordinates(10.430858947,55.367574189),
                new Coordinates(10.4308475240001,55.3676595090001),
                new Coordinates(10.4307486020001,55.3676552300001),
                new Coordinates(10.4307600280001,55.36756991),
                new Coordinates(10.430858947,55.367574189),

            })
            {
                RoomType = RoomType.Hallway
            };

            Ø21_511b_1 = new SensorlessRoom("Ø21-511b-1", new List<Coordinates>()
             {
                new Coordinates(10.430881862,55.367412089),
                new Coordinates(10.430779435,55.367407659),
                new Coordinates(10.430760623,55.3675481330001),
                new Coordinates(10.4308630510001,55.3675525640001),
                new Coordinates(10.430881862,55.367412089)
            })
            {
                RoomType = RoomType.Hallway
            };

            Ø21_600b_1 = new SensorlessRoom("Ø21-600b-1", new List<Coordinates>()
             {
                new Coordinates(10.430802204,55.3672376430001),
                new Coordinates(10.4307975720001,55.36727223),
                new Coordinates(10.430795946,55.3672843740001),
                new Coordinates(10.4307852920001,55.3673639290001),
                new Coordinates(10.430782655,55.3673836190001),
                new Coordinates(10.43078122,55.3673943360001),
                new Coordinates(10.43077966,55.367405983),
                new Coordinates(10.430779435,55.367407659),
                new Coordinates(10.430881862,55.367412089),
                new Coordinates(10.4308864340001,55.3673779440001),
                new Coordinates(10.4308880140001,55.367366148),
                new Coordinates(10.430894364,55.367318728),
                new Coordinates(10.4309081230001,55.3673193230001),
                new Coordinates(10.430911,55.3672978430001),
                new Coordinates(10.43089724,55.3672972480001),
                new Coordinates(10.430898357,55.3672889100001),
                new Coordinates(10.4308999900001,55.367276712),
                new Coordinates(10.4309046290001,55.3672420730001),
                new Coordinates(10.430802204,55.3672376430001)
            })
            {
                RoomType = RoomType.Hallway
            };

            Ø20_606_1 = new SensorlessRoom("Ø20-606-1", new List<Coordinates>()
            {
                new Coordinates(10.4310319320001,55.367689237),
                new Coordinates(10.4308398060001,55.367680927),
                new Coordinates(10.430835212,55.367715242),
                new Coordinates(10.430835319,55.367715247),
                new Coordinates(10.430834937,55.3677181),
                new Coordinates(10.4310269540001,55.367726406),
                new Coordinates(10.4310319320001,55.367689237)
            })
            {
                RoomType = RoomType.Stairs
            };

            Ø20_600b_1 = new SensorlessRoom("Ø20-600b-1", new List<Coordinates>()
            {
                new Coordinates(10.430795946,55.3672843740001),
                new Coordinates(10.430610734,55.367276363),
                new Coordinates(10.430600079,55.367355918),
                new Coordinates(10.4307852920001,55.3673639290001),
                new Coordinates(10.430795946,55.3672843740001)
            })
            {
                RoomType = RoomType.Hallway
            };

            Ø20_601a_1 = new SensorlessRoom("Ø20-601a-1", new List<Coordinates>()
            {
                new Coordinates(10.430610734,55.367276363),
                new Coordinates(10.430795946,55.3672843740001),
                new Coordinates(10.4307975720001,55.36727223),
                new Coordinates(10.4306123600001,55.367264219),
                new Coordinates(10.430610734,55.367276363)
            })
            {
                RoomType = RoomType.Hallway
            };

            Ø21_600a_1 = new SensorlessRoom("Ø21-600a-1", new List<Coordinates>()
            {
                new Coordinates(10.430963816,55.367299309),
                new Coordinates(10.430911109,55.367297029),
                new Coordinates(10.430908013,55.367320142),
                new Coordinates(10.4309607220001,55.367322421),
                new Coordinates(10.430963816,55.367299309)
            })
            {
                RoomType = RoomType.Elevator
            };

            Ø22_601a = new SensorlessRoom("Ø22-601a", new List<Coordinates>()
            {
                new Coordinates(10.4308983560001,55.3672889100001),
                new Coordinates(10.4310844660001,55.3672969610001),
                new Coordinates(10.4310861000001,55.3672847620001),
                new Coordinates(10.4308999900001,55.367276712),
                new Coordinates(10.4308983560001,55.3672889100001)
            })
            {
                RoomType = RoomType.Elevator
            };

            Ø22_512b_1 = new SensorlessRoom("Ø22-512b-1", new List<Coordinates>()
            {
                new Coordinates(10.431074123,55.3673741980001),
                new Coordinates(10.4308880140001,55.367366148),
                new Coordinates(10.4308864340001,55.3673779440001),
                new Coordinates(10.431072543,55.3673859940001),
                new Coordinates(10.431074123,55.3673741980001)
            })
            {
                RoomType = RoomType.Elevator
            };

            UpperLeftUtilities = new SensorlessRoom("UpperLeftUtilities", new List<Coordinates>()
            {
                new Coordinates(10.4305582060001,55.3676685890001),
                new Coordinates(10.4305532070001,55.3677059140001),
                new Coordinates(10.4307452240001,55.36771422),
                new Coordinates(10.430750275,55.367676896),
                new Coordinates(10.4305582060001,55.3676685890001)
            })
            {
                RoomType = RoomType.Utility
            };

            Toilets = new SensorlessRoom("Toilets", new List<Coordinates>()
            {
                new Coordinates(10.430594447, 55.367397972),
                new Coordinates(10.430600079, 55.367355918),
                new Coordinates(10.4307852920001, 55.3673639290001),
                new Coordinates(10.43077966, 55.367405983),
                new Coordinates(10.430594447, 55.367397972)
            })
            {
                RoomType = RoomType.Toilet
            };

            LowerRightUtilities = new SensorlessRoom("LowerRightUtilities", new List<Coordinates>()
            {
                new Coordinates(10.431131771, 55.3669437400001),
                new Coordinates(10.431126803, 55.3669808390001),
                new Coordinates(10.4309406890001, 55.3669727880001),
                new Coordinates(10.4309456570001, 55.36693569),
                new Coordinates(10.431131771, 55.3669437400001)
            })
            {
                RoomType = RoomType.Utility
            };
        }

        private void CreateRooms()
        {
            _testSensorRoomCellar1 = new SensorRoom("_testSensorRoomCellar1", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.430542230606079, 55.36744037424566),
                new Coordinates(10.430711209774017, 55.367673596050246),
                new Coordinates(10.43051540851593, 55.36767054740808),
                new Coordinates(10.430732667446136, 55.367447995895)
            }))
            {
                TemperatureMax = 25,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                Temperature = 24,
                CO2 = 100,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = true,
                Lumen = 90,
                Motion = true,
                Occupants = 7,
                WifiClients = 6,
                SurfaceArea = 7
            };

            _testSensorRoomFirstFloor1 = new SensorRoom("_testSensorRoomFirstFloor1", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.431097447872162, 55.367223918792),
                new Coordinates(10.430896282196045, 55.36721629709953),
                new Coordinates(10.430928468704224, 55.36698916998991),
                new Coordinates(10.431126952171324, 55.3669983160732)
            }))
            {
                TemperatureMax = 25,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                Temperature = 24,
                CO2 = 100,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = true,
                Lumen = 90,
                Motion = true,
                Occupants = 7,
                WifiClients = 6,
                SurfaceArea = 7
            };

            _testSensorRoomFirstFloor2 = new SensorRoom("_testSensorRoomFirstFloor2", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.430764853954315, 55.367210199744484),
                new Coordinates(10.430574417114258, 55.36719952937089),
                new Coordinates(10.430603921413422, 55.36697392651307),
                new Coordinates(10.430810451507568, 55.36698307259987)
            }))
            {
                TemperatureMax = 25,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                Temperature = 24,
                CO2 = 100,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = true,
                Lumen = 90,
                Motion = true,
                Occupants = 7,
                WifiClients = 6,
                SurfaceArea = 7
            };

            _testSensorRoomSecondFloor1 = new SensorRoom("_testSensorRoomSecondFloor1", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.430542230606079, 55.36744037424566),
                new Coordinates(10.430711209774017, 55.367673596050246),
                new Coordinates(10.43051540851593, 55.36767054740808),
                new Coordinates(10.430732667446136, 55.367447995895)
            }))
            {
                TemperatureMax = 25,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                Temperature = 24,
                CO2 = 100,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = true,
                Lumen = 90,
                Motion = true,
                Occupants = 7,
                WifiClients = 6,
                WifiClientsMax = 15,
                SurfaceArea = 7
            };

            _testSensorRoomSecondFloor2 = new SensorRoom("_testSensorRoomSecondFloor2", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.43104112148285, 55.36767664469221),
                new Coordinates(10.430856049060822, 55.36767207172922),
                new Coordinates(10.430874824523926, 55.367451044554315),
                new Coordinates(10.431067943572998, 55.36746171486007)
            }))
            {
                TemperatureMax = 25,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                Temperature = 24,
                CO2 = 100,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = true,
                Lumen = 90,
                Motion = true,
                Occupants = 7,
                WifiClients = 6,
                WifiClientsMax = 15,
                SurfaceArea = 7
            };

            Ø20_508a_0 = new SensorRoom("Ø20-508a-0", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.430542230606079, 55.36744037424566),
                new Coordinates(10.430711209774017, 55.367673596050246),
                new Coordinates(10.43051540851593, 55.36767054740808),
                new Coordinates(10.430732667446136, 55.367447995895)
            }))
            {
                TemperatureMax = 25,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                Temperature = 24,
                CO2 = 100,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = true,
                Lumen = 90,
                Motion = true,
                Occupants = 7,
                WifiClients = 6,
                WifiClientsMax = 15,
                SurfaceArea = 7

            };

            Ø22_508_0 = new SensorRoom("Ø22-508-0", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.4310491750001,55.367560482),
                new Coordinates(10.4308625030001,55.3675524080001),
                new Coordinates(10.4308452550001,55.367681212),
                new Coordinates(10.4310319250001,55.367689286)
            }))
            {
                TemperatureMax = 25,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                Temperature = 20.5,
                CO2 = 85,
                HardwareConsumption = 3700,
                VentilationConsumption = 2300,
                LightConsumption = 1100,
                OtherConsumption = 700,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = false,
                Lumen = 0,
                Motion = false,
                Occupants = 0,
                WifiClients = 0,
                WifiClientsMax = 15,
                SurfaceArea = 7
            };

            Ø22_604_0 = new SensorRoom("Ø22-604-0", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.431097447872162, 55.367223918792),
                new Coordinates(10.430896282196045, 55.36721629709953),
                new Coordinates(10.430928468704224, 55.36698916998991),
                new Coordinates(10.431126952171324, 55.3669983160732)
            }))
            {
                TemperatureMax = 25,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                Temperature = 21.5,
                CO2 = 80,
                HardwareConsumption = 4200,
                VentilationConsumption = 1900,
                LightConsumption = 1900,
                OtherConsumption = 500,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Lumen = 50,
                Light = true,
                Motion = true,
                Occupants = 5,
                WifiClients = 6,
                WifiClientsMax = 15,
                SurfaceArea = 7
            };

            Ø20_604_0 = new SensorRoom("Ø20-604-0", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.430764853954315, 55.367210199744484),
                new Coordinates(10.430574417114258, 55.36719952937089),
                new Coordinates(10.430603921413422, 55.36697392651307),
                new Coordinates(10.430810451507568, 55.36698307259987)
            }))
            {
                TemperatureMax = 25,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                Temperature = 22,
                CO2 = 70,
                HardwareConsumption = 2700,
                VentilationConsumption = 1700,
                LightConsumption = 1200,
                OtherConsumption = 500,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Lumen = 65,
                Light = true,
                Motion = false,
                Occupants = 1,
                WifiClients = 1,
                WifiClientsMax = 15,
                SurfaceArea = 7
            };


            Ø22_606c_1 = new SensorRoom("Ø22-606c-1", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.43088801675897,55.36700263483737),
                new Coordinates(10.43103473095622,55.36700515385672),
                new Coordinates(10.43102477942718,55.36711676739688),
                new Coordinates(10.43087766380805,55.3671124653335)
            }))
            {
                TemperatureMax = 25,
                CO2Max = 1000,
                LumenMax = 600,
                OccupantsMax = 50,
                Temperature = 24,
                CO2 = 100,
                HardwareConsumption = 4000,
                VentilationConsumption = 2500,
                OtherConsumption = 1000,
                LightConsumption = 3000,
                HardwareConsumptionMax = 5000,
                LightConsumptionMax = 3000,
                OtherConsumptionMax = 3000,
                VentilationConsumptionMax = 5000,
                Light = true,
                Lumen = 90,
                Motion = true,
                Occupants = 7,
                WifiClients = 6,
                WifiClientsMax = 15,
                SurfaceArea = 7
            };
        }

        private void AssembleActualBuilding()
        {
            cellarFloor.Rooms.Add(Ø20_510_1);
            //Rooms
            parterreFloor.Rooms.Add(Ø20_604_0);
            parterreFloor.Rooms.Add(Ø20_603_0);
            parterreFloor.Rooms.Add(Ø20_601b_0);
            parterreFloor.Rooms.Add(Ø20_511_0);
            parterreFloor.Rooms.Add(Ø20_510a_0);
            parterreFloor.Rooms.Add(Ø20_508a_0);
            parterreFloor.Rooms.Add(Ø22_604_0);
            parterreFloor.Rooms.Add(Ø22_603_0);
            parterreFloor.Rooms.Add(Ø22_601b_0);
            parterreFloor.Rooms.Add(Ø22_512a_0);
            parterreFloor.Rooms.Add(Ø22_511_0);
            parterreFloor.Rooms.Add(Ø22_510_0);
            parterreFloor.Rooms.Add(Ø22_508_0);
            groundFloor.Rooms.Add(Ø20_510_1);
            groundFloor.Rooms.Add(Ø20_601b_1);
            groundFloor.Rooms.Add(Ø20_604b_1);
            groundFloor.Rooms.Add(Ø22_510_1);
            groundFloor.Rooms.Add(Ø22_508_1);
            groundFloor.Rooms.Add(Ø22_601b_1);
            groundFloor.Rooms.Add(Ø20_603_1);
            groundFloor.Rooms.Add(Ø20_508a_1);
            groundFloor.Rooms.Add(Ø20_511_1);
            groundFloor.Rooms.Add(Ø22_604_1);
            groundFloor.Rooms.Add(Ø22_603_1);
            groundFloor.Rooms.Add(Ø22_511_1);
            firstFloor.Rooms.Add(Ø20_603c_2);
            firstFloor.Rooms.Add(Ø20_601b_2);
            firstFloor.Rooms.Add(Ø20_511_2);
            firstFloor.Rooms.Add(Ø20_510b_2);
            firstFloor.Rooms.Add(Ø22_603b_2);
            firstFloor.Rooms.Add(Ø22_601b_2);
            firstFloor.Rooms.Add(Ø22_511_2);
            firstFloor.Rooms.Add(Ø22_510b_2);
            //SensorlessRooms
            groundFloor.Rooms.Add(Ø21_602_1);
            groundFloor.Rooms.Add(Ø21_511b_1);
            groundFloor.Rooms.Add(Ø21_600b_1);
            groundFloor.Rooms.Add(Ø21_508b_1);
            groundFloor.Rooms.Add(Ø22_507_1);
            groundFloor.Rooms.Add(Ø21_600c_1);
            groundFloor.Rooms.Add(Ø20_606_1);
            groundFloor.Rooms.Add(Ø20_600b_1);
            groundFloor.Rooms.Add(Ø22_512b_1);
            groundFloor.Rooms.Add(Ø21_600a_1);
            groundFloor.Rooms.Add(Ø22_601a);
            groundFloor.Rooms.Add(Ø20_601a_1);
            groundFloor.Rooms.Add(UpperLeftUtilities);
            groundFloor.Rooms.Add(Toilets);
            groundFloor.Rooms.Add(LowerRightUtilities);

            building.Floors.Add(cellarFloor);
            building.Floors.Add(parterreFloor);
            building.Floors.Add(groundFloor);
            building.Floors.Add(firstFloor);
        }

        private void AssembleBuilding()
        {
            cellarFloor.Rooms.Add(_testSensorRoomCellar1);
            parterreFloor.Rooms.Add(Ø22_508_0);
            parterreFloor.Rooms.Add(Ø20_508a_0);
            parterreFloor.Rooms.Add(Ø22_604_0);
            //parterreFloor.Rooms.Add(Ø20_606_1);
            //parterreFloor.Rooms.Add(Ø22_606c_1);
            groundFloor.Rooms.Add(_testSensorRoomFirstFloor1);
            groundFloor.Rooms.Add(_testSensorRoomFirstFloor2);
            firstFloor.Rooms.Add(_testSensorRoomSecondFloor1);
            firstFloor.Rooms.Add(_testSensorRoomSecondFloor2);

            building.Floors.Add(cellarFloor);
            building.Floors.Add(parterreFloor);
            building.Floors.Add(groundFloor);
            building.Floors.Add(firstFloor);
        }

        private void TestTimer()
        {
            Timer testTimer = new Timer();
            testTimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
            testTimer.Interval = 1000;
            testTimer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Random random = new Random();

            if (Ø22_508_0.Temperature < 20)
            {
                Ø22_508_0.Temperature += random.NextDouble();
            }
            else if (Ø22_508_0.Temperature > 24)
            {
                Ø22_508_0.Temperature -= random.NextDouble();
            }
            else
            {
                if (random.Next(1, 2)%2 == 0)
                {
                    Ø22_508_0.Temperature += random.NextDouble();
                }
                else
                {
                    Ø22_508_0.Temperature -= random.NextDouble();
                }
            }

            if (Ø22_508_0.CO2 < 200)
            {
                Ø22_508_0.CO2 += random.Next(0, 100);
            }
            else if (Ø22_508_0.CO2 > 1000)
            {
                Ø22_508_0.CO2 -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2)%2 == 0)
                {
                    Ø22_508_0.CO2 += random.Next(0, 100);
                }
                else
                {
                    Ø22_508_0.CO2 -= random.Next(0, 100);

                }
            }

            if (Ø22_508_0.Lumen < 101)
            {
                Ø22_508_0.Lumen += random.Next(0, 100);
            }
            else if (Ø22_508_0.Lumen > 600)
            {
                Ø22_508_0.Lumen -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø22_508_0.Lumen += random.Next(0, 100);
                }
                else
                {
                    Ø22_508_0.Lumen -= random.Next(0, 100);

                }
            }

            if (Ø22_508_0.Lumen < 101)
            {
                Ø22_508_0.Lumen += random.Next(0, 100);
            }
            else if (Ø22_508_0.Lumen > Ø22_508_0.LumenMax)
            {
                Ø22_508_0.Lumen -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø22_508_0.Lumen += random.Next(0, 100);
                }
                else
                {
                    Ø22_508_0.Lumen -= random.Next(0, 100);

                }
            }

            if (Ø22_508_0.WifiClients < 6 )
            {
                Ø22_508_0.WifiClients += random.Next(0, 5);
            }
            else if (Ø22_508_0.WifiClients > Ø22_508_0.WifiClientsMax)
            {
                Ø22_508_0.WifiClients -= random.Next(0, 5);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø22_508_0.WifiClients += random.Next(0, 5);
                }
                else
                {
                    Ø22_508_0.WifiClients -= random.Next(0, 5);
                }
            }

            //SensorRoom Ø20_508a_0
            if (Ø20_508a_0.Temperature < 20)
            {
                Ø20_508a_0.Temperature += random.NextDouble();
            }
            else if (Ø20_508a_0.Temperature > 24)
            {
                Ø20_508a_0.Temperature -= random.NextDouble();
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø20_508a_0.Temperature += random.NextDouble();
                }
                else
                {
                    Ø20_508a_0.Temperature -= random.NextDouble();
                }
            }

            if (Ø20_508a_0.CO2 < 200)
            {
                Ø20_508a_0.CO2 += random.Next(0, 100);
            }
            else if (Ø20_508a_0.CO2 > 1000)
            {
                Ø20_508a_0.CO2 -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø20_508a_0.CO2 += random.Next(0, 100);
                }
                else
                {
                    Ø20_508a_0.CO2 -= random.Next(0, 100);
                }
            }

            if (Ø20_508a_0.Lumen < 101)
            {
                Ø20_508a_0.Lumen += random.Next(0, 100);
            }
            else if (Ø20_508a_0.Lumen > 600)
            {
                Ø20_508a_0.Lumen -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø20_508a_0.Lumen += random.Next(0, 100);
                }
                else
                {
                    Ø20_508a_0.Lumen -= random.Next(0, 100);

                }
            }

            if (Ø20_508a_0.Lumen < 101)
            {
                Ø20_508a_0.Lumen += random.Next(0, 100);
            }
            else if (Ø20_508a_0.Lumen > Ø20_508a_0.LumenMax)
            {
                Ø20_508a_0.Lumen -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø20_508a_0.Lumen += random.Next(0, 100);
                }
                else
                {
                    Ø20_508a_0.Lumen -= random.Next(0, 100);

                }
            }

            if (Ø20_508a_0.WifiClients < 6)
            {
                Ø20_508a_0.WifiClients += random.Next(0, 5);
            }
            else if (Ø20_508a_0.WifiClients > Ø20_508a_0.WifiClientsMax)
            {
                Ø20_508a_0.WifiClients -= random.Next(0, 5);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø20_508a_0.WifiClients += random.Next(0, 5);
                }
                else
                {
                    Ø20_508a_0.WifiClients -= random.Next(0, 5);
                }
            }

            //SensorRoom Ø20_604_0
            if (Ø20_604_0.Temperature < 20)
            {
                Ø20_604_0.Temperature += random.NextDouble();
            }
            else if (Ø20_604_0.Temperature > 24)
            {
                Ø20_604_0.Temperature -= random.NextDouble();
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø20_604_0.Temperature += random.NextDouble();
                }
                else
                {
                    Ø20_604_0.Temperature -= random.NextDouble();
                }
            }

            if (Ø20_604_0.CO2 < 200)
            {
                Ø20_604_0.CO2 += random.Next(0, 100);
            }
            else if (Ø20_604_0.CO2 > 1000)
            {
                Ø20_604_0.CO2 -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø20_604_0.CO2 += random.Next(0, 100);
                }
                else
                {
                    Ø20_604_0.CO2 -= random.Next(0, 100);
                }
            }

            if (Ø20_604_0.Lumen < 101)
            {
                Ø20_604_0.Lumen += random.Next(0, 100);
            }
            else if (Ø20_604_0.Lumen > 600)
            {
                Ø20_604_0.Lumen -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø20_604_0.Lumen += random.Next(0, 100);
                }
                else
                {
                    Ø20_604_0.Lumen -= random.Next(0, 100);

                }
            }

            if (Ø20_604_0.Lumen < 101)
            {
                Ø20_604_0.Lumen += random.Next(0, 100);
            }
            else if (Ø20_604_0.Lumen > Ø20_604_0.LumenMax)
            {
                Ø20_604_0.Lumen -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø20_604_0.Lumen += random.Next(0, 100);
                }
                else
                {
                    Ø20_604_0.Lumen -= random.Next(0, 100);

                }
            }

            if (Ø20_604_0.WifiClients < 6)
            {
                Ø20_604_0.WifiClients += random.Next(0, 5);
            }
            else if (Ø20_604_0.WifiClients > Ø20_604_0.WifiClientsMax)
            {
                Ø20_604_0.WifiClients -= random.Next(0, 5);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø20_604_0.WifiClients += random.Next(0, 5);
                }
                else
                {
                    Ø20_604_0.WifiClients -= random.Next(0, 5);
                }
            }

            //SensorRoom Ø22_604_0
            if (Ø22_604_0.Temperature < 20)
            {
                Ø22_604_0.Temperature += random.NextDouble();
            }
            else if (Ø22_604_0.Temperature > 24)
            {
                Ø22_604_0.Temperature -= random.NextDouble();
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø22_604_0.Temperature += random.NextDouble();
                }
                else
                {
                    Ø22_604_0.Temperature -= random.NextDouble();
                }
            }

            if (Ø22_604_0.CO2 < 200)
            {
                Ø22_604_0.CO2 += random.Next(0, 100);
            }
            else if (Ø22_604_0.CO2 > 1000)
            {
                Ø22_604_0.CO2 -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø22_604_0.CO2 += random.Next(0, 100);
                }
                else
                {
                    Ø22_604_0.CO2 -= random.Next(0, 100);
                }
            }

            if (Ø22_604_0.Lumen < 101)
            {
                Ø22_604_0.Lumen += random.Next(0, 100);
            }
            else if (Ø22_604_0.Lumen > 600)
            {
                Ø22_604_0.Lumen -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø22_604_0.Lumen += random.Next(0, 100);
                }
                else
                {
                    Ø22_604_0.Lumen -= random.Next(0, 100);
                }
            }

            if (Ø22_604_0.Lumen < 101)
            {
                Ø22_604_0.Lumen += random.Next(0, 100);
            }
            else if (Ø22_604_0.Lumen > Ø22_604_0.LumenMax)
            {
                Ø22_604_0.Lumen -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø22_604_0.Lumen += random.Next(0, 100);
                }
                else
                {
                    Ø22_604_0.Lumen -= random.Next(0, 100);

                }
            }

            if (Ø22_604_0.WifiClients < 6)
            {
                Ø22_604_0.WifiClients += random.Next(0, 5);
            }
            else if (Ø22_604_0.WifiClients > Ø22_604_0.WifiClientsMax)
            {
                Ø22_604_0.WifiClients -= random.Next(0, 5);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø22_604_0.WifiClients += random.Next(0, 5);
                }
                else
                {
                    Ø22_604_0.WifiClients -= random.Next(0, 5);
                }
            }
        }
    }
}