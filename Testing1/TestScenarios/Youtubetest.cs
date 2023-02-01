using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing1.TestScenarios
{
    public class Youtubetest
    {
        public Youtubetest()
        {
        }
        [SetUp]
        public void SetupBeforeEachTest()
        {
            Action.InitializeDriver("Config.YoutubeUrl");
        }

        [TearDown]

        public void AfterEachTest()
        {
            if (TestContext.CurrentContext.Result.Outcome != NUnit.Framework.Interfaces.ResultState.Success)
            {
                Action.MakeScreenshot(TestContext.CurrentContext.Test.Name);
            }

          //  Driver.driver.Quit();
        }

        
        [Test]

        public void YoutubeHistory()
        {
            Driver.driver.Manage().Window.Maximize();
            var ythistory = Driver.driver.FindElement(By.XPath("/html/body/ytd-app/div[1]/tp-yt-app-drawer/div[2]/div/div[2]/div[2]/ytd-guide-renderer/div[1]/ytd-guide-section-renderer[2]/div/ytd-guide-entry-renderer[2]/a"));
            ythistory.Click();
            var historyButton = Driver.driver.FindElement(By.XPath("/html/body/ytd-app/div[1]/ytd-page-manager/ytd-browse[2]/ytd-two-column-browse-results-renderer/div[2]/ytd-browse-feed-actions-renderer/div/ytd-button-renderer[1]/yt-button-shape/button"));
            historyButton.Click();

            Assert.IsTrue(historyButton.Displayed, "History button was not displayed"); // NUK KLIKOHET PATH NESE  FUSIM PATHIN NUK BON HISTORIJA.
        }


[Test]
    public void YoutubeTV()
    {
        Driver.driver.Manage().Window.Maximize();

        var ytTv = Driver.driver.FindElement(By.XPath("/html/body/ytd-app/div[1]/tp-yt-app-drawer/div[2]/div/div[2]/div[2]/ytd-guide-renderer/div[1]/ytd-guide-section-renderer[5]/div/ytd-guide-entry-renderer[3]/a/tp-yt-paper-item/yt-formatted-string"));
        ytTv.Click();

        // Add the assertion
        bool isTrue = ytTv.Displayed;
        Assert.IsTrue(isTrue, "Element is true.");
    }




}
}
