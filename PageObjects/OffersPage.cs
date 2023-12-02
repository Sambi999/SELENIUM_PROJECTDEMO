using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbhiTest.PageObjects
{
    internal class OffersPage
    {
        IWebDriver? driver;
        public OffersPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = ("(//a[text()='AbhiBus Offers'])"))]
        private IWebElement? AbhiBus { get; set; }

        [FindsBy(How = How.XPath, Using = ("(//a[text()='Payment Offers'])"))]
        private IWebElement? Payment { get; set; }

        [FindsBy(How = How.XPath, Using = ("//a[text()='Bus Partner Offer']"))]
        private IWebElement? BusPartner { get; set; }





        public void ClickOffers()
        {
            AbhiBus?.Click();
            
            //Thread.Sleep(3000);

            Payment?.Click();
            
            //Thread.Sleep(3000);

            BusPartner?.Click();
            //Thread.Sleep(3000);

        }
    }
}
