using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingService.Domain;

namespace BuildingService.Service
{
    public class Program
    {
        public static void Main()
        {
            Building fullBuilding = new Building();
            Building cellarFloorBuilding = new Building();
            Building groundFloorBuilding = new Building();
            Building firstFloorBuilding = new Building();
            Building secondFloorBuilding = new Building();
            Floor cellarFloor = new Floor(-1);
            Floor groundFloor = new Floor(0);
            Floor firstFloor = new Floor(1);
            Floor secondFloor = new Floor(2);
            Room room1 = new Room();
            Room room2 = new Room();
            Room room3 = new Room();
            Room room4 = new Room();
            Room room5 = new Room();
            Room room6 = new Room();
            Room room7 = new Room();

            fullBuilding.Floors.Add(cellarFloor);
            fullBuilding.Floors.Add(groundFloor);
            fullBuilding.Floors.Add(firstFloor);
            fullBuilding.Floors.Add(secondFloor);
            
        }
    }
}