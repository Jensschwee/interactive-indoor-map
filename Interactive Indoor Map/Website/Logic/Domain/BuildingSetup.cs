using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Timers;
using System.Web;
using Website.DAL.Persistence;
using Website.Logic.BO;
using Website.Logic.BO.Buildings;
using Website.Logic.BO.Floors;
using Website.Logic.BO.Rooms;
using Website.Logic.BO.Utility;

namespace Website.Logic.Domain
{
    public class BuildingSetup
    {
        private LiveBuilding building;
        private LiveFloor cellarFloor;
        private LiveFloor parterreFloor;
        private LiveFloor groundFloor;
        private LiveFloor firstFloor;

        //Cellar Floor Rooms
        private LiveRoom cellarPlaceholderRoom;

        //Parterre Floor Rooms
        private LiveRoom Ø20_604_0;
        private LiveRoom Ø20_603_0;
        private LiveRoom Ø20_601b_0;
        private LiveRoom Ø20_511_0;
        private LiveRoom Ø20_510a_0;
        private LiveRoom Ø20_508a_0;
        private LiveRoom Ø22_604_0;
        private LiveRoom Ø22_603_0;
        private LiveRoom Ø22_601b_0;
        private LiveRoom Ø22_512a_0;
        private LiveRoom Ø22_511_0;
        private LiveRoom Ø22_510_0;
        private LiveRoom Ø22_508_0;
        private SensorlessRoom cellarLowerMidHallway;
        private SensorlessRoom cellarMidHallway;
        private SensorlessRoom cellarUpperMidHallway;
        private SensorlessRoom cellarLowerLeftStairs;
        private SensorlessRoom cellarLowerRightUtilities;
        private SensorlessRoom cellarUpperRightStairs;
        private SensorlessRoom cellarUpperLeftUtilities;
        private SensorlessRoom cellarElevatorRoom;
        private SensorlessRoom cellarMidStairs;

        //Ground Floor Rooms
        private LiveRoom Ø20_604b_1;
        private LiveRoom Ø20_603_1; 
        private LiveRoom Ø20_601b_1; 
        private LiveRoom Ø20_511_1; 
        private LiveRoom Ø20_510_1; 
        private LiveRoom Ø20_508a_1;
        private LiveRoom Ø22_508_1;
        private LiveRoom Ø22_510_1; 
        private LiveRoom Ø22_511_1; 
        private LiveRoom Ø22_601b_1; 
        private LiveRoom Ø22_603_1;
        private LiveRoom Ø22_604_1;
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
        private LiveRoom Ø20_603c_2;
        private LiveRoom Ø20_601b_2;
        private LiveRoom Ø20_511_2;
        private LiveRoom Ø20_510b_2;
        private LiveRoom Ø22_603b_2;
        private LiveRoom Ø22_601b_2;
        private LiveRoom Ø22_511_2;
        private LiveRoom Ø22_510b_2;
        private SensorlessRoom firstMidHallway;
        private SensorlessRoom firstUpperRightStairs;
        private SensorlessRoom firstLowerLeftStairs;
        private SensorlessRoom firstLowerLeftHallway;
        private SensorlessRoom firstLowerRightHallway;
        private SensorlessRoom firstLowerRightUtilities;
        private SensorlessRoom firstUpperLeftUtilities;
        private SensorlessRoom firstLowerMidHallway;
        private SensorlessRoom firstMidStairs;
        private SensorlessRoom firstElevator;
        private SensorlessRoom firstUpperHallway;
        private SensorlessRoom firstUpperLeftHallway;
        private SensorlessRoom firstUpperMidHallway;
        private SensorlessRoom firstUpperRightHallway;
        private SensorlessRoom firstUpperLeftOffices;
        private SensorlessRoom firstUpperRightOffices;
        private SensorlessRoom firstUpperLeftMidOffice;
        private SensorlessRoom firstUpperRightMidOffice;
        private SensorlessRoom firstUpperLeftMidOffices;
        private SensorlessRoom firstUpperRightMidOffices;
        private SensorlessRoom firstLowerLeftOffices;
        private SensorlessRoom firstLowerRightOffices;
        private SensorlessRoom firstLowerRightMidOffice;
        private SensorlessRoom firstLowerRightMidOffices;
        private SensorlessRoom firstLowerLeftMidOffice;
        private SensorlessRoom firstLowerLeftMidOffices;

        BuildingDAL buildingDAL = new BuildingDAL();


        public void SetupBuilding(LiveBuilding building)
        {
            //SetupBuildingDB();
            SetupBuildingNoDB(building);

            HttpContext.Current.Application["Building"] = this.building;
            //buildingDAL.SaveBuilding(building);
        }

        private void SetupBuildingDB()
        {
            building = buildingDAL.GetBuilding("Building 44");
            GetLiveRooms(building);
            GetSensorLessRooms(building);
        }

        private void SetupBuildingNoDB(LiveBuilding building)
        {
            this.building = building;
            CreateFloors();

            CreateCellarFloorRooms();
            CreateParterreFloorRooms();
            CreateGroundFloorRooms();
            CreateGroundFloorSensorlessRooms();
            CreateFirstFloorRooms();

            CreateFloors();

            CreateCellarFloorRooms();

            CreateParterreFloorRooms();
            CreateParterreFloorSensorlessRooms();

            CreateGroundFloorRooms();
            CreateGroundFloorSensorlessRooms();

            CreateFirstFloorRooms();
            CreateFirstFloorSensorlessRooms();

            AssembleBuilding();
        }

        private void GetLiveRooms(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (LiveRoom LiveRoom in floor.Rooms.OfType<LiveRoom>())
                {
                    LiveRoom tempRoom = buildingDAL.GetLiveRoom(LiveRoom.Id);
                    LiveRoom.Corners = tempRoom.Corners;
                    LiveRoom.Endpoints = tempRoom.Endpoints;
                }
            }
        }

        private void GetSensorLessRooms(Building building)
        {
            foreach (Floor floor in building.Floors)
            {
                foreach (SensorlessRoom sensorlessRoom in floor.Rooms.OfType<SensorlessRoom>())
                {
                    SensorlessRoom tempRoom = buildingDAL.GetSensorLessRoom(sensorlessRoom.Id);
                    sensorlessRoom.Coordinates = tempRoom.Coordinates;
                }
            }
        }

        public LiveBuilding CreateBuilding()
        {
            building = new LiveBuilding
            {
                //MaxColdWaterConsumption = 100000,
                //MaxHotWaterConsumption = 100000,
                MaxOccupants = 2000,
                Name = "Building 44",
                Occupants = 1108,
                //ColdWaterConsumption = 2200,
                //HotWaterConsumption = 2100,
            };
            return building;
        }

