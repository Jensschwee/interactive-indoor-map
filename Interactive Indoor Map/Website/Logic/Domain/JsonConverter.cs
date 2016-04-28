using System;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Website.Logic.BO;
using Website.Logic.BO.Utility;

namespace Website.Logic.Domain
{
    public class JsonConverter
    {
        public string ConvertBuilding()
        {
            return ConvertBuilding((Building)HttpContext.Current.Application["Building"]);
        }

        public string ConvertBuilding(Building building)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            sb.Append("\"Name\":\"" + building.Name + "\",");
            sb.Append("\"SurfaceArea\":" + building.SurfaceArea + ",");

            sb.Append("\"NumberOfRooms\":" + JsonConvert.SerializeObject(building.NumberOfSensorRoom) + ",");

            sb.Append("\"Temperature\":" + JsonConvert.SerializeObject(building.Temperature) + ",");
            sb.Append("\"CO2\":" + JsonConvert.SerializeObject(building.CO2) + ",");
            sb.Append("\"Light\":" + JsonConvert.SerializeObject(building.Light) + ",");
            sb.Append("\"Lumen\":" + JsonConvert.SerializeObject(building.Lumen) + ",");

            sb.Append("\"HardwareConsumption\":" + JsonConvert.SerializeObject(building.HardwareConsumption) + ",");
            sb.Append("\"LightConsumption\":" + JsonConvert.SerializeObject(building.LightConsumption) + ",");
            sb.Append("\"VentilationConsumption\":" + JsonConvert.SerializeObject(building.VentilationConsumption) + ",");
            sb.Append("\"OtherConsumption\":" + JsonConvert.SerializeObject(building.OtherConsumption) + ",");
            sb.Append("\"TotalPowerConsumption\":" + JsonConvert.SerializeObject(building.TotalPowerConsumption) + ",");

            sb.Append("\"ColdWaterConsumption\":" + JsonConvert.SerializeObject(building.ColdWaterConsumption) + ",");
            sb.Append("\"ColdWaterConsumptionMax\":" + JsonConvert.SerializeObject(building.ColdWaterConsumptionMax) + ",");
            sb.Append("\"HotWaterConsumption\":" + JsonConvert.SerializeObject(building.HotWaterConsumption) + ",");
            sb.Append("\"HotWaterConsumptionMax\":" + JsonConvert.SerializeObject(building.HotWaterConsumptionMax) + ",");

            sb.Append("\"Motion\":" + JsonConvert.SerializeObject(building.Motion) + ",");
            sb.Append("\"Occupants\":" + JsonConvert.SerializeObject(building.Occupants) + ",");
            sb.Append("\"OccupantsMax\":" + JsonConvert.SerializeObject(building.OccupantsMax) + ",");
            sb.Append("\"WifiClients\":" + JsonConvert.SerializeObject(building.WifiClients) + ",");
            sb.Append("\"WifiClientsMax\":" + JsonConvert.SerializeObject(building.WifiClientsMax));
            sb.Append("}");

            return sb.ToString();
        }

        public string ConvertFloors(int floorLevel)
        {
            return ConvertFloors((Building)HttpContext.Current.Application["Building"], floorLevel);
        }

        public string ConvertFloors(Building building, int floorLevel)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            foreach (var floor in building.Floors)
            {
                if (floor.FloorLevel == floorLevel)
                {
                    sb.Append("\"FloorName\":\"" + floor.FloorName + "\",");
                    sb.Append("\"FloorLevel\":" + floor.FloorLevel + ",");
                    sb.Append("\"SurfaceArea\":" + floor.SurfaceArea + ",");
                    sb.Append("\"NumberOfRooms\":" + JsonConvert.SerializeObject(floor.Rooms.Count(room => room.GetType() == typeof(SensorRoom))) + ",");

                    sb.Append("\"Temperature\":" + JsonConvert.SerializeObject(floor.Temperature) + ",");
                    sb.Append("\"CO2\":" + JsonConvert.SerializeObject(floor.CO2) + ",");
                    sb.Append("\"Light\":" + JsonConvert.SerializeObject(floor.Light) + ",");
                    sb.Append("\"Lumen\":" + JsonConvert.SerializeObject(floor.Lumen) + ",");

                    sb.Append("\"HardwareConsumption\":" + JsonConvert.SerializeObject(floor.HardwareConsumption) + ",");
                    sb.Append("\"LightConsumption\":" + JsonConvert.SerializeObject(floor.LightConsumption) + ",");
                    sb.Append("\"VentilationConsumption\":" + JsonConvert.SerializeObject(floor.VentilationConsumption) + ",");
                    sb.Append("\"OtherConsumption\":" + JsonConvert.SerializeObject(floor.OtherConsumption) + ",");
                    sb.Append("\"TotalPowerConsumption\":" + JsonConvert.SerializeObject(floor.TotalPowerConsumption) + ",");

                    sb.Append("\"ColdWaterConsumption\":" + JsonConvert.SerializeObject(floor.ColdWaterConsumption) + ",");
                    sb.Append("\"ColdWaterConsumptionMax\":" + JsonConvert.SerializeObject(floor.ColdWaterConsumptionMax) + ",");
                    sb.Append("\"HotWaterConsumption\":" + JsonConvert.SerializeObject(floor.HotWaterConsumption) + ",");
                    sb.Append("\"HotWaterConsumptionMax\":" + JsonConvert.SerializeObject(floor.HotWaterConsumptionMax) + ",");

                    sb.Append("\"Motion\":" + JsonConvert.SerializeObject(floor.Motion) + ",");
                    sb.Append("\"Occupants\":" + JsonConvert.SerializeObject(floor.Occupants) + ",");
                    sb.Append("\"WifiClients\":" + JsonConvert.SerializeObject(floor.WifiClients) + ",");
                    sb.Append("\"WifiClientsMax\":" + JsonConvert.SerializeObject(floor.WifiClientsMax));
                    break;
                }
            }

