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
            Building building = new Building(Program.Building)
            {
                VentilationConsumption = null,
                LightConsumption = null,
                HardwareConsumption = null,
                OtherConsumption = null,
                TotalPowerConsumption = null,
                Occupants = null,
                ColdWaterConsumption = null,
                HotWaterConsumption = null,
            };
            foreach (var floor in building.Floors)
            {
                floor.HardwareConsumption = null;
                floor.LightConsumption = null;
                floor.OtherConsumption = null;
                floor.TotalConsumption = null;
                floor.VentilationConsumption = null;
                floor.Sensors = null;

                foreach (var room in floor.Rooms)
                {
                    room.VentilationConsumption = null;
                    room.CO2 = null;
                    room.HardwareConsumption = null;
                    room.IsMotionDetected = null;
                    room.LightConsumption = null;
                    room.Occupants = null;
                    room.OtherConsumption = null;
                    room.Temperature = null;
                    room.TotalConsumption = null;
                    room.IsLightActivated = null;
                    room.Lumen = null;
                }
            }

            return building;
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
