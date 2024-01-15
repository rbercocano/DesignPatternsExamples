namespace GangOfFour.Facade
{
    public class BankAccount
    {
        private decimal accountBalance;

        public BankAccount(decimal accountBalance)
        {
            this.accountBalance = accountBalance;
        }
        public bool HasEnoughFunds(decimal amount)
        {
            return accountBalance > amount;
        }
    }
}
