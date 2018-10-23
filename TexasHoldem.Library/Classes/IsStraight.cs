using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.Library.Enums;
using TexasHoldem.Library.Structs;

namespace TexasHoldem.Library.Classes
{
    public class IsStraight
    {
        // private List<Card> _cards;

        public List<Card> BestCards { get; private set; }

        public Hands HandValue { get; private set; }

        public bool EvaluateCards(List<Card> cards)
        {
            if (cards.Count < 5)
            {
                return false;
            }

            // Create an empty list to store the straight
            var straightHand = new List<Card>();


            // Set the first value in cards to the list
            straightHand.Add(cards[0]);

            for (int ii = 1; ii < cards.Count; ii++)
            {
                // Is the last value added to straightHand the same as the next value in cards?
                var lastStoredInStraightHand = straightHand[straightHand.Count - 1].Value;
                var nextValueInCards = cards[ii].Value;

                if (lastStoredInStraightHand != nextValueInCards)
                {
                    // is the value one higher?
                    if ((int)nextValueInCards == (int)lastStoredInStraightHand + 1)
                    {
                        straightHand.Add(cards[ii]);
                    }
                    else // So it is minimum two higher, so no straight
                    {
                        if (straightHand.Count < 5)
                        {
                            straightHand.Clear();
                            straightHand.Add(cards[ii]);
                        }
                    }
                }
            }

            // Do we have five in a row?
            if (straightHand.Count >= 5)
            {
                var top5straightCards = straightHand.ToArray().Reverse().Take(5).Reverse().ToList();
                BestCards = top5straightCards;
                HandValue = Hands.Straight;

                return true;
            }
            return false;




        }
    }
}
