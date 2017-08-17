using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SpecFlowDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpecFlowDemo.PageObjects
{
    public class TimeTrackingPage : BasePageObject
    {
        [FindsBy(How = How.XPath, Using = ".//*[@title='Stop editing and save changes.']")]
        IWebElement StopButton { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='idHomePageNewItem']")]
        IWebElement HomePageNewItem { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@class ='ms-dlgFrame']")]
        IWebElement SwitchToFrame { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".ms-dtinput input")]
        IWebElement DateField { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@title='Activity Required Field']")]
        IWebElement ActivityField { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@title='Time spent Required Field']")]
        IWebElement TimeSpentButton { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='Ribbon.ListForm.Edit.Commit.Publish-Large']")]
        IWebElement SaveButton { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='Ribbon.ListForm.Edit.Commit.Cancel-Large']")]
        IWebElement CancelButton { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@title='Category']")]
        IWebElement CategoryButton { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@title='SubProject Required Field']")]
        IWebElement SubProjectButton { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@title='Record type Required Field']")]
        IWebElement RecordTypeButton { get; set; }

        public TimeTrackingPage(IWebDriver driver) : base(driver) { }        
        
        public void FillTimeTrackingForm(TimeTrackingModel userData)
        {
            var startOfWeek = GetStartOfTheWeek(DateTime.Today, DayOfWeek.Monday);
            var businessDays = GetBusinessDays(startOfWeek, 5).ToArray();
            //StopButton.Click();
            foreach (var eachBusinessDay in businessDays)
            {
                StopButton.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                HomePageNewItem.Click();
                VerifyIframeLoaded();
                driver.SwitchTo().Frame(SwitchToFrame);
                DateField.Click();
                DateField.Clear();
                DateField.SendKeys(eachBusinessDay.ToString("dd.MM.yyyy"));
                ChooseActivity(userData.Activity);
                SetTimeSpent(userData.TimeSpent);
                ChooseCategory(userData.Category);
                ChooseSubProject(userData.SubProject);
                ChooseRecordType(userData.RecordType);

                SaveButton.Click();
                //CancelButton.Click();                
            }
        }

        public void VerifyIframeLoaded()
        {
            ElementIsPresent(SwitchToFrame);
        }

        public void ChooseActivity(string activity)
        {
            ActivityField.Clear();
            ActivityField.SendKeys(activity);
        }

        public void SetTimeSpent(string timeSpent)
        {
            TimeSpentButton.Click();
            TimeSpentButton.Clear();
            TimeSpentButton.SendKeys(timeSpent);            
        }

        public void ChooseCategory(string category)
        {
            CategoryButton.Click();
            driver.FindElement(By.XPath(".//*[text() ='" + category + "']")).Click();
        }

        public void ChooseSubProject(string subProject)
        {
            SubProjectButton.Click();
            driver.FindElement(By.XPath(".//*[text() ='" + subProject + "']")).Click();
        }

        public void ChooseRecordType(string recordType)
        {
            RecordTypeButton.Click();
            driver.FindElement(By.XPath(".//*[text() ='" + recordType + "']")).Click();
        }

        public static List<DateTime> GetBusinessDays(DateTime dayOfWeek, double daysCount)
        {
            var businessDays = new List<DateTime>();
            while (daysCount >= 0)
            {
                var day = dayOfWeek.AddDays(daysCount).Date;
                if (IsBusinessDay(day))
                    businessDays.Add(day);
                daysCount -= 1;
            }
            return businessDays;
        }

        public static new bool IsBusinessDay(DateTime date)
        {
            var day = date.DayOfWeek;
            var res = (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday) ? false : true;
            return res;
        }

        public static DateTime GetStartOfTheWeek(DateTime date, DayOfWeek startDayOfWeek)
        {
            while (date.DayOfWeek != startDayOfWeek)
            {
                date = date.AddDays(-1);
            }
            return date;
        }
        //public void ForEachDate()
        //{
        //    var startOfWeek = GetStartOfTheWeek(DateTime.Today, DayOfWeek.Monday);
        //    var businessDays = GetBusinessDays(startOfWeek, 5).ToArray();            
        //    foreach (var eachBusinessDay in businessDays)
        //    {
        //        //try
        //        //{
        //        //    Assert.AreEqual(true, ElementIsPresent(_driver.FindElement(By.XPath(".//*[@title='" + eachBusinessDay.ToString("dd.MM.yyyy") + "']"))));
        //        //}
        //        //catch
        //        //{
        //        //    return; 
        //        //}
        //        StopButton.Click();
        //        HomePageNewItem.Click();
        //        _driver.SwitchTo().Frame(_driver.FindElement(By.XPath(".//*[@class ='ms-dlgFrame']")));
        //        DateField.Click();
        //        DateField.Clear();
        //        DateField.SendKeys(eachBusinessDay.ToString("dd.MM.yyyy"));
        //        ActivityField.Clear();
        //        ActivityField.SendKeys("*");
        //        CategoryButton.Click();
        //        _driver.FindElement(By.XPath(".//*[text() ='"+category+"2 - Testing']"));
        //        SavelButton.Click();
        //        FluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@title='" + eachBusinessDay.ToString("dd.MM.yyyy") + "']")));
        //    }
        //}
    }
}
