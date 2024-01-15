namespace GangOfFour.Facade
{
    public class Credit
    {
        private int score;

        public Credit(int score)
        {
            this.score = score;
        }
        public bool IsEligible()
        {
            return score > 650;
        }
    }
}
