using System;

namespace DotNetDesign.Roulette.Models
{
    public class CalculateDurationViewModel
    {
        public Bet[] Bets { get; set; }
        public int Wallet { get; set; }
        public TimeSpan BetDuration { get; set; }
    }
}