using AbhiTest.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AbhiTest.PageObjects
{
    internal class AbhibusHomePage
    {
        IWebDriver? driver;
        public AbhibusHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange

        

        [FindsBy(How = How.XPath, Using = ("//*[@id=\"abhibus-logo\"]"))]
        private IWebElement? LogoCheck { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"bus-link\"]")]
        public IWebElement? BusesOption { get; set; }

        //Act

        /*
        public void ClickLogin()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Until(d => LogoCheck.Displayed);
            Login?.Click();
        }
        */

        public void ClickLogoCheck()
        {
            LogoCheck?.Click();
        }
        public BusPage ClickBusesOption()
        {
            BusesOption?.Click();
            return new BusPage(driver);
        }

       
    }
}
