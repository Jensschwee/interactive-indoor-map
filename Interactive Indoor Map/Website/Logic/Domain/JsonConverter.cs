using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace Website.Logic.Domain
{
    public abstract class JsonConverter
    {
        public void WriteAttribute(StringBuilder sb, string attributeName, object attributeValue)
        {
            sb.Append("\"");
            sb.Append(attributeName);
            sb.Append("\":");
            sb.Append(JsonConvert.SerializeObject(attributeValue));
            sb.Append(",");
        }

        public void WriteLastAttribute(StringBuilder sb, string attributeName, object attributeValue)
        {
            sb.Append("\"");
            sb.Append(attributeName);
            sb.Append("\":");
            sb.Append(JsonConvert.SerializeObject(attributeValue));
            sb.Append("}");
        }

        public void WriteFirstAttribute(StringBuilder sb, string attributeName, object attributeValue)
        {
            sb.Append("{\"");
            sb.Append(attributeName);
            sb.Append("\":");
            sb.Append(JsonConvert.SerializeObject(attributeValue));
            sb.Append(",");
        }

        public void WriteGeoJsonHeader(StringBuilder sb)
        {
            sb.Append("{\"type\": \"FeatureCollection\", \"features\": [");

        }

        public void WriteGeoJsonFooter(StringBuilder sb)
        {
            sb.Append("]}");    
        }

        public void WriteGeoJsonPropertiesHeader(StringBuilder sb)
        {
            sb.Append("{ \"type\": \"Feature\", \"properties\": {");
        }

        public void WriteGeoJsonPropertiesFooter(StringBuilder sb)
        {
            sb.Append("},");
        }

        public void WriteGeoJsonGeometryHeader(StringBuilder sb)
        {
            sb.Append("\"geometry\": { \"type\": \"Polygon\", \"coordinates\": [ [");
        }

        public void WriteGeoJsonGeometryFooter(StringBuilder sb)
        {
            sb.Append("]]}},");
        }
    }
}