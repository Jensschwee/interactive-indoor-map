using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Website.BO;
using Website.BO.Utility;

namespace Website.Domain
{
    public class JsonConverter
    {
        public string ConvertBuilding()
        {
            return ConvertBuilding((Building) HttpContext.Current.Application["Building"]);
        }

        public string ConvertBuilding(Building building)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            sb.Append("\"BuildingName\":" + building.BuildingName + ",");
            sb.Append("\"HardwareConsumption\":" + building.HardwareConsumption + ",");
            sb.Append("\"LightConsumption\":" + building.LightConsumption + ",");
            sb.Append("\"VentilationConsumption\":" + building.VentilationConsumption + ",");
            sb.Append("\"OtherConsumption\":" + building.OtherConsumption + ",");
            sb.Append("\"TotalPowerConsumption\":" + building.TotalPowerConsumption + ",");
            sb.Append("\"ColdWaterConsumption\":" + building.ColdWaterConsumption + ",");
            sb.Append("\"HotWaterConsumption\":" + building.HotWaterConsumption);

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
                    sb.Append("\"FloorLevel\":" + floor.FloorLevel + ",");
                    sb.Append("\"HardwareConsumption\":" + floor.HardwareConsumption + ",");
                    sb.Append("\"LightConsumption\":" + floor.LightConsumption + ",");
                    sb.Append("\"VentilationConsumption\":" + floor.VentilationConsumption + ",");
                    sb.Append("\"OtherConsumption\":" + floor.OtherConsumption + ",");
                    sb.Append("\"TotalPowerConsumption\":" + floor.TotalPowerConsumption + ",");
                    sb.Append("\"ColdWaterConsumption\":" + floor.ColdWaterConsumption + ",");
                    sb.Append("\"HotWaterConsumption\":" + floor.HotWaterConsumption);
                }
                break;
            }

            sb.Append("}");

            return sb.ToString();
        }

        public string ConvertRooms(int? floorLevel = null)
        {
            return ConvertRooms((Building) HttpContext.Current.Application["Building"], floorLevel);
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
                        sb.Append("{ \"type\": \"Feature\", \"properties\": {");
                        sb.Append("\"RoomName\":" + JsonConvert.SerializeObject(room.RoomName) + ",");
                        sb.Append("\"CO2\":" + JsonConvert.SerializeObject(room.CO2) + ",");
                        sb.Append("\"HardwareConsumption\":" + JsonConvert.SerializeObject(room.HardwareConsumption) + ",");
                        sb.Append("\"IsLightActivated\":");

                        sb.Append(room.IsLightActivated ? "\"On\"," : "\"Off\",");

                        sb.Append("\"IsMotionDetected\":");

                        sb.Append(room.IsMotionDetected ? "\"Detected\"," : "\"None\",");

                        sb.Append("\"LightConsumption\":" + JsonConvert.SerializeObject(room.LightConsumption) + ",");
                        sb.Append("\"Lumen\":" + JsonConvert.SerializeObject(room.Lumen) + ",");
                        sb.Append("\"Occupants\":" + JsonConvert.SerializeObject(room.Occupants) + ",");
                        sb.Append("\"OtherConsumption\":" + JsonConvert.SerializeObject(room.OtherConsumption) + ",");
                        sb.Append("\"Temperature\":" + JsonConvert.SerializeObject(room.Temperature) + ",");
                        sb.Append("\"TotalPowerConsumption\":" + JsonConvert.SerializeObject(room.TotalPowerConsumption) + ",");
                        sb.Append("\"VentilationConsumption\":" + JsonConvert.SerializeObject(room.VentilationConsumption));
                        sb.Append("},\"geometry\": { \"type\": \"Polygon\", \"coordinates\": [ [");
                        foreach (Coordinates coordinates in room.Area.Vertices)
                        {
                            sb.Append("[" + JsonConvert.SerializeObject(coordinates.XCoordinate) + ","+ JsonConvert.SerializeObject(coordinates.YCoordinate) +  "],");
                        }
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

        public string ConvertSensors(Building building, int floorLevel)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"type\": \"FeatureCollection\", \"features\": [");

            foreach (Floor floor in building.Floors)
            {
                if (floor.FloorLevel == floorLevel)
                {
                    foreach (Sensor sensor in floor.Sensors)
                    {
                        sb.Append("{ \"type\": \"Feature\", \"properties\": {");
                        sb.Append("\"SensorName\":" + JsonConvert.SerializeObject(sensor.SensorName) + ",");
                        sb.Append("\"SensorType\":" + JsonConvert.SerializeObject(sensor.SensorType) + ",");
                        sb.Append("},\"geometry\": { \"type\": \"Point\", \"coordinates\": [ [[");
                        sb.Append(JsonConvert.SerializeObject(sensor.Coordinates.XCoordinate) + "," +
                                  JsonConvert.SerializeObject(sensor.Coordinates.YCoordinate));
                        sb.Append("]");

                        sb.Remove(sb.Length - 1, 1);
                        sb.Append("]]}},");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    break;
                }

            }
            return sb.ToString();
        }
    }
}