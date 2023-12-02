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
    internal class LoginTest : CoreCodes
    {
        [Test, Category("Smoke Testing")]

        public void UserBookingLoginTest()
        {
            var fluentwait = Waits(driver);
            string? currDir = Directory.GetParent(@"../../../").FullName;
            string? logfilePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy.mm.dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            LoginPage loginpage = new LoginPage(driver);
            
            Thread.Sleep(4000);
            fluentwait.Until(d => loginpage);
            loginpage.ClickLogin();
            try
            {

                IWebElement error = driver.FindElement(By.XPath("//span[text()='Sorry! Referral code is incorrect']"));
                string? errortext = error.Text;
                TakeScreenShot();
                Assert.That(errortext, Does.Contain("Sorry! Referral code is incorrect"));

                LogTestResult("Login Test", "Login Test - Success");
                test = extent.CreateTest("Login Test - Passed");
                test.Pass("Login Test Success");
            }
            catch (AssertionException ex)
            {
                TakeScreenShot();
                LogTestResult("Login Test", "Login Test - Success", ex.Message);
                test.Fail("Offers Test Failed");
            }
        }


    }
}
