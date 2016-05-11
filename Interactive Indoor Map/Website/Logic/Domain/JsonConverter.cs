﻿using System;
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
            WriteAttributeDefault(sb, attributeName, attributeValue);
            sb.Append(",");
        }

        private void WriteAttributeDefault(StringBuilder sb, string attributeName, object attributeValue)
        {
            sb.Append("\"");
            sb.Append(attributeName);
            sb.Append("\":");
            sb.Append(JsonConvert.SerializeObject(attributeValue));
        }

        public void WriteLastAttribute(StringBuilder sb, string attributeName, object attributeValue)
        {
            WriteAttributeDefault(sb, attributeName, attributeValue);
            sb.Append("}");
        }

        public void WriteFirstAttribute(StringBuilder sb, string attributeName, object attributeValue)
        {
            sb.Append("{");
            WriteAttribute(sb, attributeName, attributeValue);
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
            sb.Append("{ \"type\": \"Feature\", \"properties\":");
        }

        public void WriteGeoJsonPropertiesFooter(StringBuilder sb)
        {
            sb.Append("},");
        }

        public void WriteGeoJsonGeometryHeader(StringBuilder sb)
        {
            sb.Append("\"geometry\": { \"type\": \"Polygon\", \"coordinates\": [ [");
        }

        public void WriteGeoJsonCoordinates(StringBuilder sb, double XCoordinate, double YCoordinate)
        {
            WriteGeoJsonCoordinatesLast(sb, XCoordinate, YCoordinate);
            sb.Append(",");
        }

        public void WriteGeoJsonCoordinatesLast(StringBuilder sb, double XCoordinate, double YCoordinate)
        {

            sb.Append("[");
            sb.Append(JsonConvert.SerializeObject(XCoordinate));
            sb.Append(",");
            sb.Append(JsonConvert.SerializeObject(YCoordinate));
            sb.Append("]");
        }

        public void WriteGeoJsonGeometryFooter(StringBuilder sb)
        {
            sb.Append("]]}},");
        }
    }
}