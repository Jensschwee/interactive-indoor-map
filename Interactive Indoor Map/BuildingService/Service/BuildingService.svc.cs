using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BuildingService.Domain;

namespace BuildingService.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BuildingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BuildingService.svc or BuildingService.svc.cs at the Solution Explorer and start debugging.
    public class BuildingService : IBuildingService
    {

        public Building BuildingDimensions()
        {
            throw new NotImplementedException();
        }

        public Building SensorLocations()
        {
            throw new NotImplementedException();
        }

        public Building BuildingSensorData()
        {
            throw new NotImplementedException();
        }

        public Building FloorSensorData()
        {
            throw new NotImplementedException();
        }

        public Building RoomSensorData()
        {
            throw new NotImplementedException();
        }

        public Building WifiClients()
        {
            throw new NotImplementedException();
        }

        public Building StoreBuildingSensorData()
        {
            throw new NotImplementedException();
        }
    }
}
