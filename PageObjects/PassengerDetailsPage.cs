using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.DOM;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AbhiTest.PageObjects
{
    internal class PassengerDetailsPage
    {
        IWebDriver? driver;
        public PassengerDetailsPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }



        //Arrange


        [FindsBy(How = How.XPath, Using = "//*[@id=\"passenger-detail-name\"]/div/div/div/div/div/input")]
        public IWebElement? Name { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"passenger-detail-age\"]/div/div/div[2]/input")]
        public IWebElement? Age { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"passenger-detail-gender\"]/div/button[2]")]
        public IWebElement? Gender { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"passenger-details-mob-input\"]/div/div/div[2]/input")]
        public IWebElement? Contact { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"passenger-details-email\"]/div/div/div[2]/input")]
        public IWebElement? Email { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"travel-insurance-content\"]/div/div/div[1]/a")]
        public IWebElement? TravelIns { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"billing-address-title\"]/div[2]")]
        public IWebElement? Icon { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"billing-add-num-input\"]/div/div/div[2]/input")]
        public IWebElement? Pin { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"billing-add-select-input\"]/div/div/div/div/div/input")]
        public IWebElement? State { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Hyderabad']")]
        public IWebElement? City { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"billing-add-save-button\"]/a")]
        public IWebElement? Save { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"root\"]/div/div/div[2]/div[3]/div[2]/button")]
        public IWebElement? CTPay { get; set; }



        //Act

        public void ClickName(string? name)
        {
            Name.SendKeys(name);
            Name.SendKeys(Keys.Enter);
            //Thread.Sleep(3000);
            Name.Click();
        }
        public void ClickAge(string? age)
        {
            Age?.SendKeys(age);
            Age?.SendKeys(Keys.Enter);
            //Thread.Sleep(3000);
            Name?.Click();
        }
        public void ClickGender()
        {
            Gender?.Click();
            //Thread.Sleep(2000);
        }
        public void ClickContact(string? contact)
        {
            Contact?.SendKeys(contact);
            Contact?.SendKeys(Keys.Enter);
            //Thread.Sleep(2000);
        }
        public void ClickEmail(string? email)
        {
            Email?.SendKeys(email);
            Email?.SendKeys(Keys.Enter);
            //Thread.Sleep(2000);
        }

        public void ClickTravelIns()
        {
            TravelIns?.Click();
            //Thread.Sleep(2000);
        }
        public void ClickIcon()
        {
            Icon?.Click();
            //Thread.Sleep(2000);
        }

        public void ClickPin(string? pin)
        {
            Pin?.SendKeys(pin);
            Pin?.SendKeys(Keys.Enter);
            //Thread.Sleep(2000);
        }
        public void ClickState(string? state)
        {
            State?.SendKeys(state);
            State?.SendKeys(Keys.Enter);
            //Thread.Sleep(2000);

        }

        public void ClickCity()
        {
            City?.Click();
            //Thread.Sleep(2000);
        }
        public void ClickSave()
        {
            Save?.Click();
            //Thread.Sleep(2000);
        }
        
        public void ClickCTPay()
        {
            CTPay?.Click();
            //Thread.Sleep(2000);
        }
    }
}
