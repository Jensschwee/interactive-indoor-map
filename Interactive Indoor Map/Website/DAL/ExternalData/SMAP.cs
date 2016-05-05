using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Website.Logic.BO.Utility;
using Website.Logic.Helpers;

namespace Website.DAL.ExternalData
{
    public class SMAP
    {
        private DateConverter dateConverter;
        public SMAP()
        {
            dateConverter = new DateConverter();
        }

        private static readonly string ENDPOINT = @"http://10.123.3.12:8079/api/query";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public double GetCurrentSensorValue(string uuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select data before now ");
            sb.Append(" where uuid = ");
            sb.Append("'" + uuid + "'");
            return sendHTTPPost(ENDPOINT, sb.ToString()).Readings[0][1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uuid"></param>
        /// <param name="limit">
        /// The number of reading returned
        /// </param>
        /// <returns></returns>
        public double GetCurrentHourlyUse(string uuid, int limit = 2)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select data before now ");
            sb.Append("limit " + limit);
            sb.Append(" where uuid = ");
            sb.Append("'" + uuid + "'");
            SMapSensorReading reading = sendHTTPPost(ENDPOINT, sb.ToString());

            double reading1 = reading.Readings[0][1];
            double reading2 = reading.Readings[1][1];

            TimeSpan timeBetween = dateConverter.ConvertDate((long)reading.Readings[1][0]) - dateConverter.ConvertDate((long)reading.Readings[0][0]);

            return ((reading2 - reading1) / timeBetween.TotalMinutes) * 60;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoints"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public List<SMapSensorReading> GetHistoricSensorValue(IEnumerable<KeyValuePair<string, SensorType>> endpoints, DateTime fromDate, DateTime toDate)
        {
            if (endpoints.Any())
            {
                toDate = dateConverter.ConvertToLaDate(toDate);
                fromDate = dateConverter.ConvertToLaDate(fromDate);

                StringBuilder sb = new StringBuilder();
                sb.Append("select data in (");
                sb.Append("'" + fromDate.Month + "/" + fromDate.Day + "/" + fromDate.Year + " " + fromDate.ToShortTimeString() +
                     "'");
                sb.Append(",'" + toDate.Month + "/" + toDate.Day + "/" + toDate.Year + " " + toDate.ToShortTimeString() + "')");
                sb.Append("where ");
                foreach (var uuid in endpoints)
                {
                    sb.Append("uuid = ");
                    sb.Append("'" + uuid.Key + "' or ");
                }
                sb.Remove(sb.Length, 3);
                return sendHTTPPostMultipolEndpoints(ENDPOINT, sb.ToString());
            }
            return null;
        }

        public SMapSensorReading GetHistoricSensorValue(string endpoints, DateTime fromDate, DateTime toDate)
        {

            fromDate = dateConverter.ConvertToLaDate(fromDate);
            toDate = dateConverter.ConvertToLaDate(toDate);

            StringBuilder sb = new StringBuilder();
            sb.Append("select data in (");
            sb.Append("'" + fromDate.Month + "/" + fromDate.Day + "/" + fromDate.Year + " " + fromDate.ToShortTimeString() +
                     "'");
            sb.Append(",'" + toDate.Month + "/" + toDate.Day + "/" + toDate.Year + " " + toDate.ToShortTimeString() + "')");
            sb.Append("where ");
            sb.Append("uuid = ");
            sb.Append("'" + endpoints + "'");
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

        private List<SMapSensorReading> sendHTTPPostMultipolEndpoints(string endpoint, string body)
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
            return jsonObj;
        }
    }
}