using OnlineBingoAPI.Models;
using System.Linq;

namespace OnlineBingoAPI.Extensions
{
    public static class MatchExtension
    {
        public static void UpdateCards(this Match match, int newNum)
        {
            match.Players.ToList().ForEach(p => {
                p.Card.Numbers.Where(n => n.Num == newNum).ToList().ForEach(number => {
                    number.Checked = true;
                });
            });
        }

        public static Player GetWinner(this Match match)
        {
            foreach(var p in match.Players)
            {
                if (p.Card.Numbers.Any(n => !n.Checked))
                    continue;
                return p;
            }
            return null;
        }
    }
}
