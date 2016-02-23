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
    public class GeoJsonConverter
    {

        public string Convert(Building building, int? floorLevel = null)
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
                        sb.Append("\"IsLightActivated\":" + JsonConvert.SerializeObject(room.IsLightActivated) + ",");
                        sb.Append("\"IsMotionDetected\":" + JsonConvert.SerializeObject(room.IsMotionDetected) + ",");
                        sb.Append("\"LightConsumption\":" + JsonConvert.SerializeObject(room.LightConsumption) + ",");
                        sb.Append("\"Lumen\":" + JsonConvert.SerializeObject(room.Lumen) + ",");
                        sb.Append("\"Occupants\":" + JsonConvert.SerializeObject(room.Occupants) + ",");
                        sb.Append("\"OtherConsumption\":" + JsonConvert.SerializeObject(room.OtherConsumption) + ",");
                        sb.Append("\"Temperature\":" + JsonConvert.SerializeObject(room.Temperature) + ",");
                        sb.Append("\"TotalConsumption\":" + JsonConvert.SerializeObject(room.TotalConsumption) + ",");
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

    }
}