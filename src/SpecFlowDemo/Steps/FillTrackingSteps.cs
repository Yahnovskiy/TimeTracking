using OpenQA.Selenium;
using SpecFlowDemo.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecFlowDemo.Model;
using System;

namespace SpecFlowDemo.Steps
{
    [Binding]
    public class FillTrackingSteps : TechTalk.SpecFlow.Steps
    {
        private IWebDriver driver => ScenarioContext.Get<IWebDriver>("driver");        
        private TimeTrackingPage timetrackingPage;

        [Given(@"I Open Timetracking Page '(.*)'")]
        public void GivenIOpenTimetrackingPage(string URL)
        {            
            timetrackingPage = new TimeTrackingPage(driver);
            driver.Navigate().GoToUrl(URL);
        }
        [Given(@"I Fill Time Tracking Form")]
        public void GivenIFillTimeTrackingForm(Table tableX)
        {
            TimeTrackingModel userData = tableX.CreateInstance<TimeTrackingModel>();
            var timetrackingPage = new TimeTrackingPage(driver);
            timetrackingPage.FillTimeTrackingForm(userData);
        }
        [Given(@"I choose switch OFF bilable if '(.*)'")]
        [When(@"I choose switch OFF bilable if '(.*)'")]
        [Then(@"I choose switch OFF bilable if '(.*)'")]
        public void ISwitchToMeetingTabIf(string isBilableOFF)
        {
            var ISNotBilable = Convert.ToBoolean(isBilableOFF);
            if (ISNotBilable) { Then(@"I choose switch OFF bilable"); }
        }
        //[When(@"I choose switch OFF bilable")]
        //[Then(@"I choose switch OFF bilable")]
        //public void ISwitchToMeetingTab()
        //{
        //   // timetrackingPage.SwitchOFFBilable();
        //}        
    }
}
