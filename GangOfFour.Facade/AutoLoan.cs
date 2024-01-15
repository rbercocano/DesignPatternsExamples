namespace GangOfFour.Facade
{
    public class AutoLoan
    {
        private readonly Credit credit;
        private readonly Income income;
        private readonly BankAccount bankAccount;
        private readonly int score;

        public AutoLoan(int score, decimal monthlyIncome, decimal accountBalance)
        {
            credit = new Credit(score);
            income = new Income(monthlyIncome);
            bankAccount = new BankAccount(accountBalance);
            this.score = score;
        }
        public decimal CalculateLoan(decimal downPayment, decimal vehiclePrice, int installments)
        {
            var monthlyPayment = (vehiclePrice - downPayment) / installments;
            var incomeApproved = income.IsEnough(monthlyPayment);
            var enoughForDownPayment = bankAccount.HasEnoughFunds(downPayment);
            var enoughCredit = credit.IsEligible();
            if (!incomeApproved || !enoughForDownPayment || !enoughCredit)
                throw new Exception("Auto Loan rejected");

            if (score < 700)
                return 10.5M;
            if (score < 749)
                return 7.5M;
            if (score < 799)
                return 5.5M;
            return 3.5M;
        }
    }
}
