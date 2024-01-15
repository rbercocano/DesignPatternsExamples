namespace GangOfFour.Facade
{
    public class Income
    {
        private decimal monthlyIncome;

        public Income(decimal monthlyIncome)
        {
            this.monthlyIncome = monthlyIncome;
        }
        public bool IsEnough(decimal monthlyPayment)
        {
            return monthlyPayment < monthlyIncome / 3;
        }
    }
}
