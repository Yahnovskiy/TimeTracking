//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Internal;

//namespace SpecFlowDemo.PageObjects
//{
//    public static class WebElementExtensions
//    {
//        public static T ClickAndContinueTo<T>(this IWebElement element) where T : BasePageObject
//        {
//            IWebDriver driver = (element as IWrapsDriver ?? (IWrapsDriver)((IWrapsElement)element).WrappedElement).WrappedDriver;
//            element.Click();
//            return (T)Activator.CreateInstance(typeof(T),new object[] {driver});
//        }
//    }
//}
