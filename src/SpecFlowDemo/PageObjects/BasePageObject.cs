using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

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
            PageFactory.InitElements(driver,this);

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
            try
            {
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("ddddddddddddddd is not fount");
                return false;
            }
        }
    }
}
