using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace SpecFlowDemo.PageObjects
{
    public class BasePageObject
    {
        protected WebDriverWait Wait { get; }
        protected IWebDriver driver { get; set; }
        protected DefaultWait<IWebDriver> FluentWait;

        public BasePageObject(IWebDriver driver)
        {
            Wait = new WebDriverWait(driver, new TimeSpan(0, 0, 0, 30));
            this.driver = driver;
            PageFactory.InitElements(driver, this);

            FluentWait = new DefaultWait<IWebDriver>(driver);
            FluentWait.Timeout = TimeSpan.FromSeconds(60);
            FluentWait.PollingInterval = TimeSpan.FromSeconds(10);
            FluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        protected void VerifyPageLoaded(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static bool ElementIsPresent(IWebElement element)
        {                       
                if (element.Displayed)
                {
                    return true;
                }
                else
                {
                    throw new Exception();
                }           
        }

        public bool WaitForElement(IWebElement element, TimeSpan? timeout = null)
        {
            timeout = timeout == null ? timeout = driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30) : timeout;
            var retryFrequency = driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var postTimeout = driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            try
            {
               // WaitForElement(element, "Element is absent on the screen", timeout, retryFrequency, postTimeout);
                return true;
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);                
                return false;
            }
        }

        public bool ElementIsNotPresent(string eachDate)
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
    }
}
