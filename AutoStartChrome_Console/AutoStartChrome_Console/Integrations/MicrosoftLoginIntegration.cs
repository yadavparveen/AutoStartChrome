using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCubeExtension_Console.Dto;
using TCubeExtension_Console.Helpers;

namespace TCubeExtension_Console
{
    public static class MicrosoftLoginIntegration
    {
        private static string _microsoftLoginUrl = "tcube.technossus.com";

        public static void Go(UserInfo userInfo)
        {
            try
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--incognito");

                ChromeDriver driver = new ChromeDriver(options);
                driver.Navigate().GoToUrl(_microsoftLoginUrl);

                //email screen
                var emailElementId = "i0116";
                while (!EventHelper.FindEliment(driver, emailElementId)) { }
                driver.FindElement(By.Id(emailElementId)).Clear();
                driver.FindElement(By.Id(emailElementId)).SendKeys(userInfo.Email);
                driver.FindElement(By.Id(emailElementId)).SendKeys(Keys.Enter);

                //Passowrd screen
                var pwdElementId = "i0118";
                while (!EventHelper.FindEliment(driver, pwdElementId)) { }
                driver.FindElement(By.Id(pwdElementId)).Clear();
                driver.FindElement(By.Id(pwdElementId)).SendKeys(userInfo.Password);
                driver.FindElement(By.Id(pwdElementId)).SendKeys(Keys.Enter);

                //Enter- Login button
                var loginElementId = "idSIButton9";
                while (!EventHelper.FindClickEliment(driver, loginElementId)) { }
                driver.FindElement(By.Id(loginElementId)).Click();

                //Ask me next time screen
                while (!EventHelper.FindClickEliment(driver, loginElementId)) { }
                driver.FindElement(By.Id(loginElementId)).Click();
            }
            catch (Exception ex)
            {
                //_eventLog.WriteEntry("TCube Error : " + ex.Message, EventLogEntryType.Error);
            }
        }
    }
}
