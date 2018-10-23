using System.Collections.Generic;
using System.Linq;
using TexasHoldem.Library.Enums;
using TexasHoldem.Library.Structs;

namespace TexasHoldem.Library.Classes
{
    public class IsTwoPairs
    {

        public List<Card> BestCards { get; private set; }

        public Hands HandValue { get; private set; }

        public bool EvaluateCards(List<Card> cards)
        {

            for (int ii = cards.Count - 1; ii > 0; ii--)
            {
                if (cards.Count(c => c.Value == cards[ii].Value) == 2) // first pair found
                {
                    var pairOne = cards.Where(c => c.Value == cards[ii].Value).ToList();
                    var leftoverCards = cards.Where(c => c.Value != cards[ii].Value).ToList();

                    for (int jj = cards.Count - 1; jj > 0; jj--)
                    {

                        if (leftoverCards.Count(c => c.Value == leftoverCards[jj].Value) == 2) // second pair found
                        {
                            var leftoverCardsSecondRound = leftoverCards.Where(c => c.Value != leftoverCards[jj].Value).ToList();
                            BestCards = leftoverCards.Where(c => c.Value == leftoverCards[jj].Value).ToList();
                            BestCards.AddRange(pairOne);
                            BestCards.Add(leftoverCardsSecondRound[leftoverCardsSecondRound.Count - 1]);
                            HandValue = Hands.TwoPair;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
