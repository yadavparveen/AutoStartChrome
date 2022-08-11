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
    public static class ZohoIntegration
    {
        private static string _zohoLoginUrl = "https://people.zoho.in/";

        public static void Go(UserInfo userInfo)
        {
            try
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--incognito");
                
                ChromeDriver driver = new ChromeDriver(options);
                driver.Navigate().GoToUrl(_zohoLoginUrl);

                //Login button
                var zohoLoginButtonClass = "zgh-login";
                while (!EventHelper.FindElimentByClass(driver, zohoLoginButtonClass)) { }
                driver.FindElement(By.ClassName(zohoLoginButtonClass)).Click();

                //Login Email
                var emailElementId = "login_id";
                while (!EventHelper.FindEliment(driver, emailElementId)) { }
                driver.FindElement(By.Id(emailElementId)).SendKeys(userInfo.Email);

                //Next button screen
                var nextButtonElementId = "nextbtn";
                while (!EventHelper.FindEliment(driver, nextButtonElementId)) { }
                driver.FindElement(By.Id(nextButtonElementId)).SendKeys(Keys.Enter);

                //Passowrd screen
                var pwdElementId = "password";
                Thread.Sleep(2000);
                while (!EventHelper.FindEliment(driver, pwdElementId)) { }
                driver.FindElement(By.Id(pwdElementId)).Clear();
                driver.FindElement(By.Id(pwdElementId)).SendKeys(userInfo.Password);
                driver.FindElement(By.Id(pwdElementId)).SendKeys(Keys.Enter);

                //Checkout button
                Thread.Sleep(10000);
                var checkoutElementId = "ZPD_Top_Att_Stat";
                while (!EventHelper.FindClickEliment(driver, checkoutElementId)) { }
                driver.FindElement(By.Id(checkoutElementId)).Click();

                //Checin button
                Thread.Sleep(5000);
                var checkInElementId = "ZPD_Top_Att_Stat";
                while (!EventHelper.FindClickEliment(driver, checkInElementId)) { }
                driver.FindElement(By.Id(checkInElementId)).Click();
            }
            catch (Exception ex)
            {
                //_eventLog.WriteEntry("TCube Error : " + ex.Message, EventLogEntryType.Error);
            }
        }
    }
}
