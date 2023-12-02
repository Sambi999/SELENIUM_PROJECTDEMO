using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbhiTest.PageObjects
{
    internal class LoginPage
    {
        IWebDriver? driver;
        public LoginPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = ("//a[@id='login-link']"))]
        private IWebElement? SignUp { get; set; }

        [FindsBy(How = How.XPath, Using = ("//input[@class='true mobileNo-input']"))]
        private IWebElement? Num { get; set; }

        [FindsBy(How = How.XPath, Using = ("//input[@placeholder='Enter Referal Code if Available']"))]
        private IWebElement? Referral { get; set; }

        [FindsBy(How = How.XPath, Using = ("//div[@id='login-validation']"))]
        private IWebElement? Loggin { get; set; }

        public void ClickLogin()
        {
            SignUp?.Click();

            //Thread.Sleep(3000);

            Num?.Click();
            Num?.SendKeys("8765490340");
            //Thread.Sleep(3000);

            Referral?.Click();
            Referral?.SendKeys("AJSHSDHSKD");
            Thread.Sleep(3000);

            Loggin?.Click();
            Thread.Sleep(2000);
            
        }
    }
}
