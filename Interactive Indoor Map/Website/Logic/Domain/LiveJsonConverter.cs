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

            foreach (var floor in building.Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>())
            {
                if (floor.FloorLevel == floorLevel)
                {
                    WriteFirstAttribute(sb,"Name", floor.FloorName);
                    WriteAttribute(sb, "FloorLevel", floor.FloorLevel);
                    WriteAttribute(sb, "SurfaceArea", floor.SurfaceArea);
                    WriteAttribute(sb, "NumberOfRooms", floor.NumberOfSensorRooms);

                    WriteAttribute(sb, "Temperature", floor.Temperature);
                    WriteAttribute(sb, "CO2", floor.CO2);
                    WriteAttribute(sb, "Light", floor.Light);
                    WriteAttribute(sb, "Lux", floor.Lux);

                    WriteAttribute(sb, "HardwareConsumption", floor.HardwareConsumption);
                    WriteAttribute(sb, "LightConsumption", floor.LightConsumption);
                    WriteAttribute(sb, "VentilationConsumption", floor.VentilationConsumption);
                    WriteAttribute(sb, "OtherConsumption", floor.OtherConsumption);
                    WriteAttribute(sb, "TotalPowerConsumption", floor.TotalPowerConsumption);

                    WriteAttribute(sb, "ColdWaterConsumption", floor.ColdWaterConsumption);
                    WriteAttribute(sb, "MaxColdWaterConsumption", floor.MaxColdWaterConsumption);
                    WriteAttribute(sb, "HotWaterConsumption", floor.HotWaterConsumption);
                    WriteAttribute(sb, "MaxHotWaterConsumption", floor.MaxHotWaterConsumption);

                    WriteAttribute(sb, "Motion", floor.Motion);
                    WriteAttribute(sb, "Occupants", floor.Occupants);
                    WriteAttribute(sb, "WifiClients", floor.WifiClients);
                    WriteLastAttribute(sb, "MaxWifiClients", building.MaxWifiClients);
                    break;
                }
            }
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
            WriteGeoJsonHeader(sb);
            foreach (var floor in building.Floors.Where(floor => floor.GetType() == typeof(LiveFloor)).Cast<LiveFloor>())
            {
                if (floor.FloorLevel == floorLevel)
                {
                    foreach (Room room in floor.Rooms)
                    {
                        if (typeof(LiveRoom) == room.GetType())
                        {
                            LiveRoom currentRoom = (LiveRoom)room;
                            WriteGeoJsonPropertiesHeader(sb);
                            WriteFirstAttribute(sb, "Name", currentRoom.Name);
                            WriteAttribute(sb, "SurfaceArea", currentRoom.SurfaceArea);
                            WriteAttribute(sb, "Alias", currentRoom.Alias);

                            WriteAttribute(sb, "Temperature", currentRoom.Temperature);
                            WriteAttribute(sb, "MaxTemperature", currentRoom.MaxTemperature);
                            WriteAttribute(sb, "MinTemperature", currentRoom.MinTemperature);

                            WriteAttribute(sb, "CO2", currentRoom.CO2);
                            WriteAttribute(sb, "MaxCO2", currentRoom.MaxCO2);
                            WriteAttribute(sb, "MinCO2", currentRoom.MinCO2);

                            WriteAttribute(sb, "Light", currentRoom.Light);
                            WriteAttribute(sb, "Lux", currentRoom.Lux);
                            WriteAttribute(sb, "MaxLux", currentRoom.MaxLux);

                            WriteAttribute(sb, "HardwareConsumption", currentRoom.HardwareConsumption);
                            WriteAttribute(sb, "MaxHardwareConsumption", currentRoom.MaxHardwareConsumption);
                            WriteAttribute(sb, "MinHardwareConsumption", currentRoom.MinHardwareConsumption);


                            WriteAttribute(sb, "LightConsumption", currentRoom.LightConsumption);
                            WriteAttribute(sb, "MaxLightConsumption", currentRoom.MaxLightConsumption);
                            WriteAttribute(sb, "MinLightConsumption", currentRoom.MinLightConsumption);

                            WriteAttribute(sb, "VentilationConsumption", currentRoom.VentilationConsumption);
                            WriteAttribute(sb, "MaxVentilationConsumption", currentRoom.MaxVentilationConsumption);
                            WriteAttribute(sb, "MinVentilationConsumption", currentRoom.MinVentilationConsumption);

                            WriteAttribute(sb, "OtherConsumption", currentRoom.OtherConsumption);
                            WriteAttribute(sb, "MaxOtherConsumption", currentRoom.MaxOtherConsumption);
                            WriteAttribute(sb, "MinOtherConsumption", currentRoom.MinOtherConsumption);

                            WriteAttribute(sb, "TotalPowerConsumption", currentRoom.TotalPowerConsumption);
                            WriteAttribute(sb, "MaxTotalPowerConsumption", currentRoom.MaxTotalPowerConsumption);
                            WriteAttribute(sb, "MinTotalPowerConsumption", currentRoom.MinTotalPowerConsumption);

                            WriteAttribute(sb, "Motion", currentRoom.Motion);
                            WriteAttribute(sb, "Occupants", currentRoom.Occupants);
                            WriteAttribute(sb, "MaxOccupants", currentRoom.MaxOccupants);

                            WriteAttribute(sb, "WifiClients", currentRoom.WifiClients);
                            WriteAttribute(sb, "MaxOccupants", currentRoom.MaxOccupants);
                            WriteAttribute(sb, "MaxWifiClients", currentRoom.MaxWifiClients);

                            WriteGeoJsonPropertiesFooter(sb);

                            WriteGeoJsonGeometryHeader(sb);
                            WriteGeoJsonCoordinates(sb, currentRoom.Corners.TopLeftCorner.XCoordinate, currentRoom.Corners.TopLeftCorner.YCoordinate);
                            WriteGeoJsonCoordinates(sb, currentRoom.Corners.BottomLeftCorner.XCoordinate, currentRoom.Corners.BottomLeftCorner.YCoordinate);
                            WriteGeoJsonCoordinates(sb, currentRoom.Corners.BottomRightCorner.XCoordinate, currentRoom.Corners.BottomRightCorner.YCoordinate);
                            WriteGeoJsonCoordinatesLast(sb, currentRoom.Corners.TopRightCorner.XCoordinate, currentRoom.Corners.TopRightCorner.YCoordinate);
                            WriteGeoJsonGeometryFooter(sb);
                        }
                    }
                    sb.Remove(sb.Length - 1, 1);
                    break;
                }
            }
            WriteGeoJsonFooter(sb);
            return sb.ToString();
        }
    }
}