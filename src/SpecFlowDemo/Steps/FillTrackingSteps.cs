using OpenQA.Selenium;
using SpecFlowDemo.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecFlowDemo.Model;

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

    }
}
