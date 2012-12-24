using System.Collections.Generic;
using System.Linq;

namespace DotNetDesign.Roulette.Models
{
    public class GameResult
    {
        public List<BetResult> BetResults { get; set; }
        public Number HitNumber { get; set; }
        public int Investment { get { return BetResults.Sum(betResult => betResult.Bet.Amount); } }
        public int Delta { get { return BetResults.Sum(betResult => betResult.Delta); } }

        public GameResult(Number hitNumber, IEnumerable<Bet> bets)
        {
            var betsArray = bets as Bet[] ?? bets.ToArray();

            BetResults = new List<BetResult>(betsArray.Count());
            this.HitNumber = hitNumber;

            foreach (var bet in betsArray)
            {
                BetResults.Add(new BetResult(bet, this.HitNumber));
            }
        }
    }
}