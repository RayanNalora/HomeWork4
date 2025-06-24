namespace LoanApp
{
    public class LoanEvaluator
    {
        public string GetLoanEligibility(int income, bool hasJob, int creditScore, int dependents, bool ownHouse)
        {
            if (income < 2000)  ////+1
                return "Not Eligible";

            return hasJob ////+1    بسبب الشرط
                ? EvaluateEmployed(creditScore, dependents, ownHouse)
                : EvaluateUnemployed(income, creditScore, dependents, ownHouse);
        }

        private string EvaluateEmployed(int creditScore, int dependents, bool ownHouse)
        {
            if (creditScore >= 700)////+1
            {
                if (dependents == 0)  ////+1
                    return "Eligible";
                else if (dependents <= 2)    ////+1
                    return "Review Manually";
                else
                    return "No Eligible";
            }
            else if (creditScore >= 600)  ////+1
            {
                return ownHouse ? "Review Manually" : "No Eligible"; ////+1  لانه شرط
            }
            else
            {
                return "No Eligible";
            }
        }

        private string EvaluateUnemployed(int income, int creditScore, int dependents, bool ownHouse)
        {
            if (creditScore >= 750 && income > 5000 && ownHouse) ////+1
                return "Eligible";
            else if (creditScore >= 650 && dependents == 0) ////+1
                return "Review Manually";
            else
                return "No Eligible";
        }
    }
}