using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbhiTest.PageObjects
{
    internal class TrackTicketPage
    {
        IWebDriver? driver;
        public TrackTicketPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ("//input[@placeholder='Please enter the booking ID']"))]
        private IWebElement? IdTest { get; set; }

        [FindsBy(How = How.XPath, Using = ("//input[contains(@class,'mobileNo-input')]"))]
        private IWebElement? MobNum { get; set; }

        [FindsBy(How = How.Id, Using = ("pre-cancellation-retrive"))]
        private IWebElement? TDetails { get; set; }

        public void ClickTrackTicket()
        {
//            IdTest?.Click();
            IdTest?.SendKeys("949409jw");
            IdTest?.SendKeys(Keys.Enter);
            //Thread.Sleep(3000);

            MobNum?.Click();
            MobNum?.SendKeys("7953957345");
            //Thread.Sleep(3000);

            TDetails?.Click();
            Thread.Sleep(3000);

        }
    }
}
