using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.Library.Enums;
using TexasHoldem.Library.Structs;

namespace TexasHoldem.Library.Classes
{
    public class IsFlush
    {
        public List<Card> BestCards { get; private set; }

        public Hands HandValue { get; private set; }

        public Suits Suit { get; private set; }

        public bool EvaluateCards(List<Card> cards)
        {
            if (cards.Count < 5)
            {
                return false;
            }

            foreach(var card in cards)
            {
                if (cards.Count(c => c.Suit == card.Suit) >= 5)
                {
                    var flushCards = cards.Where(ca => ca.Suit == card.Suit).Reverse().Take(5).Reverse().ToList();

                    HandValue = Hands.Flush;
                    Suit = card.Suit;
                    BestCards = flushCards;
                    return true;
                }
            }
            return false;
        }

    }
}
