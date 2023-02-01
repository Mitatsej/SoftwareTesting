using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing1.TestScenarios
{
    public class Gjirafatest
    {
        public Gjirafatest()
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
        }

        [Test]

        public void GjirafaSearchBar()
        {
            Driver.driver.Manage().Window.Maximize();

            Driver.driver.FindElement(By.Id("gjirafaSearch")).SendKeys("Merr jep");

            var buttonId = Driver.driver.FindElement(By.Id("searchvalue"));
            buttonId.Click();

            var result = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[3]/section/div[1]/div/div[1]/div[4]/div/div[1]/div[1]/h3/a"));
            result.Click();
            Assert.AreEqual("Expected result", result);


        } 
        [Test]

        public void GjirafaRrethnesh()
        {
            Driver.driver.Manage().Window.Maximize();

            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[2]/div/div[2]/div/a[1]")).Click();



            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[3]/a[2]")).Click();
            Assert.IsTrue(Driver.driver.Title.Contains("Expected title"));


        }

        [Test]

        public void GjirafaTravel()
        {
            Driver.driver.Manage().Window.Maximize();


            Driver.driver.FindElement(By.XPath("/html/body/div[1]/main/div/div/div[3]/ul/li[4]/a")).Click();
            var actualTitle = Driver.driver.Title;
            var expectedTitle = "Expected Page Title";
            Assert.AreEqual(expectedTitle, actualTitle, $"Expected title to be '{expectedTitle}' but was '{actualTitle}'");

        }
    }

}
