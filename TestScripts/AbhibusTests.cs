using AbhiTest.Utils;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbhiTest.PageObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;
using OpenQA.Selenium.Interactions;
using Serilog;
using System.Xml.Linq;

namespace AbhiTest.TestScripts
{

    internal class AbhibusTests : CoreCodes
    {

        List<BookBusData>? excelDataList;
        List<PassengerData>? passengerDataList;

        [Test, Category("End to End Testing")]
        public void UserBookingBusTest()
        {
            //DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            //fluentWait.Timeout = TimeSpan.FromSeconds(10);
            //fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            //fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            //fluentWait.Message = "Element not found";
            var fluentwait = Waits(driver);

            AbhibusHomePage abhibusHomePage = new AbhibusHomePage(driver);
            

            abhibusHomePage.ClickLogoCheck();

            //Thread.Sleep(2000);
            Assert.That(driver.Url.Contains("abhibus"));



           
            if (!driver.Url.Contains("https://www.abhibus.com/"))
            {
                driver.Navigate().GoToUrl("https://www.abhibus.com/");
            }
           

            BusPage busPage = new BusPage(driver);
            fluentwait.Until(d => busPage);
            
            




            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "Bus";

            excelDataList = BookBusUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {


                string? fromInput = excelData?.FromInput;
                Console.WriteLine($"From Input: {fromInput}");
                busPage.ClickFromInput(fromInput);

                string? toInput = excelData?.ToInput;
                Console.WriteLine($"To Input: {toInput}");
                busPage.ClickToInput(toInput);

                string? date = excelData?.Date;
                Console.WriteLine($"Date: {date}");
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].innerText = arguments[1];", busPage.Date, excelData?.Date);
                busPage.DateClick();
                Thread.Sleep(2000);

                var displayBusListsFilterPage = busPage.ClickSearchButton();
                Thread.Sleep(2000);
                try
                {
                    TakeScreenShot();
                    IWebElement error = driver.FindElement(By.Id("seat-filter-clear-all"));
                    string?errortext = error.Text;
                    Assert.That(driver.Url, Does.Contain("bus_search"));
                    
                    LogTestResult("Search Button Test", "Search Button Test - Success");
                    test = extent.CreateTest("Search Button Test - Passed");
                    test.Pass("Search Button Test Success");
                }
                catch(AssertionException ex)
                {
                    TakeScreenShot();
                    LogTestResult("Search Button Test", "Search Button Test - Success", ex.Message);
                    test.Fail("Search Button Test Failed");
                }

                fluentwait.Until(d => displayBusListsFilterPage);
                displayBusListsFilterPage.ClickPriceDrop();
                Thread.Sleep(3000);

                string? busType = excelData?.BusType;
                Console.WriteLine($"Bus Type: {busType}");
                displayBusListsFilterPage.ClickBusType(busType);


                string? departure = excelData?.Departure;
                Console.WriteLine($"Departure : {departure}");
                displayBusListsFilterPage.ClickDeparture(departure);
                //Thread.Sleep(3000);


                string? showseats = excelData?.ShowSeats;
                Console.WriteLine($"Show Seats : {showseats}");
                displayBusListsFilterPage.ClickShowSeats(showseats);
                Thread.Sleep(3000);


                string? select = excelData?.Select;
                Console.WriteLine($"Select : {select}");
                displayBusListsFilterPage.ClickSelect(select);
                Thread.Sleep(3000);

                string? bp = excelData?.BP;
                Console.WriteLine($"BP : {bp}");
                displayBusListsFilterPage.ClickBP(bp);
                //Thread.Sleep(3000);


                string? dp = excelData?.DP;
                Console.WriteLine($"DP : {dp}");
                displayBusListsFilterPage.ClickDP(dp);
                //Thread.Sleep(3000);


                displayBusListsFilterPage.ClickContinue();
                Thread.Sleep(3000);

                displayBusListsFilterPage.ClickClose();
                Thread.Sleep(3000);


            }

            PassengerDetailsPage passengerDetailsPage = new PassengerDetailsPage(driver);
            try
            {
                TakeScreenShot();
                IWebElement error = driver.FindElement(By.XPath("//*[@id=\"trip-details-title\"]/div/h5"));
                string?errortext = error.Text;
                Assert.That(driver.Url, Does.Contain("passengerInfo"));

                LogTestResult("PassengerInfo Test", "PassengerInfo Test - Success");
                test = extent.CreateTest("PassengerInfo Test - Passed");
                test.Pass("PassengerInfo Test Success");
            }
            catch (AssertionException ex)
            {
                TakeScreenShot();
                LogTestResult("PassengerInfo Test", "PassengerInfo Test - Success", ex.Message);
                test.Fail("PassengerInfo Test Failed");
            }

            string? sheetName2 = "PassengerDetails";
            fluentwait.Until(d => passengerDetailsPage);
            passengerDataList = PassengerUtils.ReadExcelData(excelFilePath, sheetName2);

            foreach (var excelData in passengerDataList)
            {

                string? name = excelData?.Name;
                Console.WriteLine($"Name: {name}");
                passengerDetailsPage.ClickName(name);

                string? age = excelData?.Age;
                Console.WriteLine($"Age: {age}");
                passengerDetailsPage.ClickAge(age);

                passengerDetailsPage.ClickGender();
                //Thread.Sleep(2000);

                string? contact = excelData?.Contact;
                Console.WriteLine($"Contact: {contact}");
                passengerDetailsPage.ClickContact(contact);

                string? email = excelData?.Email;
                Console.WriteLine($"Email: {email}");
                passengerDetailsPage.ClickEmail(email);



                passengerDetailsPage.ClickTravelIns();
                //Thread.Sleep(2000);

                passengerDetailsPage.ClickIcon();
                //Thread.Sleep(2000);

                string? pin = excelData?.Pin;
                Console.WriteLine($"Pin: {pin}");
                passengerDetailsPage.ClickPin(pin);
                //Thread.Sleep(5000);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                string? state = excelData?.State;
                Console.WriteLine($"State: {state}");
                //Thread.Sleep(5000);
                passengerDetailsPage.ClickState(state);
                Thread.Sleep(3000);

                passengerDetailsPage.ClickCity();
                Thread.Sleep(2000);

                //DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
                //WebElement slider = (WebElement)driver.FindElement(By.XPath("//*[@id=\"billing-add-save-button\"]/a"));
                //Actions move = new Actions(driver);
                //Action action = (Action)move.DragAndDrop(slider, 10, 20).Build();
                //action.perform();
                fluentwait.Until(d => passengerDetailsPage);
                Thread.Sleep(2000);
                passengerDetailsPage.ClickSave();
                

                
                passengerDetailsPage.ClickCTPay();
                



            }
            //WebElement slider = driver.FindElement(By.XPath("//div[@id='slider']/span"));
            //Actions move = new Actions(driver);
            //Action action = (Action)move.DragAndDrop(slider, 30, 0).build();
            //action.perform();


            //var displayBusListsFilterPage = abhibusHomePage.ClickSearchButton;

            //displayBusListsFilterPage.ClickBusTypeCheckBox();
        }
            
    }
}

    














                







            
            



        
    



