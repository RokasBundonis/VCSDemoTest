using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_paskaitaClassLibrary
{
    internal class WebDriverTest
    {
        private static WebDriver chromeDriver;

        [OneTimeSetUp]
        public static void OnetimeSetUp()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Url = "http://demo.seleniumeasy.com/basic-first-form-demo.html";
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }
        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            chromeDriver.Quit();
        }


        [TestCase("2","2","4", TestName = "2 plus 2")]
        [TestCase("-5", "3", "-2", TestName = "-5 plus 3")]
        [TestCase("a", "b", "NaN", TestName = " a plus b")]
        public static void FirstAdditionTest(string firstInputValue, string secondInputValue, string resultValue)
        {


            IWebElement inputFieldA = chromeDriver.FindElement(By.Id("sum1"));
            inputFieldA.Clear();
            inputFieldA.SendKeys(firstInputValue);

            IWebElement inputFieldB = chromeDriver.FindElement(By.Id("sum2"));
            inputFieldB.Clear();
            inputFieldB.SendKeys(secondInputValue);

            chromeDriver.FindElement(By.CssSelector("#gettotal > button")).Click();

            IWebElement resultSpan = chromeDriver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(resultValue, resultSpan.Text, "Display value is not correct");
        }

    }
}
