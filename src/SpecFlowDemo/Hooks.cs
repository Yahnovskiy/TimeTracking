using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium.PhantomJS;
   

namespace SpecFlowDemo
{
    [Binding]
    public sealed class Hooks : TechTalk.SpecFlow.Steps
    {
        [BeforeScenario]
        public void OpenBrowser()
        {
            //var driver = new PhantomJSDriver();
            var driver = new ChromeDriver();
            ScenarioContext.Add("driver", driver);
        }

        [AfterScenario]
        public void QuitBrowser()
        {
            ScenarioContext.Get<IWebDriver>("driver").Quit();            
        }

        [AfterStep]
        public void LogStepResult()
        {
            //This method is here to fix the bug in SpecFlow
            //the bug is when using parallel execution the test output log is not written to the tests
            //see https://github.com/techtalk/SpecFlow/issues/737
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(LevelOfParallelismAttribute), false);
            LevelOfParallelismAttribute attribute = null;
            if (attributes.Length > 0)
            {
                attribute = attributes[0] as LevelOfParallelismAttribute;
                var levelOfParallelism = (int) attribute.Properties.Get(attribute.Properties.Keys.First());

                if (levelOfParallelism > 1)
                {
                    string stepText = StepContext.StepInfo.StepDefinitionType + " " + StepContext.StepInfo.Text;
                    Console.WriteLine(stepText);
                    var stepTable = StepContext.StepInfo.Table;
                    if (stepTable != null && stepTable.ToString() != "") Console.WriteLine(stepTable);
                    var error = ScenarioContext.TestError;
                    Console.WriteLine(error != null ? "-> error: " + error.Message : "-> done.");
                }
            }            
        }
    }
}

