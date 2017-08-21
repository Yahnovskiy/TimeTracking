using HtmlAgilityPack;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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

        public TimeTrackingPage(IWebDriver driver) : base(driver) { }

        public void CheckDates()
        {
            var startOfWeek = GetStartOfTheWeek(DateTime.Today, DayOfWeek.Monday);
            var businessDays = GetBusinessDays(startOfWeek, 5).ToArray();
            foreach (var eachBusinessDay in businessDays)
            {
                elementIsNotPresent(eachBusinessDay.ToString("dd.MM.yyyy"));                
            }
        }     
        
        public void FillTimeTrackingForm(TimeTrackingModel userData)
        {
            CheckDates();
            var startOfWeek = GetStartOfTheWeek(DateTime.Today, DayOfWeek.Monday);
            var businessDays = GetBusinessDays(startOfWeek, 5).ToList();
            businessDays.Reverse();

            foreach (var eachBusinessDay in businessDays)
            {                
                StopButton.Click();                
                Thread.Sleep(TimeSpan.FromSeconds(2));
                HomePageNewItem.Click();
                VerifyIframeLoaded();
                driver.SwitchTo().Frame(SwitchToFrame);
                ChooseDate(eachBusinessDay.ToString("dd.MM.yyyy"));
                ChooseActivity(userData.Activity);
                SetTimeSpent(userData.TimeSpent);
                ChooseCategory(userData.Category);
                ChooseSubProject(userData.SubProject);
                ChooseRecordType(userData.RecordType);

                SaveButton.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));                
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

        public void ChooseDate(string dayOfWeek)
        {
            DateField.Click();
            DateField.Clear();
            DateField.SendKeys(dayOfWeek);
        }

        public bool elementIsNotPresent(string eachDate)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(300);
            if (driver.FindElements(By.XPath(".//*[@title='" + eachDate + "']")).Count > 0)
            {                
                throw new Exception("Time tracking already exist on " + eachDate);
            }
            else
            {                
                return true;
            }            
        }

        public bool elementIsNotPresentxpath(string eachDate)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(300);
            if (driver.FindElements(By.XPath(".//*[@title='" + eachDate + "']")).Count > 0)
            {
                throw new Exception("Time tracking already exist on " + eachDate);
            }
            else
            {
                return true;
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
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            WebClient wc = new WebClient();
            string raw = wc.DownloadString("http://www.timeanddate.com/holidays/ukraine/2017");

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(raw);

            var imgXpath = htmlDoc.DocumentNode.SelectNodes(".//*[@class='c0']/th");
            var dd = imgXpath.ToString();
            DateTime myDate = DateTime.ParseExact(dd, "MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);



            //foreach (HtmlNode node in imgXpath)
            //{
            //    string strValue = node.InnerText;
            //}


            var day = date.DayOfWeek;
            var res = (
                day == DayOfWeek.Saturday || day == DayOfWeek.Sunday) ? false : true;
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
    }
}
