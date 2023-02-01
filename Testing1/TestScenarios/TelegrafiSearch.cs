
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing1.TestScenarios
{
    public class TelegrafiSearch
    {
        public object GenericHelper { get; private set; }

        public TelegrafiSearch()
        {
        }
        [SetUp]
        public void SetupBeforeEachTest()
        {
            Action.InitializeDriver("Config.YoutubeUrl"); //TelegrafiUrl
        }

        [TearDown]

        public void AfterEachTest()
        {
            if (TestContext.CurrentContext.Result.Outcome != NUnit.Framework.Interfaces.ResultState.Success)
            {
                Action.MakeScreenshot(TestContext.CurrentContext.Test.Name);
            }

            Driver.driver.Quit();
        }
        [Test]

        public void SearchFiltringSport()
        {
            { 
                var menu = Driver.driver.FindElement(By.XPath("/html/body/div[4]/div/button"));
                menu.Click();

                var sporti = Driver.driver.FindElement(By.ClassName("sport"));
                sporti.Click();

                var sportluf = Driver.driver.FindElement(By.XPath("/html/body/div[3]/ul/li[3]/ul/li[5]/a"));
                sportluf.Click();

              
                Assert.IsTrue(Driver.driver.FindElement(By.ClassName("sportluf")).Displayed, "Sportluf page not displayed");
            }


        }
        [Test]

        public void ButtonEkonomia()
        {
            var ekonomia = Driver.driver.FindElement(By.XPath("/html/body/div[4]/ul/li[3]/a"));
            ekonomia.Click();
            var search = Driver.driver.FindElement(By.XPath("/html/body/div[6]/div/form/input"));
            search.Click();

            Assert.AreEqual(ekonomia , search);
            //kerkimi ne gjuhen shqipe nuk mundesohet
        }
        [Test]
        public void ButtonJobs()
        {
            var menu = Driver.driver.FindElement(By.ClassName("menu-toggle"));
            menu.Click();

            var jobsLi = Driver.driver.FindElement(By.Id("menu-item-18"));
            jobsLi.FindElement(By.TagName("a")).Click();
            var jobNameElement = Driver.driver.FindElement(By.ClassName("job-name"));
            jobNameElement.Click();
            System.Threading.Thread.Sleep(5000);

            // Add the following lines
            var expectedJobName = "Job Name";
            var actualJobName = jobNameElement.Text;
            Assert.AreEqual(expectedJobName, actualJobName,
                $"Expected job name: {expectedJobName}, but got: {actualJobName}");
        }

        [Test]
        public void ButtonMarketing()
        {
            // var menu = Driver.driver.FindElement(By.ClassName("menu-toggle"));
            // menu.Click();
            // Driver.driver.FindElement(By.XPath("/html/body/div[6]/div/ul[3]/li[2]/a")).Click();
            // System.Threading.Thread.Sleep(5000);
            var menu = Driver.driver.FindElement(By.ClassName("menu-toggle"));
            menu.Click();

            var marketingButton = Driver.driver.FindElement(By.XPath("/html/body/div[6]/div/ul[3]/li[2]/a"));
            marketingButton.Click();

            var wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(10));
            var expectedUrl = "https://example.com/marketing";
            wait.Until(d => d.Url.Equals(expectedUrl));

            var actualUrl = Driver.driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl, "The expected URLis loaded");

        }

        [Test]

        public void ButtonInstagram()
        {

            var instagram = Driver.driver.FindElement(By.ClassName("ins-social"));
            instagram.Click();

            var facebook = Driver.driver.FindElement(By.ClassName("fb-social"));
            facebook.Click();
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual(instagram, facebook);
        }

        [Test]
        public void ButtonAppInstall()
        {
            var appstore = Driver.driver.FindElement(By.XPath("/html/body/div[18]/div[2]/div/div[1]/a"));
            appstore.Click();
            System.Threading.Thread.Sleep(5000);

            // Add an assertion to check if the click was successful
            Assert.IsTrue(appstore.Enabled, "The appstore button is not enabled");
        }

        [Test]
        public void ButtonAppInstallPlaystore()
        {
            var googleplay = Driver.driver.FindElement(By.XPath("/html/body/div[18]/div[2]/div/div[2]/a"));
            googleplay.Click();
            Driver.driver.FindElement(By.XPath("/html/body/c-wiz[2]/div/div/div[1]/div[1]/div/div/div[1]/div[1]/div/c-wiz/div/div/div/div/button/div[3]")).Click();
            System.Threading.Thread.Sleep(5000);

            var installButton = Driver.driver.FindElement(By.XPath("//button[text()='Install']"));
            Assert.IsTrue(installButton.Displayed, "Install button is  enable");
        }

        //class="VfPpkd-RLmnJb"

        [Test]
        public void LocationFiltring()
        {
            var menu = Driver.driver.FindElement(By.ClassName("menu-toggle"));
            menu.Click();
            var jobsLi = Driver.driver.FindElement(By.Id("menu-item-18"));
            jobsLi.FindElement(By.TagName("a")).Click();
            Driver.driver.FindElement(By.Id("vendi")).Click();
            Driver.driver.FindElement(By.XPath("/html/body/section/div[1]/div[3]/form/div[2]/div[3]/select/optgroup[1]/option[4]")).Click();
            Driver.driver.FindElement(By.ClassName("searchButton")).Click();

            IReadOnlyCollection<IWebElement> locations = Driver.driver.FindElements(By.ClassName("puna-location"));

            foreach(IWebElement location in locations)
            {
                Assert.AreEqual(location.Text, "Gjilan");

            }
            var jobCounter = Driver.driver.FindElement(By.XPath("/html/body/section/div[2]/div/div[1]/div/div[1]/div/span/strong[1]"));
            var jobInfo = Driver.driver.FindElements(By.ClassName("job-info"));

            Assert.AreEqual(jobCounter.Text, jobInfo.Count.ToString());
        
        }

    }
}

