using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParabankAutomation.Tests.Tests
{
    [TestClass]
    public class OpenPageTests : BaseTest
    {
        [TestMethod]
        [TestCategory("Smoke")]
        public void HomePage_OpensSuccessfully()
        {
            ParaBank.OpenHomePage();
            ParaBank.VerifyHomePageOpened();
        }
    }
}
