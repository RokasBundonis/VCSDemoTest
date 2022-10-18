using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_paskaitaClassLibrary
{
    internal class CheckBoxes
    {
        private static IWebDriver chromeDriver;

        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Url = "http://demo.seleniumeasy.com/basic-checkbox-demo.html";
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            chromeDriver.Quit();
        }
        [Test]
        public static void OneCheckBoxTest()
        {
            IWebElement oneCheckBox = chromeDriver.FindElement(By.Id("isAgeSelected"));
            //IWebElement oneCheckBox = chromeDriver.FindElement(By.CssSelector("isAgeSelected"));
            //IWebElement oneCheckBox = chromeDriver.FindElement(By.ClassName(".cb1-element"));

            if (!oneCheckBox.Selected)
            {
                oneCheckBox.Click();
            }


            IWebElement resultElement = chromeDriver.FindElement(By.Id("txtAge"));
            Assert.AreEqual("Success - Check box is checked", resultElement.Text, "result is wrong");

        }

        [Test]
        public static void CheckBoxesTest()
        {
            IReadOnlyCollection<IWebElement> checkboxesCollection 
                = chromeDriver.FindElements(By.CssSelector(".cb1-element"));

            foreach (IWebElement checkbox in checkboxesCollection)
            {
                if(!checkbox.Selected)
                {
                    checkbox.Click();
                }
                
            }

            IWebElement button = chromeDriver.FindElement(By.Id("check1"));

            Assert.IsTrue("Uncheck All".Equals(button.GetAttribute("value")), "Button value is wrong");

        }
        [Test]
        public static void checkboxesUncheckAll()
        {
            IReadOnlyCollection<IWebElement> checkboxesCollection
                = chromeDriver.FindElements(By.CssSelector(".cb1-element"));

            foreach (IWebElement checkbox in checkboxesCollection)
            {
                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }
            }

            IWebElement button = chromeDriver.FindElement(By.Id("check1"));

            button.Click();

            int countNotSelected = 0;
            foreach (IWebElement checkbox in checkboxesCollection)
            {
                if (!checkbox.Selected)
                {
                    countNotSelected++;
                }
            }

            Assert.AreEqual(checkboxesCollection.Count, countNotSelected, "atleast one checkbox is selected");
            Assert.AreEqual("Check All", button.GetAttribute("value"), "Button value is wrong");

        }


    }
}
