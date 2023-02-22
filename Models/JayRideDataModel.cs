
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
 
using System.Web;
using System.Xml;
using System.Data;
using System.Collections.Generic;

namespace WebApplication6.Models
{
    public class IPDataIPSTACK
    {
        public string ip { get; set; }
        public string city { get; set; }
        public string region_code { get; set; }
        public string region_name { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public string zip { get; set; }

    }
        public class JayRideDataModel
        {
            JayRideListing jayRideListing;

        public JayRideDataModel()
        {
            jayRideListing = new JayRideListing();
            Extract();
        }

        public string GetLocation(string ipAddress)
        {
            return GetLocationIPSTACK(ipAddress); 
        }

        public void  Extract()
        {
            //if need to pass proxy using local configuration  
            var request = "https://jayridechallengeapi.azurewebsites.net/api/QuoteRequest";
 

            System.Net.WebClient webClient = new WebClient();
            webClient.Proxy = HttpWebRequest.GetSystemWebProxy();
            webClient.Proxy.Credentials = CredentialCache.DefaultCredentials;

            Stream strm = webClient.OpenRead(request);
            StreamReader sr = new StreamReader(strm);
            string result = sr.ReadToEnd();
            result = TryFormatJson(result);
            jayRideListing = JsonConvert.DeserializeObject<JayRideListing>(result);
            Console.WriteLine(result);
            strm.Close();

            string iPAdresss = "49.199.8.210";
            string city = GetLocationIPSTACK(iPAdresss);
             
    

      
        }


        public List<Listing> FilterListings(int numPassengers)
        {

            return jayRideListing.CalcTotalPrices(numPassengers);

        }

        private static string GetLocationIPSTACK(string iPAdresss)
        {
            try
            {
                IPDataIPSTACK ipInfo = new IPDataIPSTACK();
                string strResponse = new WebClient().DownloadString("http://api.ipstack.com/" + iPAdresss + "?access_key=affe0189487d942ac4ee516897fb03d1");


                if (strResponse == null || strResponse == "") return "";

                ipInfo = JsonConvert.DeserializeObject<IPDataIPSTACK>(strResponse);
                if (ipInfo == null || ipInfo.ip == null || ipInfo.ip == "") return "";
                else return ipInfo.city;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private static string TryFormatJson(string str)
        {
            try
            {

                object parsedJson = JsonConvert.DeserializeObject(str);
                return JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
            }
            catch
            {
                // can't parse JSON, return the original string
                return str;
            }
        }



    }
}