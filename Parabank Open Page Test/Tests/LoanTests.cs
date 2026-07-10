using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParabankAutomation.Tests.Tests
{
    [TestClass]
    public class LoanTests : BaseTest
    {
        [TestMethod]
        [TestCategory("Loan")]
        [Ignore("Needs a valid test username and password before this scenario can run.")]
        public void LoanApplication_OpensAfterLogin()
        {
            ParaBank.OpenHomePage();
            ParaBank.Login("username", "password");
            ParaBank.OpenLoanApplicationPage();
        }
    }
}
