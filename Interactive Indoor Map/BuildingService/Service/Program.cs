using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Web;
using BuildingService.Domain;

namespace BuildingService.Service
{
    public class Program
    {
        public static Building Building;

        public static void Main()
        {
            var host = InitializeHost();

            host.Open();
            Building = InitializeBuilding();
            

            Console.WriteLine("Service is running..");
            Console.WriteLine("Press Enter to shut it down");
            Console.ReadLine();
            host.Close();

        }

        private static WebServiceHost InitializeHost()
        {
            Uri baseAddress = new Uri("http://localhost:8080");

            WebServiceHost host = new WebServiceHost(typeof (Program), baseAddress);
            WebHttpBinding binding = new WebHttpBinding();
            host.AddServiceEndpoint(typeof (IBuildingService), binding, "WebServiceHost");

            return host;
        }

        private static Building InitializeBuilding()
        {
            //Er 90% sikker på at dette bare skal være i BuildingService, derefter skal det 
            Building building = new Building();
            Floor cellarFloor = new Floor(-1);
            Floor groundFloor = new Floor(0);
            Floor firstFloor = new Floor(1);
            Floor secondFloor = new Floor(2);
            Room room1 = new Room("1");
            Room room2 = new Room("2");
            Room room3 = new Room("3");
            Room room4 = new Room("4");
            Room room5 = new Room("5");
            Room room6 = new Room("6");
            Room room7 = new Room("7");

            cellarFloor.Rooms.Add(room1);
            groundFloor.Rooms.Add(room2);
            groundFloor.Rooms.Add(room3);
            groundFloor.Rooms.Add(room4);
            firstFloor.Rooms.Add(room5);
            secondFloor.Rooms.Add(room6);
            secondFloor.Rooms.Add((room7));

            building.Floors.Add(cellarFloor);
            building.Floors.Add(groundFloor);
            building.Floors.Add(firstFloor);
            building.Floors.Add(secondFloor);

            return building;
        }
    }
}