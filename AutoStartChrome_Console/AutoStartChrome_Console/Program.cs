using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using TCubeExtension_Console.Dto;

namespace TCubeExtension_Console
{
    class Program
    {
        private static readonly string _url = "<your URL here>";

        static void Main(string[] args)
        {
            var userInfo = LoadJson();
            OpenChromewithWindowsAuth(userInfo);
        }

        private static void OpenChromewithWindowsAuth(UserInfo userInfo)
        {
            try
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--incognito");
                //options.BinaryLocation = @"C:\Users\parveen.kumar\AppData\Local\Google\Chrome\Application\chrome.exe";

                ChromeDriver driver = new ChromeDriver(options);
                driver.Navigate().GoToUrl(_url);

                //email screen
                var emailElementId = "i0116";
                while (!FindEliment(driver, emailElementId)) { }
                driver.FindElement(By.Id(emailElementId)).Clear();
                driver.FindElement(By.Id(emailElementId)).SendKeys(userInfo.Email);
                driver.FindElement(By.Id(emailElementId)).SendKeys(Keys.Enter);

                //Passowrd screen
                var pwdElementId = "i0118";
                while (!FindEliment(driver, pwdElementId)) { }
                driver.FindElement(By.Id(pwdElementId)).Clear();
                driver.FindElement(By.Id(pwdElementId)).SendKeys(userInfo.Password);
                driver.FindElement(By.Id(pwdElementId)).SendKeys(Keys.Enter);

                //Enter- Login button
                var loginElementId = "idSIButton9";
                while (!FindClickEliment(driver, loginElementId)) { }
                driver.FindElement(By.Id(loginElementId)).Click();

                //Ask me next time screen
                while (!FindClickEliment(driver, loginElementId)) { }
                driver.FindElement(By.Id(loginElementId)).Click();
            }
            catch (Exception ex)
            {
                //_eventLog.WriteEntry("TCube Error : " + ex.Message, EventLogEntryType.Error);
            }
        }

        private static bool FindEliment(ChromeDriver driver, string elementId)
        {
            try
            {
                driver.FindElement(By.Id(elementId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool FindClickEliment(ChromeDriver driver, string elementId)
        {
            try
            {
                driver.FindElement(By.Id(elementId));
                driver.FindElement(By.Id(elementId)).Click();
                return true;
            }
            catch
            {
                return false;
            }
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
