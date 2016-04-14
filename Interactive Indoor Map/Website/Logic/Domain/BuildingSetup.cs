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
        private Floor groundFloor;
        private Floor firstFloor;
        private Floor secondFloor;
        private SensorRoom _testSensorRoomCellar1;
        private SensorRoom _testSensorRoomFirstFloor1;
        private SensorRoom _testSensorRoomFirstFloor2;
        private SensorRoom _testSensorRoomSecondFloor1;
        private SensorRoom _testSensorRoomSecondFloor2;
        private SensorRoom Ø22_508_0;
        private SensorRoom Ø22_604_0;
        private SensorRoom Ø20_604_0;
        private SensorRoom Ø20_508a_0;
        private SensorRoom Ø22_606c_1;

        private SensorRoom Ø20_604b_1; //Studiezone
        private SensorRoom Ø20_603_1; 
        private SensorRoom Ø20_601b_1; 
        private SensorRoom Ø20_511_1; 
        private SensorRoom Ø20_510_1; 
        private SensorRoom Ø20_508a_1; //Studiezone
        private SensorRoom Ø22_508_1; //Studiezone
        private SensorRoom Ø22_510_1; 
        private SensorRoom Ø22_511_1; 
        private SensorRoom Ø22_601b_1; 
        private SensorRoom Ø22_603_1;
        private SensorRoom Ø22_604_1; //Studiezone

        private SensorlessRoom Ø21_602_1;
        private SensorlessRoom Ø21_511b_1;
        private SensorlessRoom Ø21_508b_1;
        private SensorlessRoom Ø21_600b_1;
        private SensorlessRoom Ø20_606_1;
        private SensorlessRoom Ø20_600b_1;
        private SensorlessRoom Ø22_512b_1;

        public void SetupBuilding()
        {
            //buildingDAL = new BuildingDAL();
            //building = buildingDAL.GetBuilding("Building 44");

            CreateBuilding();

            CreateFloors();

            CreateRooms();
            CreateActualRooms();
            CreateActualSensorlessRooms();

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

            groundFloor = new Floor(0)
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

            firstFloor = new Floor(1)
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

            secondFloor = new Floor(2)
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

        private void CreateActualRooms()
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
                CO2Max = 1000,
                LumenMax = 200,
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
                CO2Max = 1000,
                LumenMax = 200,
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
                SurfaceArea = 108
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
                CO2Max = 1000,
                LumenMax = 200,
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
                CO2Max = 1000,
                LumenMax = 200,
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
                CO2Max = 1000,
                LumenMax = 200,
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
                SurfaceArea = 80
            };

            Ø20_508a_1 = new SensorRoom("Ø20-508a-1", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.430723347,55.3675465210001),
                new Coordinates(10.4305754100001,55.367540122),
                new Coordinates(10.4305582060001,55.3676685890001),
                new Coordinates(10.4307061420001,55.367674987)
            }))
            {
                TemperatureMax = 25,
                CO2Max = 1000,
                LumenMax = 200,
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
                SurfaceArea = 125
            };

            /*Ø20_603_1;
            Ø20_508a_1; //Studiezone
            Ø22_508_1; //Studiezone
            Ø22_601b_1;
            Ø22_604_1; //Studiezone*/

            Ø22_508_1 = new SensorRoom("Ø22-508-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4309014460001, 55.367554225),
                new Coordinates(10.4308842190001, 55.3676828480001),
                new Coordinates(10.4310319320001, 55.367689237),
                new Coordinates(10.4310491580001, 55.3675606140001)
            }))
            {
                TemperatureMax = 25,
                CO2Max = 1000,
                LumenMax = 200,
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
                CO2Max = 1000,
                LumenMax = 200,
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
                CO2Max = 1000,
                LumenMax = 200,
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
                TemperatureMax = 25,
                CO2Max = 1000,
                LumenMax = 200,
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
                SurfaceArea = 125
            };

            Ø20_604b_1 = new SensorRoom("Ø22-604-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.430801009,55.3669667990001),
                new Coordinates(10.4306530480001,55.366960399),
                new Coordinates(10.4306357890001,55.3670892740001),
                new Coordinates(10.43078375,55.367095674)
            }))
            {
                TemperatureMax = 25,
                CO2Max = 1000,
                LumenMax = 200,
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
                CO2Max = 1000,
                LumenMax = 200,
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
                CO2Max = 1000,
                LumenMax = 200,
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
                CO2Max = 1000,
                LumenMax = 200,
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
                SurfaceArea = 97
            };

        }

        private void CreateActualSensorlessRooms()
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
                //10.430795946,55.3672843740001,
                //10.430610734,55.367276363,
                //10.430600079,55.367355918,
                //10.4307852920001,55.3673639290001,
                //10.430795946,55.3672843740001
                new Coordinates(10.430795946,55.3672843740001),
                new Coordinates(10.430610734,55.367276363),
                new Coordinates(10.430600079,55.367355918),
                new Coordinates(10.4307852920001,55.3673639290001),
                new Coordinates(10.430795946,55.3672843740001)
            })
            {
                RoomType = RoomType.Hallway
            };

            Ø22_512b_1 = new SensorlessRoom("Ø22-512b-1", new List<Coordinates>()
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
                LumenMax = 200,
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
                LumenMax = 200,
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
                LumenMax = 200,
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
                LumenMax = 200,
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
                LumenMax = 200,
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
            groundFloor.Rooms.Add(Ø20_510_1);
            firstFloor.Rooms.Add(Ø20_510_1);
            firstFloor.Rooms.Add(Ø20_601b_1);
            firstFloor.Rooms.Add(Ø20_604b_1);
            firstFloor.Rooms.Add(Ø22_510_1);
            firstFloor.Rooms.Add(Ø22_508_1);
            firstFloor.Rooms.Add(Ø22_601b_1);
            firstFloor.Rooms.Add(Ø20_603_1);
            firstFloor.Rooms.Add(Ø20_508a_1);
            firstFloor.Rooms.Add(Ø20_511_1);
            firstFloor.Rooms.Add(Ø22_604_1);
            firstFloor.Rooms.Add(Ø22_603_1);
            firstFloor.Rooms.Add(Ø20_601b_1);
            firstFloor.Rooms.Add(Ø22_511_1);
            
            firstFloor.Rooms.Add(Ø21_602_1);
            firstFloor.Rooms.Add(Ø21_511b_1);
            firstFloor.Rooms.Add(Ø21_600b_1);
            firstFloor.Rooms.Add(Ø21_508b_1);
            firstFloor.Rooms.Add(Ø20_606_1);
            firstFloor.Rooms.Add(Ø20_600b_1);
            firstFloor.Rooms.Add(Ø22_512b_1);


            secondFloor.Rooms.Add(Ø20_510_1);

            building.Floors.Add(cellarFloor);
            building.Floors.Add(groundFloor);

            building.Floors.Add(firstFloor);
            building.Floors.Add(secondFloor);
        }

        private void AssembleBuilding()
        {
            cellarFloor.Rooms.Add(_testSensorRoomCellar1);
            groundFloor.Rooms.Add(Ø22_508_0);
            groundFloor.Rooms.Add(Ø20_508a_0);
            groundFloor.Rooms.Add(Ø22_604_0);
            groundFloor.Rooms.Add(Ø20_604_0);
            //groundFloor.Rooms.Add(Ø20_606_1);
            //groundFloor.Rooms.Add(Ø22_606c_1);
            firstFloor.Rooms.Add(_testSensorRoomFirstFloor1);
            firstFloor.Rooms.Add(_testSensorRoomFirstFloor2);
            secondFloor.Rooms.Add(_testSensorRoomSecondFloor1);
            secondFloor.Rooms.Add(_testSensorRoomSecondFloor2);

            building.Floors.Add(cellarFloor);
            building.Floors.Add(groundFloor);
            building.Floors.Add(firstFloor);
            building.Floors.Add(secondFloor);
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