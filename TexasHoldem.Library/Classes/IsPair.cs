using System.Collections.Generic;
using System.Linq;
using TexasHoldem.Library.Enums;
using TexasHoldem.Library.Structs;

namespace TexasHoldem.Library.Classes
{
    public class IsPair
    {

        public List<Card> BestCards { get; private set; }

        public Hands HandValue { get; private set; }

        public bool EvaluateCards(List<Card> cards)
        {

            for (int ii = cards.Count - 1; ii >= 0; ii--)
            {
                if (cards.Count(c => c.Value == cards[ii].Value) == 2) // first pair found
                {
                    var leftoverCards = cards.Where(c => c.Value != cards[ii].Value).ToList();
                    BestCards = cards.Where(c => c.Value == cards[ii].Value).ToList();
                    if (cards.Count > 2)
                    {
                        //BestCards.AddRange(BestCards.GetRange(leftoverCards.Count - 3, 3));
                    }
                    HandValue = Hands.Pair;
                    return true;
                }
            }
            return false;
        }
    }
}

