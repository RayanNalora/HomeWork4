namespace LoanApp
{
    public class LoanEvaluator
    {
        public string GetLoanEligibility(int income, bool hasJob, int creditScore, int dependents, bool ownHouse)
        {
            if (income < 2000)
                return "Not Eligible";

            return hasJob
                ? EvaluateEmployed(creditScore, dependents, ownHouse)
                : EvaluateUnemployed(income, creditScore, dependents, ownHouse);
        }

        private string EvaluateEmployed(int creditScore, int dependents, bool ownHouse)
        {
            if (creditScore >= 700)
            {
                if (dependents == 0)
                    return "Eligible";
                else if (dependents <= 2)
                    return "Review Manually";
                else
                    return "No Eligible";
            }
            else if (creditScore >= 600)
            {
                return ownHouse ? "Review Manually" : "No Eligible";
            }
            else
            {
                return "No Eligible";
            }
        }

        private string EvaluateUnemployed(int income, int creditScore, int dependents, bool ownHouse)
        {
            if (creditScore >= 750 && income > 5000 && ownHouse)
                return "Eligible";
            else if (creditScore >= 650 && dependents == 0)
                return "Review Manually";
            else
                return "No Eligible";
        }
    }
}