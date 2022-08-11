using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;
using TCubeExtension_Console.Dto;

namespace TCubeExtension_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInfo = LoadJson();
            

            //NOTE: Make sure Two factor authentication is disabled before u run this utilization 

            //Enable it for Microsoft Login
            //MicrosoftLoginIntegration.Go(userInfo);

            //Enable it for Zoho Login
            ZohoIntegration.Go(userInfo);
        }

        public static UserInfo LoadJson()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var userInfoFilePath = Path.Combine(baseDirectory, "userInfo.json");

            using (StreamReader r = new StreamReader(userInfoFilePath))
            {
                string json = r.ReadToEnd();
                var user = JsonConvert.DeserializeObject<UserInfo>(json);

                return user;
            }
        }
    }
}
