using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.Library.Enums;
using TexasHoldem.Library.Structs;

namespace TexasHoldem.Library.Classes
{
    public class IsStraightFlush
    {
        public List<Card> BestCards { get; private set; }

        public Hands HandValue { get; private set; }

        public Suits Suit { get; private set; }

        public bool EvaluateCards(List<Card> cards)
        {
            var isStraight = new IsStraight();
            var isFlush = new IsFlush();

            if (isStraight.EvaluateCards(cards))
            { // We have a straight
                if (isFlush.EvaluateCards(isStraight.BestCards)) // We have a straight flush
                {
                    BestCards = isStraight.BestCards;
                    Suit = isFlush.Suit;
                    HandValue = Hands.StraightFlush;
                    return true;
                }
            }
            return false;
        }

    }
}