            sb.Append("}");

            return sb.ToString();
        }

        public string ConvertRoomsGeoJson(int floorLevel)
        {
            Building building = (Building)HttpContext.Current.Application["Building"];
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"type\": \"FeatureCollection\", \"features\": [");
            foreach (Floor floor in building.Floors)
            {
                if (floor.FloorLevel == floorLevel)
                {
                    foreach (Room room in floor.Rooms)
                    {
                        if (room.GetType() == typeof(SensorRoom))
                        {
                            SensorRoom currentRoom = (SensorRoom)room;
                            sb.Append("{ \"type\": \"Feature\", \"properties\": {");
                            sb.Append("\"RoomType\":" + JsonConvert.SerializeObject(currentRoom.RoomType.ToString()));
                            sb.Append("},\"geometry\": { \"type\": \"Polygon\", \"coordinates\": [ [");
                            sb.Append("[" + JsonConvert.SerializeObject(currentRoom.Corners.TopLeftCorner.XCoordinate) + "," + JsonConvert.SerializeObject(currentRoom.Corners.TopLeftCorner.YCoordinate) + "],");
                            sb.Append("[" + JsonConvert.SerializeObject(currentRoom.Corners.BottomLeftCorner.XCoordinate) + "," + JsonConvert.SerializeObject(currentRoom.Corners.BottomLeftCorner.YCoordinate) + "],");
                            sb.Append("[" + JsonConvert.SerializeObject(currentRoom.Corners.BottomRightCorner.XCoordinate) + "," + JsonConvert.SerializeObject(currentRoom.Corners.BottomRightCorner.YCoordinate) + "],");
                            sb.Append("[" + JsonConvert.SerializeObject(currentRoom.Corners.TopRightCorner.XCoordinate) + "," + JsonConvert.SerializeObject(currentRoom.Corners.TopRightCorner.YCoordinate) + "],");
                            sb.Remove(sb.Length - 1, 1);
                            sb.Append("]]}},");
                        }
                        else if (room.GetType() == typeof(SensorlessRoom))
                        {
                            SensorlessRoom currentRoom = (SensorlessRoom)room;
                            sb.Append("{ \"type\": \"Feature\", \"properties\": {");
                            sb.Append("\"RoomType\":" + JsonConvert.SerializeObject(currentRoom.RoomType.ToString()));
                            sb.Append("},\"geometry\": { \"type\": \"Polygon\", \"coordinates\": [ [");
                            foreach (Coordinates coordinates in currentRoom.Coordinates)
                            {
                                sb.Append("[" + JsonConvert.SerializeObject(coordinates.XCoordinate) + "," + JsonConvert.SerializeObject(coordinates.YCoordinate) + "],");
                            }
                            sb.Remove(sb.Length - 1, 1);
                            sb.Append("]]}},");
                        }
                    }
                    sb.Remove(sb.Length - 1, 1);
                    break;
                }
            }
            sb.Append("]}");
            return sb.ToString();
        }

        public string ConvertRooms(int? floorLevel = null)
        {
            return ConvertRooms((Building)HttpContext.Current.Application["Building"], floorLevel);
        }

        public string ConvertRooms(Building building, int? floorLevel = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"type\": \"FeatureCollection\", \"features\": [");
            foreach (Floor floor in building.Floors)
            {
                if (floor.FloorLevel == floorLevel)
                {
                    foreach (Room room in floor.Rooms)
                    {
                        SensorRoom currentRoom = null;
                        if (typeof(SensorRoom) == room.GetType())
                        {
                            currentRoom = (SensorRoom)room;
                        }
                        else
                        {
                            continue;
                        }
                        sb.Append("{ \"type\": \"Feature\", \"properties\": {");
                        sb.Append("\"Name\":" + JsonConvert.SerializeObject(room.Name) + ",");
                        sb.Append("\"SurfaceArea\":" + JsonConvert.SerializeObject(currentRoom.SurfaceArea) + ",");

                        sb.Append("\"Temperature\":" + JsonConvert.SerializeObject(currentRoom.Temperature) + ",");
                        sb.Append("\"TemperatureMax\":" + JsonConvert.SerializeObject(currentRoom.TemperatureMax) + ",");
                        sb.Append("\"TemperatureMin\":" + JsonConvert.SerializeObject(currentRoom.TemperatureMin) + ",");

                        sb.Append("\"CO2\":" + JsonConvert.SerializeObject(currentRoom.CO2) + ",");
                        sb.Append("\"CO2Max\":" + JsonConvert.SerializeObject(currentRoom.CO2Max) + ",");
                        sb.Append("\"CO2Min\":" + JsonConvert.SerializeObject(currentRoom.CO2Min) + ",");

                        sb.Append("\"Light\":" + JsonConvert.SerializeObject(currentRoom.Light) + ",");

                        sb.Append("\"Lumen\":" + JsonConvert.SerializeObject(currentRoom.Lumen) + ",");
                        sb.Append("\"LumenMax\":" + JsonConvert.SerializeObject(currentRoom.LumenMax) + ",");

                        sb.Append("\"HardwareConsumption\":" + JsonConvert.SerializeObject(currentRoom.HardwareConsumption) + ",");
                        sb.Append("\"HardwareConsumptionMax\":" + JsonConvert.SerializeObject(currentRoom.HardwareConsumptionMax) + ",");
                        sb.Append("\"HardwareConsumptionMin\":" + JsonConvert.SerializeObject(currentRoom.HardwareConsumptionMin) + ",");

                        sb.Append("\"LightConsumption\":" + JsonConvert.SerializeObject(currentRoom.LightConsumption) + ",");
                        sb.Append("\"LightConsumptionMax\":" + JsonConvert.SerializeObject(currentRoom.LightConsumptionMax) + ",");
                        sb.Append("\"LightConsumptionMin\":" + JsonConvert.SerializeObject(currentRoom.LightConsumptionMin) + ",");

                        sb.Append("\"VentilationConsumption\":" + JsonConvert.SerializeObject(currentRoom.VentilationConsumption) + ",");
                        sb.Append("\"VentilationConsumptionMax\":" + JsonConvert.SerializeObject(currentRoom.VentilationConsumptionMax) + ",");
                        sb.Append("\"VentilationConsumptionMin\":" + JsonConvert.SerializeObject(currentRoom.VentilationConsumptionMin) + ",");

                        sb.Append("\"OtherConsumption\":" + JsonConvert.SerializeObject(currentRoom.OtherConsumption) + ",");
                        sb.Append("\"OtherConsumptionMax\":" + JsonConvert.SerializeObject(currentRoom.OtherConsumptionMax) + ",");
                        sb.Append("\"OtherConsumptionMin\":" + JsonConvert.SerializeObject(currentRoom.OtherConsumptionMin) + ",");

                        sb.Append("\"TotalPowerConsumption\":" + JsonConvert.SerializeObject(currentRoom.TotalPowerConsumption) + ",");
                        sb.Append("\"TotalPowerConsumptionMax\":" + JsonConvert.SerializeObject(currentRoom.TotalPowerConsumptionMax) + ",");
                        sb.Append("\"TotalPowerConsumptionMin\":" + JsonConvert.SerializeObject(currentRoom.TotalPowerConsumptionMin) + ",");

                        sb.Append("\"Motion\":" + JsonConvert.SerializeObject(currentRoom.Motion) + ",");

                        sb.Append("\"Occupants\":" + JsonConvert.SerializeObject(currentRoom.Occupants) + ",");
                        sb.Append("\"OccupantsMax\":" + JsonConvert.SerializeObject(currentRoom.OccupantsMax) + ",");

                        sb.Append("\"WifiClients\":" + JsonConvert.SerializeObject(currentRoom.WifiClients) + ",");
                        sb.Append("\"WifiClientsMax\":" + JsonConvert.SerializeObject(currentRoom.WifiClientsMax));

                        sb.Append("},\"geometry\": { \"type\": \"Polygon\", \"coordinates\": [ [");
                        sb.Append("[" + JsonConvert.SerializeObject(currentRoom.Corners.TopLeftCorner.XCoordinate) + "," + JsonConvert.SerializeObject(currentRoom.Corners.TopLeftCorner.YCoordinate) + "],");
                        sb.Append("[" + JsonConvert.SerializeObject(currentRoom.Corners.BottomLeftCorner.XCoordinate) + "," + JsonConvert.SerializeObject(currentRoom.Corners.BottomLeftCorner.YCoordinate) + "],");
                        sb.Append("[" + JsonConvert.SerializeObject(currentRoom.Corners.BottomRightCorner.XCoordinate) + "," + JsonConvert.SerializeObject(currentRoom.Corners.BottomRightCorner.YCoordinate) + "],");
                        sb.Append("[" + JsonConvert.SerializeObject(currentRoom.Corners.TopRightCorner.XCoordinate) + "," + JsonConvert.SerializeObject(currentRoom.Corners.TopRightCorner.YCoordinate) + "],");
                        sb.Remove(sb.Length - 1, 1);
                        sb.Append("]]}},");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    break;
                }
            }
            sb.Append("]}");
            return sb.ToString();
        }
    }
}