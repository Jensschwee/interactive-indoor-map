using System;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Website.Logic.BO;
using Website.Logic.BO.Buildings;
using Website.Logic.BO.Floors;
using Website.Logic.BO.Rooms;
using Website.Logic.BO.Utility;

namespace Website.Logic.Domain
{
    public class LiveJsonConverter : JsonConverter
    {
        public string ConvertBuilding()
        {
            return ConvertBuilding((LiveBuilding)HttpContext.Current.Application["Building"]);
        }

        public string ConvertBuilding(LiveBuilding building)
        {
            StringBuilder sb = new StringBuilder();
            WriteFirstAttribute(sb, "Name", building.Name);
            WriteAttribute(sb, "SurfaceArea", building.SurfaceArea);
            WriteAttribute(sb, "NumberOfRooms", building.NumberOfSensorRooms);

            WriteAttribute(sb, "Temperature", building.Temperature);
            WriteAttribute(sb, "CO2", building.CO2);
            WriteAttribute(sb, "Light", building.Light);
            WriteAttribute(sb, "Lux", building.Lux);

            WriteAttribute(sb, "HardwareConsumption", building.HardwareConsumption);
            WriteAttribute(sb, "LightConsumption", building.LightConsumption);
            WriteAttribute(sb, "VentilationConsumption", building.VentilationConsumption);
            WriteAttribute(sb, "OtherConsumption", building.OtherConsumption);
            WriteAttribute(sb, "TotalPowerConsumption", building.TotalPowerConsumption);

            WriteAttribute(sb, "ColdWaterConsumption", building.ColdWaterConsumption);
            WriteAttribute(sb, "MaxColdWaterConsumption", building.MaxColdWaterConsumption);
            WriteAttribute(sb, "HotWaterConsumption", building.HotWaterConsumption);
            WriteAttribute(sb, "MaxHotWaterConsumption", building.MaxHotWaterConsumption);

            WriteAttribute(sb, "Motion", building.Motion);
            WriteAttribute(sb, "Occupants", building.Occupants);
            WriteAttribute(sb, "MaxOccupants", building.MaxOccupants);
            WriteAttribute(sb, "WifiClients", building.WifiClients);
            WriteLastAttribute(sb, "MaxWifiClients", building.MaxWifiClients);
            return sb.ToString();
        }

        public string ConvertFloors(int floorLevel)
        {
            return ConvertFloors((LiveBuilding)HttpContext.Current.Application["Building"], floorLevel);
        }

        public string ConvertFloors(LiveBuilding building, int floorLevel)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            foreach (var floor in building.Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>())
            {
                if (floor.FloorLevel == floorLevel)
                {
                    sb.Append("\"Name\":\"" + floor.FloorName + "\",");
                    sb.Append("\"FloorLevel\":" + floor.FloorLevel + ",");
                    sb.Append("\"SurfaceArea\":" + floor.SurfaceArea + ",");
                    sb.Append("\"NumberOfRooms\":" + JsonConvert.SerializeObject(floor.NumberOfSensorRooms) + ",");

                    sb.Append("\"Temperature\":" + JsonConvert.SerializeObject(floor.Temperature) + ",");
                    sb.Append("\"CO2\":" + JsonConvert.SerializeObject(floor.CO2) + ",");
                    sb.Append("\"Light\":" + JsonConvert.SerializeObject(floor.Light) + ",");
                    sb.Append("\"Lux\":" + JsonConvert.SerializeObject(floor.Lux) + ",");

                    sb.Append("\"HardwareConsumption\":" + JsonConvert.SerializeObject(floor.HardwareConsumption) + ",");
                    sb.Append("\"LightConsumption\":" + JsonConvert.SerializeObject(floor.LightConsumption) + ",");
                    sb.Append("\"VentilationConsumption\":" + JsonConvert.SerializeObject(floor.VentilationConsumption) + ",");
                    sb.Append("\"OtherConsumption\":" + JsonConvert.SerializeObject(floor.OtherConsumption) + ",");
                    sb.Append("\"TotalPowerConsumption\":" + JsonConvert.SerializeObject(floor.TotalPowerConsumption) + ",");

                    sb.Append("\"ColdWaterConsumption\":" + JsonConvert.SerializeObject(floor.ColdWaterConsumption) + ",");
                    sb.Append("\"MaxColdWaterConsumption\":" + JsonConvert.SerializeObject(floor.MaxColdWaterConsumption) + ",");
                    sb.Append("\"HotWaterConsumption\":" + JsonConvert.SerializeObject(floor.HotWaterConsumption) + ",");
                    sb.Append("\"MaxHotWaterConsumption\":" + JsonConvert.SerializeObject(floor.MaxHotWaterConsumption) + ",");

                    sb.Append("\"Motion\":" + JsonConvert.SerializeObject(floor.Motion) + ",");
                    sb.Append("\"Occupants\":" + JsonConvert.SerializeObject(floor.Occupants) + ",");
                    sb.Append("\"WifiClients\":" + JsonConvert.SerializeObject(floor.WifiClients) + ",");
                    sb.Append("\"MaxWifiClients\":" + JsonConvert.SerializeObject(floor.MaxWifiClients));
                    break;
                }
            }

            sb.Append("}");

            return sb.ToString();
        }

