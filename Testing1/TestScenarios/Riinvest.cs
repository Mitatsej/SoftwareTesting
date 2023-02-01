using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing1.TestScenarios
{
    public class Riinvest
    {
        public Riinvest()
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
        // Testimi i profilit BA Business Menagment 
        public void RiinvestProfile()
        {
            Driver.driver.Manage().Window.Maximize();
            var studyProgram = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/header/div[1]/div[3]/div/nav[1]/ul/li[2]/a"));
            studyProgram.Click();
            var businessMenagment = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/header/div[1]/div[3]/div/nav[1]/ul/li[2]/div/div/div[1]/ul/li[1]/ul/li[1]/a"));
            businessMenagment.Click();

            var profileBusiness = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/main/div/section/div/div/div[3]/div/div/div/ul/li[1]/div/p/a"));
            profileBusiness.Click();

            string expectedText = "BA Business Menagment";
            string actualText = profileBusiness.Text;
            Assert.AreEqual(expectedText, actualText, "The text of the profileBusiness element is  expected");
        }

        [Test]
        // Testimi i profilit Ma Menagment
        public void RiinvestProfileMa()
        {
            Driver.driver.Manage().Window.Maximize();
            var studyProgram = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/header/div[1]/div[3]/div/nav[1]/ul/li[2]/a"));
            studyProgram.Click();


            var maMenagment = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/header/div[1]/div[3]/div/nav[1]/ul/li[2]/div/div/div[1]/ul/li[2]/ul/li[1]/a"));
            maMenagment.Click();
            string expectedUrl = "https://example.com/ma-management";

            maMenagment.Click();

            string actualUrl = Driver.driver.Url;

            Assert.AreEqual(expectedUrl, actualUrl, "MA Management page URL is correct");
        }

    [Test]

        public void RiinvestEmail()
        {
            // Testimi i kontaktimi prej email
            Driver.driver.Manage().Window.Maximize();
            var sendEmail = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[3]/footer/div/div/div[1]/section[1]/div[1]/ul/li[3]/div/a"));
            sendEmail.Click();
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/header/div[1]/div[1]/div/div[1]/nav[1]/ul/li[2]/a")).Click();
            var confirmationMessage = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/header/div[1]/div[1]/div/div[1]/nav[1]/ul/li[2]/a")).Text;

            // Add assertion to verify if the email was sent successfully
            Assert.AreEqual("Email sent successfully", confirmationMessage);
        }
    }
}
