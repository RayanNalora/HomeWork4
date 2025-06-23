using Xunit;
using LoanApp;

namespace LoanApp.Tests
{
    public class LoanEvaluatorTests
    {
        private readonly LoanEvaluator evaluator = new();

        [Fact]
        public void GetLoanEligibility_Should_Return_NotEligible_When_Income_Low()
        {
            var result = evaluator.GetLoanEligibility(1500, true, 800, 5, true);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public void EvaluateEmployed_HighCredit_NoDependents_Returns_Eligible()
        {
            var result = evaluator.GetLoanEligibility(3000, true, 750, 0, false);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public void EvaluateEmployed_MidCredit_OwnHouse_Returns_Review()
        {
            var result = evaluator.GetLoanEligibility(3000, true, 650, 1, true);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public void EvaluateUnemployed_HighIncomeCreditAndHouse_Returns_Eligible()
        {
            var result = evaluator.GetLoanEligibility(6000, false, 760, 1, true);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public void EvaluateUnemployed_LowCredit_Returns_NotEligible()
        {
            var result = evaluator.GetLoanEligibility(3000, false, 500, 1, false);
            Assert.Equal("No Eligible", result);
        }
    }
}