using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParabankAutomation.Tests
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
           
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Dispose();
        }
    }
}