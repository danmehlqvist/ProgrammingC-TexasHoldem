using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.Library.Enums;
using TexasHoldem.Library.Interfaces;
using TexasHoldem.Library.Structs;

namespace TexasHoldem.Library.Classes
{
    public class HandEvaluator : IHandEvaluator
    {
        private List<Card> BestCards { get; set; } = new List<Card>();

        private Hands HandValue { get; set; }

        private Suits Suit { get; set; }

        private IsStraight isStraight = new IsStraight();

        public (List<Card>, Hands, Suits) EvaluateHand(List<Card> cards)
        {
            BestCards.Clear();
            HandValue = Hands.Nothing;
            Suit = Suits.Unknown;

            if (cards.Count() >= 2)
            {
                // Sort the values according to the CompareTo in Card struct.
                // The cards should be sorting in ascending order
                cards.Sort();



                //if (IsRoyalOrStraightFlush(cards)) { return (BestCards, HandValue, Suit); }
                //if (FourOfAKind(cards)) { return (BestCards, HandValue, Suit); }
                //if (IsFullHouse(cards)) { return (BestCards, HandValue, Suit); }
                //if (IsFlush(cards)) { return (BestCards, HandValue, Suit); }
                if (isStraight.EvaluateCards(cards))
                {
                    BestCards = isStraight.BestCards;
                    HandValue = isStraight.HandValue;
                    return (BestCards, HandValue, Suit);
                }
                //if (IsThreeOfAKind(cards)) { return (BestCards, HandValue, Suit); }
                //if (IsTwoPairs(cards)) { return (BestCards, HandValue, Suit); }
                //if (IsPair(cards)) { return (BestCards, HandValue, Suit); }


            }
            return (BestCards, HandValue, Suit);
        }
    }
}
//    private bool IsRoyalOrStraightFlush(List<Card> cards)
//    {
//        List<Card> tempCards = IsStraightHelper(cards);
//        if (tempCards != null) // It is a straight
//        {
//            // Is it also a flush?
//            if (tempCards.Count(c => c.Suit == cards[0].Suit) == 5) //Is also a flush
//            {
//                if (cards[4].Value == Values.Ace) // Is top card an ace?
//                {
//                    // Is a Royal Straight Flush!
//                    HandValue = Hands.RoyalStraigtFlush;
//                    Suit = cards[0].Suit;
//                    BestCards = cards;
//                    return true;
//                }
//                // Is a Straight Flush
//                HandValue = Hands.StraightFlush;
//                Suit = cards[0].Suit;
//                BestCards = cards;
//                return true;
//            }
//        }
//        return false;
//    }

//    private bool FourOfAKind(List<Card> cards)
//    {
//        var tempCards = new List<Card>(cards);
//        var fourOfAKindCards = new List<Card>();

//        while (tempCards.Count >= 4)
//        {
//            if (tempCards.Count(c => c.Value == tempCards[0].Value) > 4)
//            {

//                var tempBestCards = new List<Card>();

//                // tempBestCards are the four of a kind cards
//                tempBestCards = tempCards.Where(c => c.Value == tempCards[0].Value).ToList();

//                tempCards = new List<Card>(cards);

//                // tempCards will contain the cards minus the four of kind cards.
//                foreach (var card in tempBestCards)
//                {
//                    tempCards.Remove(card);
//                }

//                // Add the highest card of the left over cards to BestCards
//                tempBestCards.Add(tempCards[tempCards.Count - 1]);

//                HandValue = Hands.FourOfAKind;
//                Suit = Suits.Unknown;
//                BestCards = tempBestCards;
//                return true;
//            }
//            else tempCards.Remove(tempCards[0]);
//        }

//        return false;
//    }

//    private bool IsFullHouse(List<Card> cards)
//    {
//        if (cards.Count < 5)
//        {
//            return false;
//        }

//        var tempCards = new List<Card>(cards);

//        for (int ii = 4; ii > 2; ii = ii - 2)
//        {
//            if (cards.Count(c => c.Value == cards[ii].Value) == 3) // Has a three of a kind
//            {
//                // Build the tempCards
//                tempCards = cards.Where(c => c.Value != cards[ii].Value).ToList();
//                for (int jj = 2; jj > 0; jj--)
//                {
//                    if (tempCards.Count(c => c.Value == tempCards[jj].Value) > 2)
//                    {
//                        // Has also a pair! Full House!
//                    }
//                    HandValue = Hands.FullHouse;
//                    // BestCards
//                    return true;
//                }
//            }
//        }


//        return false;
//    }



//    private bool IsStraight(List<Card> cards)
//    {
//        if (cards.Count < 5)
//        {
//            return false;
//        }

//        // Create an empty list to store the straight
//        var straightHand = new List<Card>();


//        // Set the first value in cards to the list
//        straightHand.Add(cards[0]);

//        for (int ii = 1; ii < cards.Count; ii++)
//        {
//            // Is the last value added to straightHand the same as the next value in cards?
//            var lastStoredInStraightHand = straightHand[straightHand.Count - 1].Value;
//            var nextValueInCards = cards[ii].Value;

