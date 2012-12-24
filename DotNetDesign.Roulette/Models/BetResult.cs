namespace DotNetDesign.Roulette.Models
{
    public class BetResult
    {
        public Bet Bet { get; set; }
        public bool IsWinner { get; set; }
        public int Delta { get; set; }

        public BetResult(Bet bet, Number hitNumber)
        {
            this.Bet = bet;

            var slot = Slot.Slots[this.Bet.SlotType];
            this.IsWinner = slot.IsWinner(hitNumber);

            this.Delta = slot.GetWinnings(hitNumber, this.Bet.Amount) - this.Bet.Amount;
        }
    }
}