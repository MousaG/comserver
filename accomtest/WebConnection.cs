using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accomtest
{
  public  class WebConnection
    {
        public static string remoteAddr;
        public static string getWebCleint(string funcName, object ex)
        {
            ExtendedWebClient client = new ExtendedWebClient();
            client.Headers.Add("Content-Type", "application/json; charset=utf-8");
            client.Encoding = System.Text.Encoding.UTF8;
            string json = JsonConvert.SerializeObject(
                      ex,
                      new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() });

            
            var result = client.UploadString(remoteAddr+ funcName, json);

            if (client.StatusCode.ToString().ToLower() != "0")
            {
                throw new Exception(result);
            }
            return result;


        }

    }
}
