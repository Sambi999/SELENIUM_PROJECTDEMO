using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbhiTest.PageObjects
{
    internal class BusPage
    {
        IWebDriver? driver;
        public BusPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange


        [FindsBy(How = How.XPath, Using = ("//input[@placeholder='From Station']"))]
        private IWebElement? FromInput { get; set; }

        [FindsBy(How = How.XPath, Using = ("//input[@placeholder='To Station']"))]
        private IWebElement? ToInput { get; set; }

        [FindsBy(How = How.XPath, Using = ("//*[@id=\"jaurney-date\"]/div/div/div/div[3]/a[2]"))]
        public IWebElement? Date { get; set; }

        [FindsBy(How = How.Id, Using = ("search-button"))]
        private IWebElement? SearchButton { get; set; }



        //Act

        public void ClickFromInput(string? fromStation)
        {
            FromInput?.Click();
            //Thread.Sleep(2000);
            FromInput?.SendKeys(fromStation);
            FromInput?.SendKeys(Keys.Enter);
        }

        public void ClickToInput(string? toStation)
        {
            ToInput?.Click();
            //Thread.Sleep(2000);
            ToInput?.SendKeys(toStation);
            ToInput?.SendKeys(Keys.Enter);
        }

        public void DateClick()
        {
            Date?.Click();
        }


        public DisplayBusListsFilterPage ClickSearchButton()
        {
            SearchButton?.Click();
            return new DisplayBusListsFilterPage(driver);
        }

       
    }
}

