using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ParabankAutomation.Tests.Workflows;

namespace ParabankAutomation.Tests.Tests
{
    [TestClass]
    public abstract class BaseTest
    {
        protected IWebDriver Driver { get; private set; }
        protected ParaBankWorkflow ParaBank { get; private set; }

        [TestInitialize]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            Driver = new ChromeDriver(options);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            ParaBank = new ParaBankWorkflow(Driver);
        }

        [TestCleanup]
        public void TearDown()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}
