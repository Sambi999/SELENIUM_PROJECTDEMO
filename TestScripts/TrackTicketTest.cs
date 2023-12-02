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
    internal class TrackTicketTest : CoreCodes
    {
        [Test, Category("Smoke Testing")]
        public void UserBookingBusTest()
        {
            var fluentwait = Waits(driver);
            string? currDir = Directory.GetParent(@"../../../").FullName;
            string? logfilePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy.mm.dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            TrackTicketPage trackticketpage = new TrackTicketPage(driver);
            driver.Navigate().GoToUrl("https://www.abhibus.com/track");
            Thread.Sleep(4000);
            fluentwait.Until(d => trackticketpage);
            trackticketpage.ClickTrackTicket();
            try
            {
                
                IWebElement error = driver.FindElement(By.XPath("//div[contains(@class,'alertbox')]"));
                string? errortext = error.Text;
                TakeScreenShot();
                Assert.That(errortext, Does.Contain("Please enter valid"));

                LogTestResult("Track Ticket Test", "Track Ticket Test - Success");
                test = extent.CreateTest("Track Ticket Test - Passed");
                test.Pass("Track Ticket Test Success");
            }
            catch (AssertionException ex)
            {
                TakeScreenShot();
                LogTestResult("Track Ticket Test", "Track Ticket Test - Success", ex.Message);
                test.Fail("Track Ticket Test Failed");
            }
        }
    }
}

