namespace Tipset.Domain
{
    public class Result
    {
        public Player Player { get; set; }
        public int Stryktipset { get; set; }
        public decimal YieldStryktipset { get; set; }
        public decimal YieldLotto { get; set; }
        public Round Round { get; set; }
        public Round AssignedRound { get; set; }
    }
}
