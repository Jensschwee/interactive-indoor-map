using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Web;
using BuildingService.Domain;
using BuildingService.Domain.Utility;

namespace BuildingService.Service
{
    public class Program
    {
        public static Building Building;

        public static void Main()
        {
            var host = InitializeHost();
            host.Open();

            InitializeBuilding();


            Console.WriteLine("Service is running..");
            Console.WriteLine("Press Enter to shut it down");
            Console.ReadLine();
            host.Close();

        }

        private static WebServiceHost InitializeHost()
        {
            Uri baseAddress = new Uri("http://localhost:8080");

            WebServiceHost host = new WebServiceHost(typeof(Program), baseAddress);
            WebHttpBinding binding = new WebHttpBinding();
            host.AddServiceEndpoint(typeof(IBuildingService), binding, "WebServiceHost");

            return host;
        }

        private static void InitializeBuilding()
        {
            //Er 90% sikker på at dette bare skal være i BuildingService, derefter skal det 
            Building = new Building();
            Floor cellarFloor = new Floor(-1);
            Floor groundFloor = new Floor(0);
            Floor firstFloor = new Floor(1);
            Floor secondFloor = new Floor(2);
            //Room Ø20_501c_2 = new Room("Ø20-501c-2", );
            Room Ø20_508a_0 = new Room("Ø20-508a-0", new Area(new List<Coordinates> { new Coordinates(10.430732667446136, 55.367447995895),
                new Coordinates(10.430542230606079, 55.36744037424566), new Coordinates(10.43051540851593, 55.36767054740808),
                new Coordinates(10.430711209774017, 55.367673596050246), new Coordinates(10.430732667446136, 55.367447995895)}));

            //Her er jeg nået til, resten af koordinaterne skal ændres

            Room Ø22_508_0 = new Room("Ø22-508-0", new Area(new List<Coordinates> { new Coordinates(10.430732667446136, 55.367447995895),
                new Coordinates(10.430542230606079, 55.36744037424566), new Coordinates(10.43051540851593, 55.36767054740808),
                new Coordinates(10.430711209774017, 55.367673596050246), new Coordinates(10.430732667446136, 55.367447995895)}));

            Room Ø22_604_0 = new Room("Ø22-604-0", new Area(new List<Coordinates> { new Coordinates(10.430732667446136, 55.367447995895),
                new Coordinates(10.430542230606079, 55.36744037424566), new Coordinates(10.43051540851593, 55.36767054740808),
                new Coordinates(10.430711209774017, 55.367673596050246), new Coordinates(10.430732667446136, 55.367447995895)}));

            Room Ø20_604_0 = new Room("Ø20_604_0", new Area(new List<Coordinates> { new Coordinates(10.430732667446136, 55.367447995895),
                new Coordinates(10.430542230606079, 55.36744037424566), new Coordinates(10.43051540851593, 55.36767054740808),
                new Coordinates(10.430711209774017, 55.367673596050246), new Coordinates(10.430732667446136, 55.367447995895)}));

            groundFloor.Rooms.Add(Ø22_508_0);
            groundFloor.Rooms.Add(Ø20_508a_0);
            groundFloor.Rooms.Add(Ø22_604_0);
            groundFloor.Rooms.Add(Ø20_604_0);

            Building.Floors.Add(cellarFloor);
            Building.Floors.Add(groundFloor);
            Building.Floors.Add(firstFloor);
            Building.Floors.Add(secondFloor);
        }
    }
}