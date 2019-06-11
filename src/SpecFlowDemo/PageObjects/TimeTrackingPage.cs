using HtmlAgilityPack;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SpecFlowDemo.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using TechTalk.SpecFlow;

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
        [FindsBy(How = How.CssSelector, Using = "input:checked[type='checkbox'][title='Billable']")]
        IWebElement CheckBoxBilable { get; set; }
        [FindsBy(How = How.CssSelector, Using = "input:not(checked)[type='checkbox'][title='Billable']")]
        IWebElement CheckBoxBilableDisabled { get; set; }
        // CSS selector, for all checkboxes which are checked
        // input:checked[type='checkbox']
        // CSS selector, for all checkboxes which are not checked
        //input:not(:checked)[type='checkbox']
        // Xpath, only works in certain situations
        //input[@type='checkbox' and @checked='xyz']

        public TimeTrackingPage(IWebDriver driver) : base(driver) { }
                
        public void FillTimeTrackingForm(TimeTrackingModel userData)
        {
            CheckDates();
            var startOfWeek = GetStartOfTheWeek(DateTime.Now.AddDays(3), DayOfWeek.Monday);
            var businessDays = GetBusinessDays(startOfWeek, 3).ToList();
            businessDays.Reverse();

            foreach (var eachBusinessDay in businessDays)
            {
                WaitElement(StopButton);
                //StopButton.Click();
                WaitElement(HomePageNewItem);        
                //HomePageNewItem.Click();
                //VerifyIframeLoaded();
                //driver.SwitchTo().Frame(SwitchToFrame);
                ChooseDate(eachBusinessDay.ToString("dd.MM.yyyy"));
                ChooseActivity(userData.Activity);
                SetTimeSpent(userData.TimeSpent);
                ChooseCategory(userData.Category);
                SwitchOFFBilable(userData.Billable);
                ChooseSubProject(userData.SubProject);
                ChooseRecordType(userData.RecordType);
                WaitElement(SaveButton);
                //SaveButton.Click();                
            }
        }

        public static void WaitElement(IWebElement element)
        {
            var timer = 0;
            do { timer++; Thread.Sleep(TimeSpan.FromSeconds(3));  }
            while (!element.Displayed && timer < 10);
            element.Click();            
        }

        public void CheckDates()
        {
            var startOfWeek = GetStartOfTheWeek(DateTime.Now.AddDays(3), DayOfWeek.Monday);
            var businessDays = GetBusinessDays(startOfWeek, 3).ToArray();
            foreach (var eachBusinessDay in businessDays)
            {
                DateIsNotPresent(eachBusinessDay.ToString("dd.MM.yyyy"));
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
            driver.FindElement(By.XPath("//*[@title='Record type Required Field']/option[text() ='" + recordType + "']")).Click();

        }

        public void ChooseDate(string dayOfWeek)
        {
            DateField.Click();
            DateField.Clear();
            DateField.SendKeys(dayOfWeek);
        }

        public void DateIsNotPresent(string eachDate)
        {
            ElementIsNotPresent(eachDate);           
        }

        public void SwitchOFFBilable(bool billableOFF)
        {
            bool checkboxStatus = billableOFF;
            if (checkboxStatus == true)
            {
                if (!CheckBoxBilableDisabled.Selected)
                {
                    try
                    {
                        CheckBoxBilableDisabled.Click();
                    }
                    catch
                    {
                        throw new Exception();
                    }
                }
            }
            if (checkboxStatus == false)
            {
                if (CheckBoxBilableDisabled.Selected)
                {
                    try
                    {
                        CheckBoxBilable.Click();
                    }
                    catch
                    {
                        throw new Exception();
                    }
                }

            }
        }
        
        /// <summary>
        ///Calculate business days methods 
        /// </summary>        
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
            var holidays = GetHolidays();
            return (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday || holidays.Contains(date)) ? false : true;
            //if (day == DayOfWeek.Saturday
            //    || day == DayOfWeek.Sunday
            //    || holidays.Contains(date))
            //{
            //    return false;
            //}
            //return true;
        }

        public static DateTime GetStartOfTheWeek(DateTime date, DayOfWeek startDayOfWeek)
        {
            while (date.DayOfWeek != startDayOfWeek)
            {
                date = date.AddDays(-1);
            }
            return date;
        } 
        
        public static List<DateTime> GetHolidays()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            WebClient wc = new WebClient();

            string raw = wc.DownloadString($"http://www.timeanddate.com/holidays/ukraine/{DateTime.Today.Year}");

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(raw);
            var imgXpath = htmlDoc.DocumentNode.SelectNodes(".//*[@class='zebra fw tb-cl tb-hover']/tbody");
            List<DateTime> holidays = new List<DateTime>();

            foreach (HtmlNode table in imgXpath)
            {
                //Console.WriteLine("Found" + table.Id);
                foreach( HtmlNode row in table.SelectNodes("tr"))
                {
                    //Console.WriteLine("row");
                    foreach(HtmlNode cell in row.SelectNodes("th"))
                    {
                        //Console.WriteLine("cell" + cell.InnerText);
                        var outDate = cell.InnerText;
                        var parsedDate = DateTime.Parse(outDate);
                        holidays.Add(parsedDate);
                    }
                }                
            }
            return holidays;
        }
        public void test()
        {

        }
    }
}
