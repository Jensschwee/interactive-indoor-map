﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Timers;
using System.Web;
using Website.Logic.BO;
using Website.Logic.BO.Utility;
using Website.Persistence;

namespace Website.Logic.Domain
{
    public class BuildingSetup
    {
        private BuildingDAL buildingDAL;
        private Building building;
        private Floor cellarFloor;
        private Floor groundFloor;
        private Floor firstFloor;
        private Floor secondFloor;
        private Room testRoomCellar1;
        private Room testRoomFirstFloor1;
        private Room testRoomFirstFloor2;
        private Room testRoomSecondFloor1;
        private Room testRoomSecondFloor2;
        private Room testRoom;
        private Room Ø22_508_0;
        private Room Ø22_604_0;
        private Room Ø20_604_0;
        private Room Ø20_508a_0;
        private Room Ø20_606_1;
        private Room Ø22_606c_1;

        public void SetupBuilding()
        {
            //buildingDAL = new BuildingDAL();
            //building = buildingDAL.GetBuilding("Building 44");

            CreateBuilding();

            CreateFloors();

            CreateRooms();

            AssembleBuilding();

            HttpContext.Current.Application["Building"] = building;

            TestTimer();
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

            CreateSensors();
        }

        private void CreateSensors()
        {
            testSensor = new Sensor("Test Sensor", "Laptop");
            cellarFloor.Sensors.Add(testSensor);
        }

        private void CreateRooms()
        {
            testRoomCellar1 = new Room("testRoomCellar1", new Corners(new List<Coordinates>()
            {
                //Top Left Room
                
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

            testRoomFirstFloor1 = new Room("testRoomFirstFloor1", new Corners(new List<Coordinates>()
            {
                //Bottom Right Room
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

            testRoomFirstFloor2 = new Room("testRoomFirstFloor2", new Corners(new List<Coordinates>()
            {
                //Bottom Left Room
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

            testRoomSecondFloor1 = new Room("testRoomSecondFloor1", new Corners(new List<Coordinates>()
            {
                //Top Left Room
                
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

            testRoomSecondFloor2 = new Room("testRoomSecondFloor2", new Corners(new List<Coordinates>()
            {
                //Top Right Room
                
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

            Ø20_508a_0 = new Room("Ø20-508a-0", new Corners(new List<Coordinates>()
            {
                //Top Left Room
                
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

            Ø22_508_0 = new Room("Ø22-508-0", new Corners(new List<Coordinates>()
            {
                //Top Right Room
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

            Ø22_604_0 = new Room("Ø22-604-0", new Corners(new List<Coordinates>()
            {
                //Bottom Right Room
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

            Ø20_604_0 = new Room("Ø20_604_0", new Corners(new List<Coordinates>()
            {
                //Bottom Left Room
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

            Ø20_606_1 = new Room("Ø20-606-1", new Corners(new List<Coordinates>()
            {
                //Top Left Room
                
                new Coordinates(10.43070692999217,55.36711127188644),
                new Coordinates(10.43056692392323,55.36710705298766),
                new Coordinates(10.43057877027221,55.36699865466709),
                new Coordinates(10.43071804722406,55.3670028455568)
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

            Ø22_606c_1 = new Room("Ø22-606c-1", new Corners(new List<Coordinates>()
            {
                //Top Left Room
                
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

        private void AssembleBuilding()
        {
            cellarFloor.Rooms.Add(testRoomCellar1);
            groundFloor.Rooms.Add(Ø22_508_0);
            groundFloor.Rooms.Add(Ø20_508a_0);
            groundFloor.Rooms.Add(Ø22_604_0);
            groundFloor.Rooms.Add(Ø20_604_0);
            groundFloor.Rooms.Add(Ø20_606_1);
            groundFloor.Rooms.Add(Ø22_606c_1);
            firstFloor.Rooms.Add(testRoomFirstFloor1);
            firstFloor.Rooms.Add(testRoomFirstFloor2);
            secondFloor.Rooms.Add(testRoomSecondFloor1);
            secondFloor.Rooms.Add(testRoomSecondFloor2);

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

            //Room Ø20_508a_0
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

            //Room Ø20_604_0
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

            //Room Ø22_604_0
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