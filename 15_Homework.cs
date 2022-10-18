using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_paskaitaClassLibrary
{
    internal class _15_Homework
    {
        private static WebDriver Driver;

        [TestCase("Firefox")]
        [TestCase("Chrome")]
        public static void DriverTest(string driver)
        {
            Driver = new FirefoxDriver();
            Driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

    }
}
