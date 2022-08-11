using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCubeExtension_Console.Helpers
{
    class EventHelper
    {
        public static bool FindEliment(ChromeDriver driver, string elementId)
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

        public static bool FindElimentByClass(ChromeDriver driver, string className)
        {
            try
            {
                driver.FindElement(By.ClassName(className));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool FindClickEliment(ChromeDriver driver, string elementId)
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
    }
}
