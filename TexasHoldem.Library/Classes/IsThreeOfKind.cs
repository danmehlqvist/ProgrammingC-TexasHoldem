using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.Library.Enums;
using TexasHoldem.Library.Structs;

namespace TexasHoldem.Library.Classes
{
    public class IsThreeOfAKind
    {
        public List<Card> BestCards { get; private set; }

        public Hands HandValue { get; private set; }

        public bool EvaluateCards(List<Card> cards)
        {
            if (cards.Count < 3)
            {
                return false;
            }

            for (int ii = cards.Count - 1; ii >= 0; ii = ii - 3)
            {
                if (cards.Count(c => c.Value == cards[ii].Value)==3)
                {
                    var leftoverCards = cards.Where(c => c.Value != cards[ii].Value).ToList();
                    BestCards = cards.Where(c => c.Value == cards[ii].Value).ToList();
                    BestCards.Add(leftoverCards[leftoverCards.Count - 1]);
                    BestCards.Add(leftoverCards[leftoverCards.Count - 2]);
                    HandValue = Hands.ThreeOfAKind;
                    return true;
                }
            }

            return false;
        }
    }
}
