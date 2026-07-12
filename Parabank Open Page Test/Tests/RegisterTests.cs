using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ParabankAutomation.Tests.Tests
{
    [TestClass]
    public class RegisterTests : BaseTest
    {
        [TestMethod]
        [TestCategory("Register")]
        public void RegisterPage_OpensFromHomePage()
        {
            ParaBank.OpenHomePage();
            ParaBank.OpenRegistrationPage();
            ParaBank.VerifyRegistrationPageOpened();
        }

        [TestMethod]
        [TestCategory("Register")]
        public void User_CanRegister()
        {
            string username = "stefan" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string password = "TestPassword123";

            ParaBank.OpenHomePage();
            ParaBank.OpenRegistrationPage();
            ParaBank.RegisterUser(
                firstName: "Stefan",
                lastName: "Piperkov",
                address: "Test Address",
                city: "Test City",
                state: "Delaware",
                zipCode: "19701",
                phoneNumber: "3025550100",
                ssn: "123456789",
                username: username,
                password: password);

            ParaBank.VerifyRegistrationSucceeded(username);
        }
    }
}
