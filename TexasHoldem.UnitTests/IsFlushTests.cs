using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.Library.Classes;
using TexasHoldem.Library.Enums;
using TexasHoldem.Library.Structs;

namespace TexasHoldem.UnitTests
{
    [TestClass]
    public class IsFlushTests
    {
        [TestMethod]
        public void EvaluateCards_GetsLessThanFiveCards_ReturnsFalse()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Hearts, Values.Queen),
                new Card(Suits.Spades, Values.Two),
                new Card(Suits.Hearts, Values.Ten),
                new Card(Suits.Hearts, Values.Five)
            };
            var ev = new IsFlush();
            var result = ev.EvaluateCards(cards);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EvaluateCards_GetsFiveCardsWhichAreFlush_ReturnsTrue()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Hearts, Values.Queen),
                new Card(Suits.Hearts, Values.Two),
                new Card(Suits.Hearts, Values.Ten),
                new Card(Suits.Hearts, Values.Five),
                new Card(Suits.Hearts, Values.King)
            };
            cards.Sort();
            var ev = new IsFlush();
            var result = ev.EvaluateCards(cards);
            Assert.IsTrue(result);
            Assert.AreEqual(ev.BestCards.Count, 5);
            Assert.AreEqual(ev.Suit, Suits.Hearts);
        }

        [TestMethod]
        public void EvaluateCards_GetsFiveCardsWhichAreNotFlush_ReturnsFalse()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Spades, Values.Queen),
                new Card(Suits.Hearts, Values.Two),
                new Card(Suits.Hearts, Values.Ten),
                new Card(Suits.Hearts, Values.Five),
                new Card(Suits.Hearts, Values.King)
            };
            cards.Sort();
            var ev = new IsFlush();
            var result = ev.EvaluateCards(cards);
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void EvaluateCards_GetsSevenCardsWhichAreFlush_ReturnsTrue()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Hearts, Values.Queen),
                new Card(Suits.Hearts, Values.Two),
                new Card(Suits.Hearts, Values.Ten),
                new Card(Suits.Spades, Values.Ten),
                new Card(Suits.Hearts, Values.Five),
                new Card(Suits.Hearts, Values.King)
            };

            cards.Sort();
            var ev = new IsFlush();
            var result = ev.EvaluateCards(cards);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EvaluateCards_GetsSevenCardsWhichAreNotFlush_ReturnsFalse()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Hearts, Values.Queen),
                new Card(Suits.Clubs, Values.Two),
                new Card(Suits.Diamonds, Values.Ten),
                new Card(Suits.Spades, Values.Ten),
                new Card(Suits.Hearts, Values.Five),
                new Card(Suits.Hearts, Values.King)
            };
            cards.Sort();
            var ev = new IsFlush();
            var result = ev.EvaluateCards(cards);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EvaluateCards_GetSevenCardsAllTheSameSuit_ReturnsHighestSuit()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Hearts, Values.King),
                new Card(Suits.Hearts, Values.Queen),
                new Card(Suits.Hearts, Values.Ten),
                new Card(Suits.Hearts, Values.Six),
                new Card(Suits.Hearts, Values.Five),
                new Card(Suits.Hearts, Values.Two),
                new Card(Suits.Spades, Values.Ten),
            };

            var lowestCardInStraight = new Card(Suits.Hearts, Values.Five);

            cards.Sort();
            var ev = new IsFlush();
            var result = ev.EvaluateCards(cards);
            Assert.IsTrue(result);
            Assert.AreEqual(ev.HandValue, Hands.Flush);
            Assert.AreEqual(ev.Suit, Suits.Hearts);
            Assert.AreEqual(ev.BestCards[0].Suit, lowestCardInStraight.Suit);
            Assert.AreEqual(ev.BestCards[0].Value, lowestCardInStraight.Value);
        }
    }
}
