using Newtonsoft.Json;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DemoHTTP.HTTPRequests
{
    internal class Engine
    {
        public static void SendRegisterRequest(string username, string password, string email, string sessionToken)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string>
    {
        { "requestSession", sessionToken },
        { "action", "exampleHTTPRegister" },
        { "username", username },
        { "password", password },
        { "email", email }
    };

            var content = new FormUrlEncodedContent(values);
            var response = client.PostAsync("https://v-devs.online/demoHTTPLogin/api/v1/", content).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            dynamic responseJson = JsonConvert.DeserializeObject(responseString);
            Console.WriteLine(responseJson);
        }
        public static void SendLoginRequest(string username, string password, string sessionToken)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string>
    {
        { "requestSession", sessionToken },
        { "action", "exampleHTTPLogin" },
        { "username", username },
        { "password", password }
    };

            var content = new FormUrlEncodedContent(values);
            var response = client.PostAsync("https://v-devs.online/demoHTTPLogin/api/v1/", content).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            dynamic responseJson = JsonConvert.DeserializeObject(responseString);
            Console.WriteLine(responseJson);
        }
        public static void SendExampleHTTPRequest()
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string>
    {
        { "action", "exampleHTTPRequest" }
    };

            var content = new FormUrlEncodedContent(values);
            var response = client.PostAsync("https://v-devs.online/demoHTTPLogin/api/v1/", content).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;

            var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseString);
            if (json != null)
            {
                foreach (var item in json)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Deserialization of response failed.");
            }

        }

    }
}
