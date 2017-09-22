using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace convert_fiatToCrypto_viceVersa_api
{
    
    public class Api
    {
        //To Get value of Currency in BTC
        /* This function is used to send http request to API*/
        public string CallApi(string url, string _cur) {

            string cur = _cur;
            string Result = string.Empty;
           
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(url);
            Request.KeepAlive = false;
            Request.Method = "GET"; // Would be POST for some methods 
            
            //For SSL/TLS exception
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)Request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    Result = reader.ReadToEnd();
                }

                //To Get Result in Hex Value 
                var HexValue = GetJsonObj(Result);

                //To Convert Hex To Decimal
                //var DecValue = HexToDecString(HexValue);
                return Result;

            }

            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    Console.WriteLine(errorText);
                }
                throw;
            }            
        }

        //For Value Converstion to BTC
        /* This function is used to send http request to API*/
        public string CallApi(string url)
        {

            
            string Result = string.Empty;

            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(url);
            Request.KeepAlive = false;
            Request.Method = "GET"; // Would be POST for some methods 

            //For SSL/TLS exception
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)Request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    Result = reader.ReadToEnd();
                }

                return Result;

            }

            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    Console.WriteLine(errorText);
                }
                throw ex;

            }
        }

        public JObject GetJsonObj(string result)
        {
            var JObj = JObject.Parse(result);
            return JObj;
        }

       

       
    }
}
