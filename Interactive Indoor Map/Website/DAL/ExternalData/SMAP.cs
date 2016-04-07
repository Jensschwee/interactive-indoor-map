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

        public double GetCurrentSensorValue(string uuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select data before now where uuid = ");
            sb.Append("'" + uuid + "'");
            sb.Append("and Metadata/SourceName like 'OpcUa'");
            return sendHTTPPost(ENDPOINT, sb.ToString()).Readings[0][1];
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