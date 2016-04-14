﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Website.Logic.BO.Utility;

namespace Website.DAL.ExternalData
{
    public class SMAP
    {

        private static readonly string ENDPOINT = @"http://10.123.3.12:8079/api/query";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uuid"></param>
        /// <param name="sensorSource">
        /// To get power use OU44-EnergyKey else use OpcUa
        /// </param>
        /// <returns></returns>
        public double GetCurrentSensorValue(string uuid, string sensorSource)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select data before now where uuid = ");
            sb.Append("'" + uuid + "'");
            sb.Append("and Metadata/SourceName like ");
            sb.Append("'" + sensorSource + "'");
            return sendHTTPPost(ENDPOINT, sb.ToString()).Readings[0][1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uuid"></param>
        /// <param name="sensorSoruce">
        /// To get power use OU44-EnergyKey else use OpcUa
        /// </param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public SMapSensorReading GetHistoricSensorValue(string uuid, string sensorSoruce, DateTime fromDate, DateTime toDate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select data in (");
            sb.Append("'" + fromDate.Date.ToString() + "'");
            sb.Append(", '" + toDate.Date.ToString() + "')");
            sb.Append(" where uuid = '" + uuid + "'");
            sb.Append("and Metadata/SourceName like ");
            sb.Append("'" + sensorSoruce + "'");
            return sendHTTPPost(ENDPOINT, sb.ToString());
        }

        private SMapSensorReading sendHTTPPost(string endpoint, string body)
        {
            var request = (HttpWebRequest)WebRequest.Create(endpoint);

            var data = Encoding.ASCII.GetBytes(body);

            request.Method = "POST";
            request.ContentType = "application/raw";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
                
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            var jsonObj = JsonConvert.DeserializeObject<List<SMapSensorReading>>(responseString.ToString());
            return jsonObj[0];
        }
    }
}