//            if (lastStoredInStraightHand == nextValueInCards)
//            {
//                // Do nothing
//            }
//            else
//            {
//                // is the value one higher?
//                if ((int)nextValueInCards == (int)lastStoredInStraightHand + 1)
//                {
//                    straightHand.Add(cards[ii]);
//                }
//                else // So it is minimum two higher, so no straight
//                {
//                    straightHand.Clear();
//                    straightHand.Add(cards[ii]);
//                }
//            }
//        }

//        // Do we have five in a row?
//        if (straightHand.Count >= 5)
//        {
//            var top5straightCards = straightHand.ToArray().Reverse().Take(5).Reverse().ToList();
//            BestCards = top5straightCards;
//            Suit = Suits.Unknown;
//            HandValue = Hands.Straight;
//            return true;
//        }
//        return false;

//    }

//    private List<Card> IsStraightHelper(List<Card> cards)
//    {
//        if (cards.Count < 5)
//        {
//            return null;
//        }

//        // Create an empty list to store the straight
//        var straightHand = new List<Card>();


//        // Set the first value in cards to the list
//        straightHand.Add(cards[0]);

//        for (int ii = 1; ii < cards.Count; ii++)
//        {
//            // Is the last value added to straightHand the same as the next value in cards?
//            var lastStoredInStraightHand = straightHand[straightHand.Count - 1].Value;
//            var nextValueInCards = cards[ii].Value;

//            if (lastStoredInStraightHand == nextValueInCards)
//            {
//                // Do nothing
//            }
//            else
//            {
//                // is the value one higher?
//                if ((int)nextValueInCards == (int)lastStoredInStraightHand + 1)
//                {
//                    straightHand.Add(cards[ii]);
//                }
//                else // So it is minimum two higher, so no straight
//                {
//                    straightHand.Clear();
//                    straightHand.Add(cards[ii]);
//                }
//            }
//        }

//        // Do we have five in a row?
//        if (straightHand.Count >= 5)
//        {
//            var top5straightCards = straightHand.ToArray().Reverse().Take(5).Reverse().ToList();
//            BestCards = top5straightCards;
//            Suit = Suits.Unknown;
//            HandValue = Hands.Straight;
//            return top5straightCards;
//        }
//        return null;

//    }

//    private bool IsFlush(List<Card> cards)
//    {
//        foreach (var card in cards)
//        {
//            if (cards.Count(c => card.Suit == c.Suit) >= 5) // Ok. We have a flush
//            {
//                // Which cards have the color Suit?
//                var flushCards = cards.Where(f => f.Suit == card.Suit);

//                // Take the top 5 of them
//                var top5FlushCards = flushCards.Reverse().Take(5).Reverse().ToList();

//                //Set stuff and return
//                BestCards = top5FlushCards;
//                Suit = card.Suit;
//                HandValue = Hands.Flush;
//                return true;
//            }
//        }
//        return false;
//    }

//    private bool IsThreeOfAKind(List<Card> cards)
//    {
//        if (cards.Count < 3)
//        {
//            return false;
//        }
//        var tempCards = new List<Card>(cards);
//        return false;
//        //for (int ii = 4; ii > 2; ii=ii-2)
//        //{
//        //    if (cards.Count(c => c.Value == cards[ii].Value) == 3) // Has a three of a kind
//        //    {
//        //        HandValue = Hands.ThreeOfAKind;
//        //        return true;
//        //    }
//        //}
//        //return false;
//    }

//    private bool IsTwoPairs(List<Card> cards)
//    {

//        //var tempCards = new List<Card>(cards);
//        //tempCards.Reverse();

//        //for (int ii = 0; ii < tempCards.Count-1; ii = ii + 2)
//        //{
//        //    if (tempCards.Count(c => c.Value == tempCards[ii].Value) == 2)
//        //    {
//        //        // Remove the pair from the tempCards
//        //        tempCards = tempCards.Where(c => c.Value != tempCards[ii].Value).ToList();

//        //        for (int jj = 0; jj < tempCards.Count - 1; jj = jj + 2)
//        //        {
//        //            if (tempCards.Count(c => c.Value == tempCards[ii].Value) == 2)
//        //            {
//        //                HandValue = Hands.TwoPair;
//        //                return true;
//        //            }
//        //        }


//        //    }
//        //}

//        return false;
//    }

//    private bool IsPair(List<Card> cards)
//    {
//        //var tempCards = new List<Card>(cards);
//        //tempCards.Reverse();

//        //for (int ii = 0; ii < tempCards.Count; ii = ii + 2)
//        //{
//        //    if (tempCards.Count(c => c.Value == tempCards[ii].Value) == 2)
//        //    {
//        //        HandValue = Hands.Pair;
//        //        return true;
//        //    }
//        //}

//        return false;
//    }

//    private void ClearProps()
//    {
//        HandValue = Hands.Nothing;
//        Suit = Suits.Unknown;
//    }
//}