        private void CreateFloors()
        {
            cellarFloor = new LiveFloor(-1)
            {
                FloorName = "Cellar",
                SurfaceArea = 2400,
                MaxHardwareConsumption = 200,
                MaxLightConsumption = 200,
                MaxVentilationConsumption = 200,
                MaxOtherConsumption = 200,
                MaxColdWaterConsumption = 20,
                MaxHotWaterConsumption = 20,
                HardwareConsumption = 100,
                LightConsumption = 90,
                OtherConsumption = 50,
                VentilationConsumption = 75,
                ColdWaterConsumption = 5,
                HotWaterConsumption = 3
            };

            parterreFloor = new LiveFloor(0)
            {
                FloorName = "Parterre",
                SurfaceArea = 2400,
                MaxHardwareConsumption = 200,
                MaxLightConsumption = 200,
                MaxVentilationConsumption = 200,
                MaxOtherConsumption = 200,
                MaxColdWaterConsumption = 20,
                MaxHotWaterConsumption = 20,
                HardwareConsumption = 100,
                LightConsumption = 90,
                OtherConsumption = 50,
                VentilationConsumption = 75,
                ColdWaterConsumption = 5,
                HotWaterConsumption = 3
            };

            groundFloor = new LiveFloor(1)
            {
                FloorName = "Ground Floor",
                SurfaceArea = 2400,
                MaxHardwareConsumption = 200,
                MaxLightConsumption = 200,
                MaxVentilationConsumption = 200,
                MaxOtherConsumption = 200,
                MaxColdWaterConsumption = 20,
                MaxHotWaterConsumption = 20,
                HardwareConsumption = 100,
                LightConsumption = 90,
                OtherConsumption = 50,
                VentilationConsumption = 75,
                ColdWaterConsumption = 5,
                HotWaterConsumption = 3,
                Endpoints = new Endpoints()
                {
                    SmapEndponts = new Dictionary<string, SensorType>()
                    {
                        { "0d7f95ef-d7eb-5b54-b9c2-494c04c963be", SensorType.TotalPowerConsumption}, //Smap 1567
                        { "b04967eb-4e49-5ea4-b633-795ae052a705", SensorType.LightPowerConsumption}, //sMap 1568
                        { "96935927-ae4f-58b0-93aa-11d17845af30", SensorType.OtherPowerConsumption}, //sMap 1571
                        { "9389fd92-ae2e-534b-aafd-ee1048ae472c", SensorType.TotalPowerConsumption}, //sMap 1572
                        { "3fa0b857-cbd3-5d17-9973-99e7ef55abbb", SensorType.LightPowerConsumption}, //sMap 1573
                        { "d28b4740-4b62-5908-9722-c57bbef7f6c0", SensorType.OtherPowerConsumption}, //sMap 1576
                    }
                }
            };

            firstFloor = new LiveFloor(2)
            {
                FloorName = "First Floor",
                SurfaceArea = 2400,
                MaxHardwareConsumption = 200,
                MaxLightConsumption = 200,
                MaxVentilationConsumption = 200,
                MaxOtherConsumption = 200,
                MaxColdWaterConsumption = 20,
                MaxHotWaterConsumption = 20,
                HardwareConsumption = 100,
                LightConsumption = 90,
                OtherConsumption = 50,
                VentilationConsumption = 75,
                ColdWaterConsumption = 5,
                HotWaterConsumption = 3
            };

        }