        public string ConvertRoomsGeoJson(int floorLevel)
        {
            LiveBuilding building = (LiveBuilding)HttpContext.Current.Application["Building"];
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"type\": \"FeatureCollection\", \"features\": [");
            foreach (var floor in building.Floors)
            {
                if (floor.FloorLevel == floorLevel)
                {
                    foreach (var room in floor.Rooms)
                    {
                        if (room.GetType() == typeof(LiveRoom))
                        {
                            LiveRoom currentRoom = (LiveRoom)room;
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
            return ConvertRooms((LiveBuilding)HttpContext.Current.Application["Building"], floorLevel);
        }

        public string ConvertRooms(LiveBuilding building, int? floorLevel = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"type\": \"FeatureCollection\", \"features\": [");
            foreach (var floor in building.Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>())
            {
                if (floor.FloorLevel == floorLevel)
                {
                    foreach (Room room in floor.Rooms)
                    {
                        LiveRoom currentRoom = null;
                        if (typeof(LiveRoom) == room.GetType())
                        {
                            currentRoom = (LiveRoom)room;
                        }
                        else
                        {
                            continue;
                        }
                        sb.Append("{ \"type\": \"Feature\", \"properties\": {");
                        sb.Append("\"Name\":" + JsonConvert.SerializeObject(room.Name) + ",");
                        sb.Append("\"SurfaceArea\":" + JsonConvert.SerializeObject(currentRoom.SurfaceArea) + ",");
                        sb.Append("\"Alias\":" + JsonConvert.SerializeObject(currentRoom.Alias) + ",");

                        sb.Append("\"Temperature\":" + JsonConvert.SerializeObject(currentRoom.Temperature) + ",");
                        sb.Append("\"MaxTemperature\":" + JsonConvert.SerializeObject(currentRoom.MaxTemperature) + ",");
                        sb.Append("\"MinTemperature\":" + JsonConvert.SerializeObject(currentRoom.MinTemperature) + ",");

                        sb.Append("\"CO2\":" + JsonConvert.SerializeObject(currentRoom.CO2) + ",");
                        sb.Append("\"MaxCO2\":" + JsonConvert.SerializeObject(currentRoom.MaxCO2) + ",");
                        sb.Append("\"MinCO2\":" + JsonConvert.SerializeObject(currentRoom.MinCO2) + ",");

                        sb.Append("\"Light\":" + JsonConvert.SerializeObject(currentRoom.Light) + ",");

                        sb.Append("\"Lux\":" + JsonConvert.SerializeObject(currentRoom.Lux) + ",");
                        sb.Append("\"MaxLux\":" + JsonConvert.SerializeObject(currentRoom.MaxLux) + ",");

                        sb.Append("\"HardwareConsumption\":" + JsonConvert.SerializeObject(currentRoom.HardwareConsumption) + ",");
                        sb.Append("\"MaxHardwareConsumption\":" + JsonConvert.SerializeObject(currentRoom.MaxHardwareConsumption) + ",");
                        sb.Append("\"MinHardwareConsumption\":" + JsonConvert.SerializeObject(currentRoom.MinHardwareConsumption) + ",");

                        sb.Append("\"LightConsumption\":" + JsonConvert.SerializeObject(currentRoom.LightConsumption) + ",");
                        sb.Append("\"MaxLightConsumption\":" + JsonConvert.SerializeObject(currentRoom.MaxLightConsumption) + ",");
                        sb.Append("\"MinLightConsumption\":" + JsonConvert.SerializeObject(currentRoom.MinLightConsumption) + ",");

                        sb.Append("\"VentilationConsumption\":" + JsonConvert.SerializeObject(currentRoom.VentilationConsumption) + ",");
                        sb.Append("\"MaxVentilationConsumption\":" + JsonConvert.SerializeObject(currentRoom.MaxVentilationConsumption) + ",");
                        sb.Append("\"MinVentilationConsumption\":" + JsonConvert.SerializeObject(currentRoom.MinVentilationConsumption) + ",");

                        sb.Append("\"OtherConsumption\":" + JsonConvert.SerializeObject(currentRoom.OtherConsumption) + ",");
                        sb.Append("\"MaxOtherConsumption\":" + JsonConvert.SerializeObject(currentRoom.MaxOtherConsumption) + ",");
                        sb.Append("\"MinOtherConsumption\":" + JsonConvert.SerializeObject(currentRoom.MinOtherConsumption) + ",");

                        sb.Append("\"TotalPowerConsumption\":" + JsonConvert.SerializeObject(currentRoom.TotalPowerConsumption) + ",");
                        sb.Append("\"MaxTotalPowerConsumption\":" + JsonConvert.SerializeObject(currentRoom.MaxTotalPowerConsumption) + ",");
                        sb.Append("\"MinTotalPowerConsumption\":" + JsonConvert.SerializeObject(currentRoom.MinTotalPowerConsumption) + ",");

                        sb.Append("\"Motion\":" + JsonConvert.SerializeObject(currentRoom.Motion) + ",");

                        sb.Append("\"Occupants\":" + JsonConvert.SerializeObject(currentRoom.Occupants) + ",");
                        sb.Append("\"MaxOccupants\":" + JsonConvert.SerializeObject(currentRoom.MaxOccupants) + ",");

                        sb.Append("\"WifiClients\":" + JsonConvert.SerializeObject(currentRoom.WifiClients) + ",");
                        sb.Append("\"MaxWifiClients\":" + JsonConvert.SerializeObject(currentRoom.MaxWifiClients));

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