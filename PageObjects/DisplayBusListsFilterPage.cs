using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbhiTest.PageObjects
{
    internal class DisplayBusListsFilterPage
    {
        IWebDriver? driver;
        public DisplayBusListsFilterPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange

        [FindsBy(How = How.Id, Using = "price-drop")]
        private IWebElement? PriceDrop { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"seat-filter-bus-type\"]/a[1]/span[2]")]
        public IWebElement? BusType { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"seat-filter-departure-list\"]/a[3]")]
        public IWebElement? Departure { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'fare-info col')]//following::button)[1]")]
        public IWebElement? ShowSeats { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"seat-layout-details\"]/tbody/tr[1]/td[1]/div/button")]
        public IWebElement? Select { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"place-container\"]/div[1]/input")]
        public IWebElement? BP { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"place-container\"]/div[2]/input")]
        public IWebElement? DP { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"seating-container\"]/div[3]/div[2]/div/div/button")]
        public IWebElement? Continue { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"login-heading\"]/div[1]/span")]
        public IWebElement? Close { get; set; }


        public void ClickPriceDrop()
        {

            PriceDrop?.Click();
            Console.WriteLine("PD clicked");
            //Thread.Sleep(3000);

        }

        public void ClickBusType(string? bustype)
        {
            

            BusType?.Click();

        }

        public void ClickDeparture(string? departure)
        {
            Departure?.Click();

        }

        public void ClickShowSeats(string? seats)
        {
            
            ShowSeats?.Click();
        }

        public void ClickSelect(string? select)
        {
            
            Select?.Click();
        }
        public void ClickBP(string? bp)
        {
            
            BP?.Click();
        }
        public void ClickDP(string? dp)
        {
            
            DP?.Click();
        }
        public void ClickContinue()
        {
            
            Continue?.Click();
        }

       

        public PassengerDetailsPage ClickClose()
        {
            Close?.Click();
            return new PassengerDetailsPage(driver);
        }





    }
}
