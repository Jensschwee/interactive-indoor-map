﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.BO;
using Website.BO.Utility;

namespace Website.Domain
{
    public class BuildingSetup
    {
        public void SetupBuilding()
        {
            Building building = new Building();
            Floor cellarFloor = new Floor(-1);
            Floor groundFloor = new Floor(0);
            Floor firstFloor = new Floor(1);
            Floor secondFloor = new Floor(2);
            //Room Ø20_501c_2 = new Room("Ø20-501c-2", );
            Room Ø20_508a_0 = new Room("Ø20-508a-0", new Area(new List<Coordinates> { new Coordinates(10.430732667446136, 55.367447995895),
                new Coordinates(10.430542230606079, 55.36744037424566), new Coordinates(10.43051540851593, 55.36767054740808),
                new Coordinates(10.430711209774017, 55.367673596050246), new Coordinates(10.430732667446136, 55.367447995895)}));
            Ø20_508a_0.Temperature = 20;

            Room Ø22_508_0 = new Room("Ø22-508-0", new Area(new List<Coordinates> { new Coordinates(10.43104112148285, 55.36767664469221),
                new Coordinates(10.430856049060822, 55.36767207172922), new Coordinates(10.430874824523926, 55.367451044554315),
                new Coordinates(10.431067943572998, 55.36746171486007), new Coordinates(10.43104112148285, 55.36767664469221)}));
            Ø22_508_0.Temperature = 21.5;

            Room Ø22_604_0 = new Room("Ø22-604-0", new Area(new List<Coordinates> { new Coordinates(10.430928468704224, 55.36698916998991),
                new Coordinates(10.431126952171324, 55.3669983160732), new Coordinates(10.431097447872162, 55.367223918792),
                new Coordinates(10.430896282196045, 55.36721629709953), new Coordinates(10.430928468704224, 55.36698916998991)}));
            Ø22_604_0.Temperature = 23;

            Room Ø20_604_0 = new Room("Ø20_604_0", new Area(new List<Coordinates> { new Coordinates(10.430603921413422, 55.36697392651307),
                new Coordinates(10.430810451507568, 55.36698307259987), new Coordinates(10.430764853954315, 55.367210199744484),
                new Coordinates(10.430574417114258, 55.36719952937089), new Coordinates(10.430603921413422, 55.36697392651307)}));
            Ø20_604_0.Temperature = 19.5;

            groundFloor.Rooms.Add(Ø22_508_0);
            groundFloor.Rooms.Add(Ø20_508a_0);
            groundFloor.Rooms.Add(Ø22_604_0);
            groundFloor.Rooms.Add(Ø20_604_0);

            building.Floors.Add(cellarFloor);
            building.Floors.Add(groundFloor);
            building.Floors.Add(firstFloor);
            building.Floors.Add(secondFloor);

            HttpContext.Current.Application["Building"] = building;

        }
    }
}