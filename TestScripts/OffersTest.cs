using AbhiTest.PageObjects;
using AbhiTest.Utils;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbhiTest.TestScripts
{
    [TestFixture]
    internal class OffersTest : CoreCodes
    {
        [Test, Category("Smoke Testing")]
        public void UserBookingOffersTest()
        {
            var fluentwait = Waits(driver);
            string? currDir = Directory.GetParent(@"../../../").FullName;
            string? logfilePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy.mm.dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            OffersPage offerspage = new OffersPage(driver);
            driver.Navigate().GoToUrl("https://www.abhibus.com/bus-ticket-offers");
            Thread.Sleep(4000);
            fluentwait.Until(d => offerspage);
            offerspage.ClickOffers();
            try
            {

                IWebElement error = driver.FindElement(By.XPath("//h1[text()='Bus Booking Offers']"));
                string? errortext = error.Text;
                TakeScreenShot();
                Assert.That(errortext, Does.Contain("Bus Booking Offers"));

                LogTestResult("Offers Test", "Offers Test - Success");
                test = extent.CreateTest("Offers Test - Passed");
                test.Pass("Offers Test Success");
            }
            catch (AssertionException ex)
            {
                TakeScreenShot();
                LogTestResult("Offers Test", "Offers Test - Success", ex.Message);
                test.Fail("Offers Test Failed");
            }
        }
    }
}
