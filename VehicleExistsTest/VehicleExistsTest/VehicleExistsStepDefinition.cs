using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace VehicleExistsTest
{
    [Binding]
    public sealed class VehicleExistsStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;
        IWebDriver _driver;
        HomePage _page;
        string _regNumber;

        public VehicleExistsStepDefinition(ScenarioContext injectedContext)
        {
            context = injectedContext;
            _driver =  new ChromeDriver();
            _page = new HomePage(_driver);
        }

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {            
            _page.GoToHomePage();
        }

        [When(@"I enter reg number '(.*)'")]
        public void WhenIEnterRegNumber(string regNumber)
        {
            _regNumber = regNumber;
            _page.EnterRegNumber(regNumber);
        }

        [When(@"press find vehicle button")]
        public void WhenPressFindVehicleButton()
        {
            _page.FindVehicle();
        }
               
        [Then(@"the result should include vehicle")]
        public void ThenTheResultShouldIncludeVehicle()
        {
            var vehicleExists = _page.VehicleExists(_regNumber);

            Assert.True(vehicleExists);

        }

        [Then(@"the result should not include vehicle")]
        public void ThenTheResultShouldNotIncludeVehicle()
        {
            var vehicleExists = _page.VehicleExists(_regNumber);

            Assert.False(vehicleExists);
        }


        [AfterScenario]
        public void TearDown()
        {
            _driver.Close();
        }


    }
}
