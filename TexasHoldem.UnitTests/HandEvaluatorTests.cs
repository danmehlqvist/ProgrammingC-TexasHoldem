using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TexasHoldem.Library.Classes;
using TexasHoldem.Library.Enums;
using TexasHoldem.Library.Structs;

namespace TexasHoldem.UnitTests
{
    [TestClass]
    public class HandEvaluatorTests
    {
        // Hearts
        //private static Card aceOfHearts = new Card(Suits.Hearts, Values.Ace);
        //private static Card kingOfHearts = new Card(Suits.Hearts, Values.King);
        //private static Card queenOfHearts = new Card(Suits.Hearts, Values.Queen);
        //private static Card jackOfHearts = new Card(Suits.Hearts, Values.Jack);
        //private static Card tenOfHearts = new Card(Suits.Hearts, Values.Ten);

        //// Spades
        //private static Card fiveOfSpades = new Card(Suits.Spades, Values.Five);
        //private static Card eightOfSpades = new Card(Suits.Spades, Values.Five);
        //// Diamonds
        //private static Card twoOfDiamonds = new Card(Suits.Diamonds, Values.Two);
        //private static Card sixOfDiamonds = new Card(Suits.Diamonds, Values.Six);
        //// Clubs
        //private static Card queenOfClubs = new Card(Suits.Clubs, Values.Queen);

        //// Card Collections containing nothing
        //private static List<Card> cards2nothing = new List<Card> { aceOfHearts, kingOfHearts };
        //private static List<Card> cards4nothing = new List<Card> { aceOfHearts, kingOfHearts, fiveOfSpades, eightOfSpades };
        //private static List<Card> cards5nothing = new List<Card> { aceOfHearts, kingOfHearts, fiveOfSpades, eightOfSpades, twoOfDiamonds };


        //private static List<Card> cards5RoyalStraightFlush = new List<Card>
        //{
        //    aceOfHearts, kingOfHearts, queenOfHearts, jackOfHearts, tenOfHearts
        //};
        //private static List<Card> cards7RoyalStraightFlush = new List<Card>(cards5RoyalStraightFlush) { queenOfClubs, twoOfDiamonds };


        //[TestMethod]
        //public void EvaluateHand_RoyalStraightFlush_LessThan5Cards_ReturnsFalse()
        //{
        //    var handEvaluator = new HandEvaluator();
        //    var result = handEvaluator.EvaluateHand(cards2nothing);
        //    var result2 = handEvaluator.EvaluateHand(cards4nothing);
        //    Assert.AreEqual(Hands.Nothing, result.Item2);
        //    Assert.AreEqual(Hands.Nothing, result2.Item2);
        //}

        //[TestMethod]
        //public void EvaluateHand_RoyalStraightFlush_GetsRoyalFlush5_ReturnsTrue()
        //{
        //    var handEvaluator = new HandEvaluator();
        //    var result = handEvaluator.EvaluateHand(cards5RoyalStraightFlush);
        //    Assert.AreEqual(Hands.RoyalStraigtFlush, result.Item2);
        //}

        //[TestMethod]
        //public void EvaluateHand_RoyalStraightFlush_GetsRoyalStraightFlush7_ReturnsTrue()
        //{
        //    var handEvaluator = new HandEvaluator();
        //    var result2 = handEvaluator.EvaluateHand(cards7RoyalStraightFlush);
        //    Assert.AreEqual(Hands.RoyalStraigtFlush, result2.Item2);
        //}
    }
}