        private void CreateCellarFloorRooms()
        {
            cellarPlaceholderRoom = new LiveRoom("Placeholder", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.430841441,55.366968517),
                new Coordinates(10.430653052,55.3669603690001),
                new Coordinates(10.430635802,55.367089175),
                new Coordinates(10.430824193,55.367097324)
            }))
            {
                RoomType = RoomType.Studyzone,
                MaxTemperature = 25,
                MinTemperature = 20,
                MaxCO2 = 1000,
                MaxLux = 600,
                MaxOccupants = 50,
                MaxWifiClients = 75,
                Temperature = 20,
                CO2 = 350,
                HardwareConsumption = 290,
                VentilationConsumption = 310,
                OtherConsumption = 90,
                LightConsumption = 150,
                MaxHardwareConsumption = 400,
                MaxLightConsumption = 800,
                MaxOtherConsumption = 500,
                MaxVentilationConsumption = 1000,
                Light = false,
                Lux = 0,
                Motion = false,
                Occupants = 0,
                WifiClients = 0,
                SurfaceArea = 162
            };
        }

        private void CreateParterreFloorRooms()
        {
            Ø20_604_0 = new LiveRoom("Ø20-604-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.430841441,55.366968517),
                new Coordinates(10.430653052,55.3669603690001),
                new Coordinates(10.430635802,55.367089175),
                new Coordinates(10.430824193,55.367097324)
            }))
            {
                RoomType = RoomType.Studyzone,
                Alias = "Studiezone 2",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 48,
                MaxWifiClients = 75,
                Temperature = 24,
                CO2 = 430,
                HardwareConsumption = 1,
                VentilationConsumption = 3,
                OtherConsumption = 1,
                LightConsumption = 3,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 4,
                SurfaceArea = 162
            };

            Ø20_603_0 = new LiveRoom("Ø20-603-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.430824193,55.367097324),
                new Coordinates(10.430635802,55.367089175),
                new Coordinates(10.4306243130001,55.3671749660001),
                new Coordinates(10.4308127080001,55.367183089)
            }))
            {
                Alias = "U168",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 48,
                MaxWifiClients = 75,
                Temperature = 24,
                CO2 = 430,
                HardwareConsumption = 1,
                VentilationConsumption = 3,
                OtherConsumption = 1,
                LightConsumption = 3,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 4,
                SurfaceArea = 108
            };

            Ø20_601b_0 = new LiveRoom("Ø20-601b-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.430612384,55.367264042),
                new Coordinates(10.4308007770001,55.3672721890001),
                new Coordinates(10.4308127080001,55.367183089),
                new Coordinates(10.4306243130001,55.3671749660001)
            }))
            {
                Alias = "U163",
                MaxOccupants = 48,
                MaxWifiClients = 60,
                MaxTemperature = 25,
                MaxLux = 700,
                Temperature = 22,
                CO2 = 600,
                MaxCO2 = 800,
                TotalPowerConsumption = 22,
                HardwareConsumption = 8,
                VentilationConsumption = 7,
                OtherConsumption = 4,
                LightConsumption = 3,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 400,
                Motion = true,
                Occupants = 30,
                WifiClients = 40,
                SurfaceArea = 111
            };

            Ø20_511_0 = new LiveRoom("Ø20-511-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4307828560001,55.367406014),
                new Coordinates(10.430594462,55.367397866),
                new Coordinates(10.4305840530001,55.367475588),
                new Coordinates(10.430772448,55.367483737)
            }))
            {
                Alias = "U166",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 120,
                MaxWifiClients = 150,
                Temperature = 24,
                CO2 = 515,
                TotalPowerConsumption = 33,
                HardwareConsumption = 9,
                VentilationConsumption = 9,
                OtherConsumption = 7,
                LightConsumption = 8,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 600,
                Motion = true,
                Occupants = 100,
                WifiClients = 90,
                SurfaceArea = 98
            };

            Ø20_510a_0 = new LiveRoom("Ø20-510a-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4305754280001,55.3675399900001),
                new Coordinates(10.4307638240001,55.3675481390001),
                new Coordinates(10.430772448,55.367483737),
                new Coordinates(10.4305840530001,55.367475588)
            }))
            {
                Alias = "U165",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 36,
                MaxWifiClients = 60,
                Temperature = 24,
                CO2 = 420,
                TotalPowerConsumption = 10,
                HardwareConsumption = 2,
                VentilationConsumption = 3,
                OtherConsumption = 1,
                LightConsumption = 4,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 450,
                Motion = true,
                Occupants = 15,
                WifiClients = 20,
                SurfaceArea = 80
            };

            Ø20_508a_0 = new LiveRoom("Ø20-508a-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4307638240001,55.3675481390001),
                new Coordinates(10.4305754280001,55.3675399900001),
                new Coordinates(10.4305581780001,55.3676687940001),
                new Coordinates(10.4307465750001,55.367676943)
            }))
            {
                RoomType = RoomType.Studyzone,
                Alias = "Studiezone 1",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 48,
                MaxWifiClients = 75,
                Temperature = 24,
                CO2 = 480,
                TotalPowerConsumption = 22,
                HardwareConsumption = 7,
                VentilationConsumption = 4,
                OtherConsumption = 5,
                LightConsumption = 6,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 240,
                Motion = true,
                Occupants = 12,
                WifiClients = 18,
                SurfaceArea = 162
            };

            Ø22_604_0 = new LiveRoom("Ø22-604-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4311268000001,55.366980862),
                new Coordinates(10.430940122,55.3669727860001),
                new Coordinates(10.430922874,55.3671015880001),
                new Coordinates(10.43110955,55.367109665)
            }))
            {
                RoomType = RoomType.Studyzone,
                Alias = "Studiezone 3",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 48,
                MaxWifiClients = 75,
                Temperature = 24,
                CO2 = 480,
                TotalPowerConsumption = 16,
                HardwareConsumption = 5,
                VentilationConsumption = 6,
                OtherConsumption = 2,
                LightConsumption = 3,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 390,
                Motion = true,
                Occupants = 16,
                WifiClients = 20,
                SurfaceArea = 162
            };

            Ø22_603_0 = new LiveRoom("Ø22-603-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.43110955,55.367109665),
                new Coordinates(10.430922874,55.3671015880001),
                new Coordinates(10.4309142490001,55.3671659950001),
                new Coordinates(10.4311009250001,55.367174069)
            }))
            {
                Alias = "U164",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 36,
                MaxWifiClients = 25,
                Temperature = 22.5,
                CO2 = 430,
                TotalPowerConsumption = 1.7,
                HardwareConsumption = 0.5,
                VentilationConsumption = 1.2,
                OtherConsumption = 0,
                LightConsumption = 0,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = false,
                Lux = 0,
                Motion = false,
                Occupants = 0,
                WifiClients = 0,
                SurfaceArea = 80
            };

            Ø22_601b_0 = new LiveRoom("Ø22-601b-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4308994830001,55.367276254),
                new Coordinates(10.431086158,55.367284328),
                new Coordinates(10.4311009250001,55.367174069),
                new Coordinates(10.4309142490001,55.3671659950001)
            }))
            {
                Alias = "U163",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 120,
                MaxWifiClients = 150,
                Temperature = 24,
                CO2 = 700,
                TotalPowerConsumption = 33.5,
                HardwareConsumption = 9,
                VentilationConsumption = 9.5,
                OtherConsumption = 8,
                LightConsumption = 7,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 550,
                Motion = true,
                Occupants = 60,
                WifiClients = 76,
                SurfaceArea = 139
            };

            Ø22_512a_0= new LiveRoom("Ø22-512a-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.43107259,55.3673856410001),
                new Coordinates(10.430885916,55.3673775670001),
                new Coordinates(10.4308797510001,55.3674236040001),
                new Coordinates(10.431066425,55.3674316780001)
            }))
            {
                Alias = "U162",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 48,
                MaxWifiClients = 75,
                Temperature = 24,
                CO2 = 430,
                TotalPowerConsumption = 8,
                HardwareConsumption = 1,
                VentilationConsumption = 3,
                OtherConsumption = 1,
                LightConsumption = 3,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 4,
                SurfaceArea = 57
            };

            Ø22_511_0 = new LiveRoom("Ø22-511-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.431066425,55.3674316780001),
                new Coordinates(10.4308797510001,55.3674236040001),
                new Coordinates(10.430871127,55.367488006),
                new Coordinates(10.4310578000001,55.3674960800001)
            }))
            {
                Alias = "U161",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 48,
                MaxWifiClients = 75,
                Temperature = 23,
                CO2 = 535,
                TotalPowerConsumption = 23.1,
                HardwareConsumption = 7.5,
                VentilationConsumption = 6.2,
                OtherConsumption = 4.3,
                LightConsumption = 5.1,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 310,
                Motion = true,
                Occupants = 35,
                WifiClients = 50,
                SurfaceArea = 80
            };

            Ø22_510_0 = new LiveRoom("Ø22-510-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4310578000001,55.3674960800001),
                new Coordinates(10.430871127,55.367488006),
                new Coordinates(10.4308625030001,55.3675524080001),
                new Coordinates(10.4310491750001,55.367560482)
            }))
            {
                Alias = "U160",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 48,
                MaxWifiClients = 75,
                Temperature = 22.5,
                CO2 = 515,
                TotalPowerConsumption = 23.6,
                HardwareConsumption = 7.1,
                VentilationConsumption = 6.9,
                OtherConsumption = 4.2,
                LightConsumption = 5.4,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 325,
                Motion = true,
                Occupants = 31,
                WifiClients = 33,
                SurfaceArea = 80
            };

            Ø22_508_0 = new LiveRoom("Ø22-508-0", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4310491750001,55.367560482),
                new Coordinates(10.4308625030001,55.3675524080001),
                new Coordinates(10.4308452550001,55.367681212),
                new Coordinates(10.4310319250001,55.367689286)
            }))
            {
                RoomType = RoomType.Studyzone,
                Alias = "Studiezone 4",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 48,
                MaxWifiClients = 75,
                Temperature = 23,
                CO2 = 535,
                TotalPowerConsumption = 23.1,
                HardwareConsumption = 7.5,
                VentilationConsumption = 6.2,
                OtherConsumption = 4.3,
                LightConsumption = 5.1,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 310,
                Motion = true,
                Occupants = 35,
                WifiClients = 50,
                SurfaceArea = 162
            };
        }

        private void CreateGroundFloorRooms()
        {
            Ø22_603_1 = new LiveRoom("Ø22-603-1", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.430624295,55.3671750980001),
                new Coordinates(10.430809507,55.3671831080001),
                new Coordinates(10.430821,55.3670972850001),
                new Coordinates(10.4306357890001,55.3670892740001)
            }))
            {
                Alias = "U175",
                MaxOccupants = 48,
                MaxWifiClients = 60,
                MaxLux = 700,
                Temperature = 22,
                CO2 = 600,
                MaxCO2 = 800,
                TotalPowerConsumption = 22,
                HardwareConsumption = 8,
                VentilationConsumption =7,
                OtherConsumption = 4,
                LightConsumption = 3,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 400,
                Motion = true,
                Occupants = 30,
                WifiClients = 40,
                SurfaceArea = 108,
                Endpoints = new Endpoints()
                {
                    SmapEndponts = new Dictionary<string, SensorType>()
                    {
                        { "52b533d9-ca2d-5b46-9d94-59e4ba98bce2", SensorType.CO2 },
                        { "2ac063fc-96f2-5e68-b277-3339f9eb89ff",SensorType.MotionDetection },
                        { "30721f0d-606d-5a07-8cdb-9f9b20380369" , SensorType.Temperature}

                    }
                }
            };

            Ø20_510_1 = new LiveRoom("Ø20-510-1", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.43076928, 55.36748349),
                new Coordinates(10.430584067, 55.3674754790001),
                new Coordinates(10.4305754100001, 55.367540122),
                new Coordinates(10.430760623, 55.3675481330001)
            }))
            {
                Alias = "U172",
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 36,
                MaxWifiClients = 50,
                Temperature = 23,
                CO2 = 550,
                TotalPowerConsumption = 13,
                HardwareConsumption = 5,
                VentilationConsumption = 4,
                OtherConsumption = 2,
                LightConsumption = 2,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = false,
                Lux = 0,
                Motion = false,
                Occupants = 0,
                WifiClients = 0,
                SurfaceArea = 80,
                Endpoints = new Endpoints()
                {
                    SmapEndponts = new Dictionary<string, SensorType>()
                    {
                        { "b7c51bf1-bd68-58d9-9cb1-d81fb2ee6f67", SensorType.CO2 },
                        { "53dfbf10-7aba-50f9-9aa5-6401993ffcee", SensorType.MotionDetection },
                        { "57ef0c6d-8801-5315-8916-c55cf4721e35", SensorType.Temperature }

                    }
                }
            };

            Ø20_511_1 = new LiveRoom("Ø20-511-1", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.43077966,55.367405983),
                new Coordinates(10.430594447,55.367397972),
                new Coordinates(10.430584067,55.3674754790001),
                new Coordinates(10.43076928,55.36748349)
            }))
            {
                Alias = "U170",
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 120,
                MaxWifiClients = 150,
                Temperature = 24,
                CO2 = 700,
                TotalPowerConsumption = 33.5,
                HardwareConsumption = 9,
                VentilationConsumption = 9.5,
                OtherConsumption = 8,
                LightConsumption = 7,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 550,
                Motion = true,
                Occupants = 60,
                WifiClients = 76,
                SurfaceArea = 97,
                Endpoints = new Endpoints()
                {
                    SmapEndponts = new Dictionary<string, SensorType>()
                    {
                        { "9a4de872-0414-5d2e-868d-fe649c06ee56" , SensorType.CO2},
                        { "535b9bf9-8a6a-56bb-b43a-31b2c2a090e3", SensorType.MotionDetection },
                        {"dbcdc366-a30e-52be-8940-5c4ee9cdaa29" ,  SensorType.Temperature}

                    }
                }
            };

            Ø20_508a_1 = new LiveRoom("Ø20-508a-1", new Corners(new List<Coordinates>()
            {
                new Coordinates(10.430723347,55.3675465210001),
                new Coordinates(10.4305754100001,55.367540122),
                new Coordinates(10.4305582060001,55.3676685890001),
                new Coordinates(10.4307061420001,55.367674987)
            }))
            {
                RoomType = RoomType.Studyzone,
                Alias = "Studiezone 7",
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 48,
                MaxWifiClients = 75,
                Temperature = 24,
                CO2 = 430,
                TotalPowerConsumption = 8,
                HardwareConsumption = 1,
                VentilationConsumption = 3,
                OtherConsumption = 1,
                LightConsumption = 3,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 200,
                Motion = false,
                Occupants = 5,
                WifiClients = 4,
                SurfaceArea = 125,
                Endpoints = new Endpoints()
                {
                    SmapEndponts = new Dictionary<string, SensorType>()
                    {
                        { "bec6ad6b-753a-548d-bb8c-4e03f4d67b2e" , SensorType.CO2},
                        { "b4cb304d-1425-5165-b83d-f3dc985858a6", SensorType.MotionDetection },
                        { "411d6c5e-da82-526a-8825-c27c3db4137b" , SensorType.Temperature}

                    }
                }
            };

            Ø22_508_1 = new LiveRoom("Ø22-508-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4309014460001, 55.367554225),
                new Coordinates(10.4308842190001, 55.3676828480001),
                new Coordinates(10.4310319320001, 55.367689237),
                new Coordinates(10.4310491580001, 55.3675606140001)
            }))
            {
                RoomType = RoomType.Studyzone,
                Alias = "Studiezone 8",
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 48,
                MaxWifiClients = 75,
                Temperature = 24,
                CO2 = 480,
                TotalPowerConsumption = 16,
                HardwareConsumption = 5,
                VentilationConsumption = 6,
                OtherConsumption = 2,
                LightConsumption = 3,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 390,
                Motion = true,
                Occupants = 16,
                WifiClients = 20,
                SurfaceArea = 125,
                Endpoints = new Endpoints()
                {
                    SmapEndponts = new Dictionary<string, SensorType>()
                    {
                        { "a19b2b8c-a4f0-5fc1-84af-d94e07329589" , SensorType.CO2},
                        { "34fb23ff-8d91-59ed-b30f-3a80d6262251", SensorType.MotionDetection },
                        { "b498b5ce-9084-57e6-905a-e0c15a8399f7", SensorType.Temperature }
                    }
                }
            };

            Ø22_510_1 = new LiveRoom("Ø22-510-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.431057781, 55.3674962250001),
                new Coordinates(10.4308716730001, 55.3674881760001),
                new Coordinates(10.4308630510001, 55.3675525640001),
                new Coordinates(10.4310491580001, 55.3675606140001)
            }))
            {
                Alias = "U171",
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 36,
                MaxWifiClients = 60,
                Temperature = 24,
                CO2 = 420,
                TotalPowerConsumption = 10,
                HardwareConsumption = 2,
                VentilationConsumption = 3,
                OtherConsumption = 1,
                LightConsumption = 4,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 450,
                Motion = true,
                Occupants = 15,
                WifiClients = 20,
                SurfaceArea = 80,
                Endpoints = new Endpoints()
                {
                    SmapEndponts = new Dictionary<string, SensorType>()
                    {
                        { "686e2e0c-294b-59c3-b1aa-a39d04044bfa", SensorType.CO2 },
                        { "30c18abd-3071-5283-95cd-341ad6b093f1", SensorType.MotionDetection },
                        {"b9dac0d2-0238-54e6-84e7-366e89610a61",  SensorType.Temperature }
                    }
                }
            };

            Ø22_601b_1 = new LiveRoom("Ø22-601b-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4311009210001, 55.3671740930001),
                new Coordinates(10.43091481, 55.3671660420001),
                new Coordinates(10.4308999900001, 55.367276712),
                new Coordinates(10.4310861000001, 55.3672847620001)
            }))
            {
                Alias = "U177",
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 120,
                MaxWifiClients = 150,
                Temperature = 24,
                CO2 = 515,
                TotalPowerConsumption = 33,
                HardwareConsumption = 9,
                VentilationConsumption = 9,
                OtherConsumption = 7,
                LightConsumption = 8,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 600,
                Motion = true,
                Occupants = 100,
                WifiClients = 90,
                SurfaceArea = 139,
                Endpoints = new Endpoints()
                {
                    SmapEndponts = new Dictionary<string, SensorType>()
                    {
                        { "ad415c75-5ef9-5e34-93d0-7ddccfb85010", SensorType.CO2 },
                        { "830364bb-6728-532b-bf58-2786d3d5a274" , SensorType.MotionDetection},
                        { "c4875c12-1198-5ca5-8a5d-23c81bf1701a", SensorType.Temperature }
                    }
                }
            };

            Ø22_604_1 = new LiveRoom("Ø22-604-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4309793780001,55.366974462),
                new Coordinates(10.430962113,55.3671033680001),
                new Coordinates(10.431109539,55.3671097450001),
                new Coordinates(10.431126803,55.3669808390001)
            }))
            {
                RoomType = RoomType.Studyzone,
                Endpoints = new Endpoints(){
                    SmapEndponts = new Dictionary<string, SensorType>()
                    {
                        { "c936d681-c892-5dd8-9ce5-28b59b428c2f", SensorType.CO2},
                        { "13650000-df43-5ba9-a909-ae918a3e1027", SensorType.MotionDetection},
                        { "e00a920b-31b7-5a99-a5e9-59eeeed69c9a", SensorType.Temperature}
                    }
                },
                Alias = "Studiezone 6",
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 48,
                MaxWifiClients = 75,
                Temperature = 24,
                CO2 = 480,
                TotalPowerConsumption = 22,
                HardwareConsumption = 7,
                VentilationConsumption = 4,
                OtherConsumption = 5,
                LightConsumption = 6,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 240,
                Motion = true,
                Occupants = 12,
                WifiClients = 18,
                SurfaceArea = 125
            };

            Ø20_604b_1 = new LiveRoom("Ø20-604b-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.430801009,55.3669667990001),
                new Coordinates(10.4306530480001,55.366960399),
                new Coordinates(10.4306357890001,55.3670892740001),
                new Coordinates(10.43078375,55.367095674)
            }))
            {
                Alias = "Studiezone 5",
                RoomType = RoomType.Studyzone,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 48,
                MaxWifiClients = 75,
                Temperature = 23,
                CO2 = 535,
                TotalPowerConsumption = 23.1,
                HardwareConsumption = 7.5,
                VentilationConsumption = 6.2,
                OtherConsumption = 4.3,
                LightConsumption = 5.1,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 310,
                Motion = true,
                Occupants = 35,
                WifiClients = 50,
                SurfaceArea = 125,
                Endpoints = new Endpoints()
                {
                    SmapEndponts = new Dictionary<string, SensorType>()
                    {
                        { "1b1fa3c0-a23f-5280-a221-e8bbb79210d4", SensorType.CO2 },
                        { "03db442e-b690-55a7-9cb4-a680bd27ba96", SensorType.MotionDetection },
                        { "d08b79ea-4145-5248-86a2-7cd61c772c65", SensorType.Temperature }
                    }
                }
            };

            Ø20_603_1 = new LiveRoom("Ø20-603-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.43091481,55.3671660420001),
                new Coordinates(10.4311009210001,55.3671740930001),
                new Coordinates(10.431109539,55.3671097450001),
                new Coordinates(10.430923427,55.367101694)
            }))
            {
                Alias = "U176",
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 36,
                MaxWifiClients = 25,
                Temperature = 22.5,
                CO2 = 430,
                TotalPowerConsumption = 1.7,
                HardwareConsumption = 0.5,
                VentilationConsumption = 1.2,
                OtherConsumption = 0,
                LightConsumption = 0,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = false,
                Lux = 0,
                Motion = false,
                Occupants = 0,
                WifiClients = 0,
                SurfaceArea = 80,
                Endpoints = new Endpoints()
                {
                    SmapEndponts = new Dictionary<string, SensorType>()
                    {
                        { "8b4072ba-6ce4-5e73-a643-12dfb6e0ec2f", SensorType.CO2 },
                        { "25c972e7-897a-5073-991c-1830b87f79fc", SensorType.MotionDetection },
                        { "7ab3149f-d9ee-57d0-8917-5a20e0b38660", SensorType.Temperature }

                    }
                }
            };

            Ø20_601b_1 = new LiveRoom("Ø20-601b-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4306123600001,55.367264219),
                new Coordinates(10.4307975720001,55.36727223),
                new Coordinates(10.430809507,55.3671831080001),
                new Coordinates(10.430624295,55.3671750980001)
            }))
            {
                Alias = "U174",
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 60,
                MaxWifiClients = 100,
                Temperature = 22,
                CO2 = 485,
                TotalPowerConsumption = 15.9,
                HardwareConsumption = 4.8,
                VentilationConsumption = 5.2,
                OtherConsumption = 2.1,
                LightConsumption = 3.8,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 340,
                Motion = true,
                Occupants = 24,
                WifiClients = 28,
                SurfaceArea = 111,
                Endpoints = new Endpoints()
                {
                    SmapEndponts = new Dictionary<string, SensorType>()
                    {
                        { "4655c0eb-25b9-5652-816a-933e50e6e296", SensorType.CO2 },
                        { "bdb11d16-75bc-55c4-8aef-2cd2c9972973", SensorType.MotionDetection },
                        { "7c4fc2e8-47ea-56b1-a1a7-58c2b8f6ef5a", SensorType.Temperature }

                    }
                }
            };

            Ø22_511_1 = new LiveRoom("Ø22-511-1", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.431072543,55.3673859940001),
                new Coordinates(10.4308864340001,55.3673779440001),
                new Coordinates(10.4308716730001,55.3674881760001),
                new Coordinates(10.431057781,55.3674962250001)
            }))
            {
                Alias = "U173",
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 60,
                MaxWifiClients = 75,
                Temperature = 20,
                CO2 = 490,
                TotalPowerConsumption = 14,
                HardwareConsumption = 3.7,
                VentilationConsumption = 4.1,
                OtherConsumption = 1.9,
                LightConsumption = 4.3,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 445,
                Motion = false,
                Occupants = 20,
                WifiClients = 16,
                SurfaceArea = 139,
                Endpoints = new Endpoints()
                {
                    SmapEndponts = new Dictionary<string, SensorType>()
                    {
                        { "e7f08bd3-4096-5b76-a90b-ccaac7451730", SensorType.CO2 },
                        { "208d2238-69cd-5b3f-9469-cc94e2c089e3", SensorType.MotionDetection },
                        { "4782fdad-a676-54e3-a70b-eeffd5491d13", SensorType.Temperature }
                    }
                }
            };
        }

        private void CreateParterreFloorSensorlessRooms()
        {
            cellarLowerMidHallway = new SensorlessRoom("Lower Mid Hallway", new List<Coordinates>()
            {
                new Coordinates(10.430805369,55.367237894),
                new Coordinates(10.430904049,55.3672421620001),
                new Coordinates(10.4309258010001,55.367079732),
                new Coordinates(10.4309258010001,55.367079732),
                new Coordinates(10.4308271200001,55.367075464),
                new Coordinates(10.430805369,55.367237894)
            })
            {
                RoomType = RoomType.Hallway
            };

            cellarMidHallway = new SensorlessRoom("Mid Hallway", new List<Coordinates>()
            {
                new Coordinates(10.4307825390001,55.3674083780001),
                new Coordinates(10.4308812190001,55.367412646),
                new Coordinates(10.430904049,55.3672421620001),
                new Coordinates(10.430805369,55.367237894),
                new Coordinates(10.4307825390001,55.3674083780001)
            })
            {
                RoomType = RoomType.Hallway
            };

            cellarUpperMidHallway = new SensorlessRoom("Upper Mid Hallway", new List<Coordinates>()
            {
                new Coordinates(10.4308812190001,55.367412646),
                new Coordinates(10.4307825390001,55.3674083780001),
                new Coordinates(10.430761025,55.3675690410001),
                new Coordinates(10.4308597040001,55.3675733090001),
                new Coordinates(10.4308812190001,55.367412646)
            })
            {
                RoomType = RoomType.Hallway
            };

            cellarLowerLeftStairs = new SensorlessRoom("Lower Left Stairs", new List<Coordinates>()
            {
                new Coordinates(10.430653052,55.3669603690001),
                new Coordinates(10.430841441,55.366968517),
                new Coordinates(10.4308464120001,55.366931397),
                new Coordinates(10.430658023,55.366923248),
                new Coordinates(10.430653052,55.3669603690001)
            })
            {
                RoomType = RoomType.Hallway
            };

            cellarLowerRightUtilities = new SensorlessRoom("Lower Right Utilities", new List<Coordinates>()
            {
                new Coordinates(10.4311268000001,55.366980862),
                new Coordinates(10.431131771,55.3669437400001),
                new Coordinates(10.430945093,55.3669356660001),
                new Coordinates(10.430940122,55.3669727860001),
                new Coordinates(10.4311268000001,55.366980862)
            })
            {
                RoomType = RoomType.Hallway
            };

            cellarUpperRightStairs = new SensorlessRoom("Upper Right Stairs", new List<Coordinates>()
            {
                new Coordinates(10.4310319250001,55.367689286),
                new Coordinates(10.4308452550001,55.367681212),
                new Coordinates(10.4308402840001,55.367718331),
                new Coordinates(10.4310269540001,55.367726406),
                new Coordinates(10.4310319250001,55.367689286)
            })
            {
                RoomType = RoomType.Hallway
            };

            cellarUpperLeftUtilities = new SensorlessRoom("Upper Left Utilities", new List<Coordinates>()
            {
                new Coordinates(10.4305581780001,55.3676687940001),
                new Coordinates(10.4305532070001,55.3677059140001),
                new Coordinates(10.430741604,55.3677140630001),
                new Coordinates(10.4307465750001,55.367676943),
                new Coordinates(10.4305581780001,55.3676687940001)
            })
            {
                RoomType = RoomType.Hallway
            };

            cellarElevatorRoom = new SensorlessRoom("Elevator", new List<Coordinates>()
            {
                new Coordinates(10.430885916,55.3673775670001),
                new Coordinates(10.43107259,55.3673856410001),
                new Coordinates(10.431086158,55.367284328),
                new Coordinates(10.4308994830001,55.367276254),
                new Coordinates(10.430885916,55.3673775670001)
            })
            {
                RoomType = RoomType.Hallway
            };

            cellarMidStairs = new SensorlessRoom("Mid Stairs", new List<Coordinates>()
            {
                new Coordinates(10.430801452,55.3672720260001),
                new Coordinates(10.43061241,55.367263849),
                new Coordinates(10.4305945140001,55.367397474),
                new Coordinates(10.430783557,55.3674056510001),
                new Coordinates(10.430801452,55.3672720260001)
            })
            {
                RoomType = RoomType.Hallway
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

        private void CreateFirstFloorSensorlessRooms()
        {
            firstMidHallway = new SensorlessRoom("Mid Hallways", new List<Coordinates>()
            {
                new Coordinates(10.430925523,55.3670798140001),
                new Coordinates(10.430827757,55.3670755860001),
                new Coordinates(10.4307832860001,55.3674076780001),
                new Coordinates(10.4308810520001,55.367411906),
                new Coordinates(10.430925523,55.3670798140001)
            })
            {
                RoomType = RoomType.Hallway
            };
            
            firstUpperRightStairs = new SensorlessRoom("Upper Right Stairs", new List<Coordinates>()
            {
                new Coordinates(10.43084306,55.3676811170001),
                new Coordinates(10.4308380900001,55.367718236),
                new Coordinates(10.4310269540001,55.367726406),
                new Coordinates(10.4310319250001,55.367689286),
                new Coordinates(10.43084306,55.3676811170001)
            })
            {
                RoomType = RoomType.Stairs
            };

            firstLowerLeftStairs = new SensorlessRoom("Lower Left Stairs", new List<Coordinates>()
            {
                new Coordinates(10.430653052,55.3669603700001),
                new Coordinates(10.430842091,55.3669685460001),
                new Coordinates(10.4308470620001,55.3669314250001),
                new Coordinates(10.430658023,55.366923248),
                new Coordinates(10.430653052,55.3669603700001)
            })
            {
                RoomType = RoomType.Stairs
            };

            firstLowerLeftHallway = new SensorlessRoom("Lower Left Hallways", new List<Coordinates>()
            {
                new Coordinates(10.4307459550001,55.367115685),
                new Coordinates(10.430748851,55.3670940640001),
                new Coordinates(10.430824842,55.367097351), 
                new Coordinates(10.430827692,55.367076065),
                new Coordinates(10.430751609,55.3670727740001),
                new Coordinates(10.4307631830001,55.3669863420001),
                new Coordinates(10.4308392670001,55.3669896330001),
                new Coordinates(10.430842091,55.3669685460001),
                new Coordinates(10.430735842,55.3669639510001),
                new Coordinates(10.4307330180001,55.3669850380001),
                new Coordinates(10.430721444,55.36707147),
                new Coordinates(10.430718594,55.367092756),
                new Coordinates(10.4307156990001,55.3671143770001),
                new Coordinates(10.4307459550001,55.367115685),
            })
            {
                RoomType = RoomType.Hallway
            };

            firstLowerRightHallway = new SensorlessRoom("Lower Right Hallways", new List<Coordinates>()
            {
                new Coordinates(10.431026764,55.367106086),
                new Coordinates(10.431041141,55.366998703),
                new Coordinates(10.431041303,55.3669987100001),
                new Coordinates(10.4310441710001,55.366977288),
                new Coordinates(10.4309398570001,55.3669727760001),
                new Coordinates(10.430936988,55.366994199),
                new Coordinates(10.431011105,55.3669974040001),
                new Coordinates(10.430999641,55.3670830200001),
                new Coordinates(10.430925523,55.3670798140001),
                new Coordinates(10.4309226080001,55.367101581),
                new Coordinates(10.430996726,55.3671047870001),
                new Coordinates(10.430994986,55.367117776),
                new Coordinates(10.430993872,55.367126098),
                new Coordinates(10.43102391,55.367127397),
                new Coordinates(10.4310249970001,55.3671192830001),
                new Coordinates(10.431026764,55.367106086)
            })
            {
                RoomType = RoomType.Hallway
            };

            firstLowerMidHallway = new SensorlessRoom("Lower Mid Hallways", new List<Coordinates>()
            {
                new Coordinates(10.430839222,55.3669899700001),
                new Coordinates(10.430936988,55.366994199),
                new Coordinates(10.4309448280001,55.366935654),
                new Coordinates(10.4309397540001,55.3669354350001),
                new Coordinates(10.4309393720001,55.366938288),
                new Coordinates(10.430849659,55.366934407),
                new Coordinates(10.430850041,55.3669315540001),
                new Coordinates(10.4308470620001,55.3669314250001),
            })
            {
                RoomType = RoomType.Hallway
            };

            firstLowerRightUtilities = new SensorlessRoom("Lower Right Utilities", new List<Coordinates>()
            {
                new Coordinates(10.431131771,55.3669437400001),
                new Coordinates(10.4311268000001,55.366980862),
                new Coordinates(10.4309398570001,55.3669727760001),
                new Coordinates(10.4309448280001,55.366935654),
                new Coordinates(10.431131771,55.3669437400001)
            })
            {
                RoomType = RoomType.Hallway
            };

            firstUpperLeftUtilities = new SensorlessRoom("Upper Left Utilities", new List<Coordinates>()
            {
                new Coordinates(10.4305581780001,55.367668795),
                new Coordinates(10.4305532070001,55.3677059140001),
                new Coordinates(10.4307420810001,55.3677140840001),
                new Coordinates(10.4307470520001,55.3676769640001),
                new Coordinates(10.4305581780001,55.367668795)
            })
            {
                RoomType = RoomType.Hallway
            };

            firstMidStairs = new SensorlessRoom("Mid Stairs", new List<Coordinates>()
            {
                new Coordinates(10.430801452,55.3672720260001), 
                new Coordinates(10.43061241,55.367263849), 
                new Coordinates(10.4305945140001,55.367397474),
                new Coordinates(10.430783557,55.3674056510001),
                new Coordinates(10.430801452,55.3672720260001)
            })
            {
                RoomType = RoomType.Stairs
            };

            firstElevator = new SensorlessRoom("Elevator", new List<Coordinates>()
            {
                new Coordinates(10.431086153,55.3672843740001),
                new Coordinates(10.430899213,55.367276288),
                new Coordinates(10.430885613,55.3673778510001),
                new Coordinates(10.4310725510001,55.3673859370001),
                new Coordinates(10.431086153,55.3672843740001)
            })
            {
                RoomType = RoomType.Elevator
            };

            firstUpperHallway = new SensorlessRoom("Upper Hallway", new List<Coordinates>()
            {
                new Coordinates(10.4308810520001,55.367411906),
                new Coordinates(10.4307832860001,55.3674076780001),
                new Coordinates(10.4307644730001,55.3675481670001),
                new Coordinates(10.4307238110001,55.3675464090001),
                new Coordinates(10.430720922,55.3675679830001),
                new Coordinates(10.430761584,55.3675697420001),
                new Coordinates(10.430898127,55.3675756480001),
                new Coordinates(10.4309010150001,55.3675540730001),
                new Coordinates(10.430862239,55.3675523960001),
                new Coordinates(10.4308810520001,55.367411906),
            })
            {
                RoomType = RoomType.Hallway
            };

            firstUpperLeftHallway = new SensorlessRoom("Upper Left Hallway", new List<Coordinates>()
            {
                new Coordinates(10.430720922,55.3675679830001),
                new Coordinates(10.4307238110001,55.3675464090001),
                new Coordinates(10.4306884210001,55.367544878),
                new Coordinates(10.430691305,55.3675233320001),
                new Coordinates(10.430661061,55.367522024),
                new Coordinates(10.4306581770001,55.3675435700001),
                new Coordinates(10.4306582180001,55.367543572),
                new Coordinates(10.430655329,55.3675651460001),
                new Coordinates(10.4306409660001,55.367672376),
                new Coordinates(10.4306714250001,55.367673693),
                new Coordinates(10.4307470520001,55.3676769640001),
                new Coordinates(10.430749948,55.3676553390001),
                new Coordinates(10.430674321,55.367652068),
                new Coordinates(10.430685784,55.3675664630001),
                new Coordinates(10.430720922,55.3675679830001),
            })
            {
                RoomType = RoomType.Hallway
            };

            firstUpperRightHallway = new SensorlessRoom("Upper Right Hallway", new List<Coordinates>()
            {
                new Coordinates(10.430969286,55.367535278),
                new Coordinates(10.430938998,55.367533968),
                new Coordinates(10.430936103,55.367555591),
                new Coordinates(10.4309010150001,55.3675540730001),
                new Coordinates(10.430898127,55.3675756480001),
                new Coordinates(10.4309332350001,55.367577166),
                new Coordinates(10.430921778,55.367662711),
                new Coordinates(10.4308459640001,55.367659432),
                new Coordinates(10.43084306,55.3676811170001),
                new Coordinates(10.4309490590001,55.3676857020001)
            })
            {
                RoomType = RoomType.Hallway
            };

            firstUpperMidHallway = new SensorlessRoom("Upper Mid Hallway", new List<Coordinates>()
            {
                new Coordinates(10.430845956,55.367659491),
                new Coordinates(10.430749948,55.3676553390001),
                new Coordinates(10.4307420810001,55.3677140840001),
                new Coordinates(10.4307452240001,55.36771422),
                new Coordinates(10.4307456060001,55.367711367),
                new Coordinates(10.430835319,55.367715247),
                new Coordinates(10.430834937,55.3677181),
                new Coordinates(10.4308380900001,55.367718236)
            })
            {
                RoomType = RoomType.Hallway
            };

            firstUpperLeftOffices = new SensorlessRoom("Upper Left Offices", new List<Coordinates>()
            {
                new Coordinates(10.4305581780001,55.367668795),
                new Coordinates(10.4305783130001,55.3675184460001),
                new Coordinates(10.430661061,55.367522024),
                new Coordinates(10.4306409660001,55.367672376)
            })
            {
                RoomType = RoomType.Office
            };

            firstUpperRightOffices = new SensorlessRoom("Upper Right Offices", new List<Coordinates>()
            {
                new Coordinates(10.4309490590001,55.3676857020001),
                new Coordinates(10.4310319250001,55.367689286),
                new Coordinates(10.4310520710001,55.367538859),
                new Coordinates(10.430969286,55.367535278)
            })
            {
                RoomType = RoomType.Office
            };

            firstUpperLeftMidOffice = new SensorlessRoom("Upper Mid Left Office", new List<Coordinates>()
            {
                new Coordinates(10.430691305,55.3675233320001),
                new Coordinates(10.4306884210001,55.367544878),
                new Coordinates(10.4307644730001,55.3675481670001),
                new Coordinates(10.430767358,55.36752662)
            })
            {
                RoomType = RoomType.Office
            };

            firstUpperRightMidOffice = new SensorlessRoom("Upper Mid Right Office", new List<Coordinates>()
            {
                new Coordinates(10.430938998,55.367533968),
                new Coordinates(10.430865135,55.3675307730001),
                new Coordinates(10.430862239,55.3675523960001),
                new Coordinates(10.430936103,55.367555591)
            })
            {
                RoomType = RoomType.Office
            };

            firstUpperLeftMidOffices = new SensorlessRoom("Upper Mid Right Offices", new List<Coordinates>()
            {
                new Coordinates(10.430674321,55.367652068),
                new Coordinates(10.430749948,55.3676553390001),
                new Coordinates(10.430761411,55.367569734),
                new Coordinates(10.430685784,55.3675664630001),
            })
            {
                RoomType = RoomType.Office
            };

            firstUpperRightMidOffices = new SensorlessRoom("Upper Mid Right Offices", new List<Coordinates>()
            {
                new Coordinates(10.4309332350001,55.367577166),
                new Coordinates(10.4308574190001,55.367573887),
                new Coordinates(10.4308459640001,55.367659432),
                new Coordinates(10.430921778,55.367662711)
            })
            {
                RoomType = RoomType.Office
            };

            firstLowerLeftOffices = new SensorlessRoom("Lower Left Offices", new List<Coordinates>()
            {
                new Coordinates(10.4306329070001,55.3671107960001),
                new Coordinates(10.4307156990001,55.3671143770001),
                new Coordinates(10.430735842,55.3669639510001),
                new Coordinates(10.430653052,55.3669603700001)
            })
            {
                RoomType = RoomType.Office
            };

            firstLowerRightOffices = new SensorlessRoom("Lower Right Offices", new List<Coordinates>()
            {
                new Coordinates(10.4311268000001,55.366980862),
                new Coordinates(10.4310441710001,55.366977288),
                new Coordinates(10.43102391,55.367127397),
                new Coordinates(10.431106696,55.367130978)
            })
            {
                RoomType = RoomType.Office
            };

            firstLowerRightMidOffice = new SensorlessRoom("Lower Right Mid Office", new List<Coordinates>()
            {
                new Coordinates(10.430996726,55.3671047870001),
                new Coordinates(10.4309226080001,55.367101581),
                new Coordinates(10.4309197540001,55.3671228920001),
                new Coordinates(10.430993872,55.367126098)
            })
            {
                RoomType = RoomType.Office
            };

            firstLowerLeftMidOffice = new SensorlessRoom("Lower Left Mid Office", new List<Coordinates>()
            {
                new Coordinates(10.430748851,55.3670940640001),
                new Coordinates(10.4307459550001,55.367115685),
                new Coordinates(10.430821947,55.3671189720001),
                new Coordinates(10.430824842,55.367097351)
            })
            {
                RoomType = RoomType.Office
            };

            firstLowerLeftMidOffices = new SensorlessRoom("Lower Left Mid Offices", new List<Coordinates>()
            {
                new Coordinates(10.430751609,55.3670727740001),
                new Coordinates(10.430827692,55.367076065),
                new Coordinates(10.4308392670001,55.3669896330001),
                new Coordinates(10.4307631830001,55.3669863420001)
            })
            {
                RoomType = RoomType.Office
            };

            firstLowerRightMidOffices = new SensorlessRoom("Lower Left Mid Offices", new List<Coordinates>()
            {
                new Coordinates(10.431011105,55.3669974040001),
                new Coordinates(10.430936988,55.366994199),
                new Coordinates(10.430925523,55.3670798140001),
                new Coordinates(10.430999641,55.3670830200001),
            })
            {
                RoomType = RoomType.Office
            };
        }

        private void CreateFirstFloorRooms()
        {
            Ø20_603c_2 = new LiveRoom("Ø20-603c-2", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.430821947,55.3671189720001),
                new Coordinates(10.4306329070001,55.3671107960001),
                new Coordinates(10.4306271780001,55.3671535780001),
                new Coordinates(10.4308162180001,55.3671617540001),
            }))
            {
                Alias = "Ø20-603-2",
                MaxOccupants = 36,
                MaxWifiClients = 60,
                MaxTemperature = 25,
                MaxLux = 700,
                Temperature = 22,
                CO2 = 600,
                MaxCO2 = 800,
                TotalPowerConsumption = 22,
                HardwareConsumption = 8,
                VentilationConsumption = 7,
                OtherConsumption = 4,
                LightConsumption = 3,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 400,
                Motion = true,
                Occupants = 20,
                WifiClients = 28,
                SurfaceArea = 53
            };

            Ø20_601b_2 = new LiveRoom("Ø20-601b-2", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4308162180001,55.3671617540001),
                new Coordinates(10.4306271780001,55.3671535780001),
                new Coordinates(10.43061241,55.367263849),
                new Coordinates(10.430801452,55.3672720260001)
            }))
            {
                Alias = "U182",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 120,
                MaxWifiClients = 150,
                Temperature = 24,
                CO2 = 700,
                TotalPowerConsumption = 33.5,
                HardwareConsumption = 9,
                VentilationConsumption = 9.5,
                OtherConsumption = 8,
                LightConsumption = 7,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 550,
                Motion = true,
                Occupants = 60,
                WifiClients = 76,
                SurfaceArea = 139
            };
            
            Ø20_511_2 = new LiveRoom("Ø20-511-2", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.430783557,55.3674056510001),
                new Coordinates(10.4305945140001,55.367397474),
                new Coordinates(10.4305840530001,55.367475589),
                new Coordinates(10.430773097,55.367483765)
            }))
            {
                Alias = "U183",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 48,
                MaxWifiClients = 75,
                Temperature = 24,
                CO2 = 420,
                TotalPowerConsumption = 10,
                HardwareConsumption = 2,
                VentilationConsumption = 3,
                OtherConsumption = 1,
                LightConsumption = 4,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 450,
                Motion = true,
                Occupants = 25,
                WifiClients = 30,
                SurfaceArea = 98
            };

            Ø20_510b_2 = new LiveRoom("Ø20-510b-2", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.430773097,55.367483765),
                new Coordinates(10.4305840530001,55.367475589),
                new Coordinates(10.4305783130001,55.3675184460001),
                new Coordinates(10.430767358,55.36752662)
            }))
            {
                Alias = "Ø20-510-2",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 36,
                MaxWifiClients = 50,
                Temperature = 23,
                CO2 = 550,
                TotalPowerConsumption = 13,
                HardwareConsumption = 5,
                VentilationConsumption = 4,
                OtherConsumption = 2,
                LightConsumption = 2,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = false,
                Lux = 0,
                Motion = false,
                Occupants = 0,
                WifiClients = 0,
                SurfaceArea = 53
            };

            Ø22_603b_2 = new LiveRoom("Ø22-603b-2", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.431106696,55.367130978),
                new Coordinates(10.4309197540001,55.3671228920001),
                new Coordinates(10.430913984,55.3671659830001),
                new Coordinates(10.4311009250001,55.367174069)
            }))
            {
                Alias = "Ø22-603-2",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 36,
                MaxWifiClients = 25,
                Temperature = 22.5,
                CO2 = 430,
                TotalPowerConsumption = 1.7,
                HardwareConsumption = 0.5,
                VentilationConsumption = 1.2,
                OtherConsumption = 0,
                LightConsumption = 0,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = false,
                Lux = 0,
                Motion = false,
                Occupants = 0,
                WifiClients = 0,
                SurfaceArea = 53
            };

            Ø22_601b_2 = new LiveRoom("Ø22-601b-2", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4311009250001,55.367174069),
                new Coordinates(10.430913984,55.3671659830001),
                new Coordinates(10.430899213,55.367276288),
                new Coordinates(10.431086153,55.3672843740001)

            }))
            {
                Alias = "U181",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 120,
                MaxWifiClients = 150,
                Temperature = 24,
                CO2 = 515,
                TotalPowerConsumption = 23,
                HardwareConsumption = 9,
                VentilationConsumption = 9,
                OtherConsumption = 7,
                LightConsumption = 8,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 600,
                Motion = true,
                Occupants = 100,
                WifiClients = 90,
                SurfaceArea = 139
            };

            Ø22_511_2 = new LiveRoom("Ø22-511-2", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.4310725510001,55.3673859370001),
                new Coordinates(10.430885613,55.3673778510001),
                new Coordinates(10.4308708630001,55.367487995),
                new Coordinates(10.4310578000001,55.3674960810001)
            }))
            {
                Alias = "U180",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 48,
                MaxWifiClients = 75,
                Temperature = 24,
                CO2 = 480,
                TotalPowerConsumption = 22,
                HardwareConsumption = 7,
                VentilationConsumption = 4,
                OtherConsumption = 5,
                LightConsumption = 6,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 240,
                Motion = true,
                Occupants = 12,
                WifiClients = 18,
                SurfaceArea = 139
            };

            Ø22_510b_2 = new LiveRoom("Ø22-510b-2", new Corners(new List<Coordinates>()
             {
                new Coordinates(10.430865135,55.3675307730001),
                new Coordinates(10.4310520710001,55.367538859),
                new Coordinates(10.4310578000001,55.3674960810001),
                new Coordinates(10.4308708630001,55.367487995)
            }))
            {
                Alias = "Ø22-510-2",
                MaxTemperature = 25,
                MaxCO2 = 800,
                MaxLux = 700,
                MaxOccupants = 36,
                MaxWifiClients = 50,
                Temperature = 20,
                CO2 = 490,
                TotalPowerConsumption = 14,
                HardwareConsumption = 3.7,
                VentilationConsumption = 4.1,
                OtherConsumption = 1.9,
                LightConsumption = 4.3,
                MaxHardwareConsumption = 10,
                MaxLightConsumption = 10,
                MaxOtherConsumption = 10,
                MaxVentilationConsumption = 10,
                Light = true,
                Lux = 445,
                Motion = false,
                Occupants = 20,
                WifiClients = 16,
                SurfaceArea = 53
            };
        }

        private void AssembleBuilding()
        {
            //Rooms
            cellarFloor.Rooms.Add(cellarPlaceholderRoom );
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
            parterreFloor.Rooms.Add(cellarLowerMidHallway); 
            parterreFloor.Rooms.Add(cellarMidHallway); 
            parterreFloor.Rooms.Add(cellarUpperMidHallway); 
            parterreFloor.Rooms.Add(cellarLowerLeftStairs); 
            parterreFloor.Rooms.Add(cellarUpperRightStairs); 
            parterreFloor.Rooms.Add(cellarMidStairs); 
            parterreFloor.Rooms.Add(cellarElevatorRoom); 
            parterreFloor.Rooms.Add(cellarUpperLeftUtilities); 
            parterreFloor.Rooms.Add(cellarLowerRightUtilities); 
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
            firstFloor.Rooms.Add(firstMidHallway);
            firstFloor.Rooms.Add(firstUpperRightStairs);
            firstFloor.Rooms.Add(firstLowerLeftStairs);
            firstFloor.Rooms.Add(firstLowerLeftHallway);
            firstFloor.Rooms.Add(firstLowerRightHallway);
            firstFloor.Rooms.Add(firstLowerRightUtilities);
            firstFloor.Rooms.Add(firstUpperLeftUtilities);
            firstFloor.Rooms.Add(firstMidStairs);
            firstFloor.Rooms.Add(firstElevator);
            firstFloor.Rooms.Add(firstUpperHallway);
            firstFloor.Rooms.Add(firstUpperLeftHallway);
            firstFloor.Rooms.Add(firstLowerMidHallway);
            firstFloor.Rooms.Add(firstUpperMidHallway);
            firstFloor.Rooms.Add(firstUpperRightHallway);
            firstFloor.Rooms.Add(firstUpperLeftOffices);
            firstFloor.Rooms.Add(firstUpperRightOffices);
            firstFloor.Rooms.Add(firstUpperLeftMidOffice);
            firstFloor.Rooms.Add(firstUpperLeftMidOffices);
            firstFloor.Rooms.Add(firstUpperRightMidOffice);
            firstFloor.Rooms.Add(firstUpperRightMidOffices);
            firstFloor.Rooms.Add(firstLowerLeftOffices);
            firstFloor.Rooms.Add(firstLowerRightOffices);
            firstFloor.Rooms.Add(firstLowerLeftMidOffice);
            firstFloor.Rooms.Add(firstLowerLeftMidOffices);
            firstFloor.Rooms.Add(firstLowerRightMidOffice);
            firstFloor.Rooms.Add(firstLowerRightMidOffices);

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

            if (Ø22_508_0.Lux < 101)
            {
                Ø22_508_0.Lux += random.Next(0, 100);
            }
            else if (Ø22_508_0.Lux > 600)
            {
                Ø22_508_0.Lux -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø22_508_0.Lux += random.Next(0, 100);
                }
                else
                {
                    Ø22_508_0.Lux -= random.Next(0, 100);

                }
            }

            if (Ø22_508_0.Lux < 101)
            {
                Ø22_508_0.Lux += random.Next(0, 100);
            }
            else if (Ø22_508_0.Lux > Ø22_508_0.MaxLux)
            {
                Ø22_508_0.Lux -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø22_508_0.Lux += random.Next(0, 100);
                }
                else
                {
                    Ø22_508_0.Lux -= random.Next(0, 100);

                }
            }

            if (Ø22_508_0.WifiClients < 6 )
            {
                Ø22_508_0.WifiClients += random.Next(0, 5);
            }
            else if (Ø22_508_0.WifiClients > Ø22_508_0.MaxWifiClients)
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

            //LiveRoom Ø20_508a_0
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

            if (Ø20_508a_0.Lux < 101)
            {
                Ø20_508a_0.Lux += random.Next(0, 100);
            }
            else if (Ø20_508a_0.Lux > 600)
            {
                Ø20_508a_0.Lux -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø20_508a_0.Lux += random.Next(0, 100);
                }
                else
                {
                    Ø20_508a_0.Lux -= random.Next(0, 100);

                }
            }

            if (Ø20_508a_0.Lux < 101)
            {
                Ø20_508a_0.Lux += random.Next(0, 100);
            }
            else if (Ø20_508a_0.Lux > Ø20_508a_0.MaxLux)
            {
                Ø20_508a_0.Lux -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø20_508a_0.Lux += random.Next(0, 100);
                }
                else
                {
                    Ø20_508a_0.Lux -= random.Next(0, 100);

                }
            }

            if (Ø20_508a_0.WifiClients < 6)
            {
                Ø20_508a_0.WifiClients += random.Next(0, 5);
            }
            else if (Ø20_508a_0.WifiClients > Ø20_508a_0.MaxWifiClients)
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

            //LiveRoom Ø20_604_0
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

            if (Ø20_604_0.Lux < 101)
            {
                Ø20_604_0.Lux += random.Next(0, 100);
            }
            else if (Ø20_604_0.Lux > 600)
            {
                Ø20_604_0.Lux -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø20_604_0.Lux += random.Next(0, 100);
                }
                else
                {
                    Ø20_604_0.Lux -= random.Next(0, 100);

                }
            }

            if (Ø20_604_0.Lux < 101)
            {
                Ø20_604_0.Lux += random.Next(0, 100);
            }
            else if (Ø20_604_0.Lux > Ø20_604_0.MaxLux)
            {
                Ø20_604_0.Lux -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø20_604_0.Lux += random.Next(0, 100);
                }
                else
                {
                    Ø20_604_0.Lux -= random.Next(0, 100);

                }
            }

            if (Ø20_604_0.WifiClients < 6)
            {
                Ø20_604_0.WifiClients += random.Next(0, 5);
            }
            else if (Ø20_604_0.WifiClients > Ø20_604_0.MaxWifiClients)
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

            //LiveRoom Ø22_604_0
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

            if (Ø22_604_0.Lux < 101)
            {
                Ø22_604_0.Lux += random.Next(0, 100);
            }
            else if (Ø22_604_0.Lux > 600)
            {
                Ø22_604_0.Lux -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø22_604_0.Lux += random.Next(0, 100);
                }
                else
                {
                    Ø22_604_0.Lux -= random.Next(0, 100);
                }
            }

            if (Ø22_604_0.Lux < 101)
            {
                Ø22_604_0.Lux += random.Next(0, 100);
            }
            else if (Ø22_604_0.Lux > Ø22_604_0.MaxLux)
            {
                Ø22_604_0.Lux -= random.Next(0, 100);
            }
            else
            {
                if (random.Next(1, 2) % 2 == 0)
                {
                    Ø22_604_0.Lux += random.Next(0, 100);
                }
                else
                {
                    Ø22_604_0.Lux -= random.Next(0, 100);

                }
            }

            if (Ø22_604_0.WifiClients < 6)
            {
                Ø22_604_0.WifiClients += random.Next(0, 5);
            }
            else if (Ø22_604_0.WifiClients > Ø22_604_0.MaxWifiClients)
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