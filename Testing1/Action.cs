using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing1
{
    public static class Action
    {
        public static void InitializeDriver(string url = "")
        {
            if (string.IsNullOrEmpty(url)) { url = Config.GjirafaUrl; } //TelegrafiUrl RiinvestUrl // GjirafaUrl
            
           

            Driver.driver = new ChromeDriver();
            Driver.driver.Navigate().GoToUrl("https://gjirafa.com");
            Driver.driver.Manage().Window.Maximize();
        }

        public static void MakeScreenshot(string filename)
        {
          string screenshotDirectory = Config.ScreenshotDir ;
            Screenshot browserScreenshot = ((ITakesScreenshot)Driver.driver).GetScreenshot();
            browserScreenshot.SaveAsFile(screenshotDirectory + @"\" +filename + ".png", ScreenshotImageFormat.Png);


        }
    }
}
