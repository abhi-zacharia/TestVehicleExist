using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleExistsTest
{    
    public class HomePage
    {
        private readonly IWebDriver _webDriver;

        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.Id,Using = "vehicleReg")]
        private IWebElement regNumberTextBox;

        [FindsBy(How =How.Name, Using = "btnfind")]
        private IWebElement findVehicleButton;

        [FindsBy(How =How.ClassName, Using="result")]
        private IWebElement result;

        public void GoToHomePage()
        {
            _webDriver.Navigate().GoToUrl("https://covercheck.vwfsinsuranceportal.co.uk/");
        }

        public void EnterRegNumber(string regNumber)
        {
            regNumberTextBox.SendKeys(regNumber);
        }

        public void FindVehicle()
        {
            findVehicleButton.Click();
        }

        public bool VehicleExists(string regNumber)
        {            
            return result.Text == $"Result for : {regNumber}";
        }
    }
}
