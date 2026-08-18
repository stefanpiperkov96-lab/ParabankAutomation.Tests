using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ParabankAutomation.Tests.Tests
{
    [TestClass]
    public class LoanTests : BaseTest
    {
        [TestMethod]
        [TestCategory("Loan")]
        [DynamicData(nameof(GetLoanApplicationScenarios), DynamicDataSourceType.Method)]
        public void Customer_CanApplyForLoan_FromSelectedAccount(LoanApplicationScenario scenario)
        {
            string username = GetRequiredEnvironmentVariable("PARABANK_USERNAME");
            string password = GetRequiredEnvironmentVariable("PARABANK_PASSWORD");

            ParaBank.OpenHomePage();
            ParaBank.Login(username, password);
            ParaBank.OpenLoanApplicationPage();
            ParaBank.ApplyForLoan(
                loanAmount: scenario.LoanAmount,
                downPayment: scenario.DownPayment,
                fromAccountId: scenario.FromAccountId);
        }

        public static IEnumerable<object[]> GetLoanApplicationScenarios()
        {
            string testDataPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "TestData",
                "loan-test-data.json");

            string json = File.ReadAllText(testDataPath);
            LoanApplicationScenario[] scenarios = JsonSerializer.Deserialize<LoanApplicationScenario[]>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            foreach (LoanApplicationScenario scenario in scenarios)
            {
                yield return new object[] { scenario };
            }
        }

        private static string GetRequiredEnvironmentVariable(string name)
        {
            string value = Environment.GetEnvironmentVariable(name);

            if (string.IsNullOrWhiteSpace(value))
            {
                Assert.Inconclusive("Set the " + name + " environment variable before running this test.");
            }

            return value;
        }

        public class LoanApplicationScenario
        {
            public string FromAccountId { get; set; }

            public string LoanAmount { get; set; }

            public string DownPayment { get; set; }

            public override string ToString()
            {
                return "Account " + FromAccountId + ", loan " + LoanAmount + ", down payment " + DownPayment;
            }
        }
    }
}
