using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
