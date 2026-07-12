using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ParabankAutomation.Tests.Workflows
{
    public class ParaBankWorkflow
    {
        private const string BaseUrl = "https://parabank.parasoft.com/parabank/index.htm";
        private readonly IWebDriver driver;

        public ParaBankWorkflow(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            WaitUntilPageLoaded();
            WaitUntilVisible(By.Id("leftPanel"));
        }

        public void VerifyHomePageOpened()
        {
            StringAssert.Contains(driver.Url, "/parabank/");
            StringAssert.Contains(driver.Title, "ParaBank");
            StringAssert.Contains(Find(By.CssSelector("#leftPanel h2")).Text, "Customer Login");
        }

        public void OpenRegistrationPage()
        {
            Click(By.LinkText("Register"));
            WaitUntilVisible(By.Id("customerForm"));
        }

        public void VerifyRegistrationPageOpened()
        {
            StringAssert.Contains(driver.Url, "register.htm");
            StringAssert.Contains(Find(By.CssSelector("#rightPanel h1")).Text, "Signing up is easy!");
        }

        public void RegisterUser(
            string firstName,
            string lastName,
            string address,
            string city,
            string state,
            string zipCode,
            string phoneNumber,
            string ssn,
            string username,
            string password)
        {
            Type(By.Id("customer.firstName"), firstName);
            Type(By.Id("customer.lastName"), lastName);
            Type(By.Id("customer.address.street"), address);
            Type(By.Id("customer.address.city"), city);
            Type(By.Id("customer.address.state"), state);
            Type(By.Id("customer.address.zipCode"), zipCode);
            Type(By.Id("customer.phoneNumber"), phoneNumber);
            Type(By.Id("customer.ssn"), ssn);
            Type(By.Id("customer.username"), username);
            Type(By.Id("customer.password"), password);
            Type(By.Id("repeatedPassword"), password);
            Click(By.CssSelector("input[value='Register']"));
            WaitUntilVisible(By.CssSelector("#rightPanel h1"));
        }

        public void VerifyRegistrationSucceeded(string username)
        {
            StringAssert.Contains(Find(By.CssSelector("#rightPanel h1")).Text, "Welcome " + username);
            StringAssert.Contains(Find(By.Id("rightPanel")).Text, "Your account was created successfully.");
        }

        public void Login(string username, string password)
        {
            Type(By.Name("username"), username);
            Type(By.Name("password"), password);
            Click(By.CssSelector("input[value='Log In']"));
        }

        public void OpenLoanApplicationPage()
        {
            Click(By.LinkText("Request Loan"));
            WaitUntilVisible(By.Id("requestLoanForm"));
        }

        private void Click(By locator)
        {
            WaitUntilVisible(locator).Click();
        }

        private void Type(By locator, string value)
        {
            IWebElement element = WaitUntilVisible(locator);
            element.Clear();
            element.SendKeys(value);
        }

        private IWebElement Find(By locator)
        {
            return WaitUntilVisible(locator);
        }

        private void WaitUntilPageLoaded()
        {
            WebDriverWait wait = NewWait();
            wait.Until(d => ((IJavaScriptExecutor)d)
                .ExecuteScript("return document.readyState")
                .Equals("complete"));
        }

        private IWebElement WaitUntilVisible(By locator)
        {
            WebDriverWait wait = NewWait();
            return wait.Until(d =>
            {
                IWebElement element = d.FindElement(locator);
                return element.Displayed ? element : null;
            });
        }

        private WebDriverWait NewWait()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }
    }
}
