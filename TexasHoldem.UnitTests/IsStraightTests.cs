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
    public class IsStraightTests
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
            var ev = new IsStraight();
            var result = ev.EvaluateCards(cards);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EvaluateCards_GetsFiveCardsThatIsStraight_ReturnsTrue()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Hearts, Values.Queen),
                new Card(Suits.Diamonds, Values.Jack),
                new Card(Suits.Spades, Values.Ten),
                new Card(Suits.Hearts, Values.Nine),
                new Card(Suits.Hearts, Values.Eight),
            };
            cards.Sort();
            var ev = new IsStraight();
            var result = ev.EvaluateCards(cards);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EvaluateCards_GetsSevenCardsThatIsStraight_ReturnsTrue_v1()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Hearts, Values.Queen),
                new Card(Suits.Diamonds, Values.Jack),
                new Card(Suits.Spades, Values.Ten),
                new Card(Suits.Hearts, Values.Nine),
                new Card(Suits.Hearts, Values.Eight),
                new Card(Suits.Diamonds, Values.Eight),
                new Card(Suits.Spades, Values.Eight)

            };
            cards.Sort();
            var ev = new IsStraight();
            var result = ev.EvaluateCards(cards);
            Assert.IsTrue(result);
            Assert.AreEqual(ev.BestCards.Count, 5);
            Assert.AreEqual(ev.HandValue, Hands.Straight);
        }

        [TestMethod]
        public void EvaluateCards_GetsSevenCardsThatIsStraight_ReturnsTrue_v2()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Hearts, Values.Ace),
                new Card(Suits.Diamonds, Values.Queen),
                new Card(Suits.Hearts, Values.Queen),
                new Card(Suits.Diamonds, Values.Jack),
                new Card(Suits.Spades, Values.Ten),
                new Card(Suits.Hearts, Values.Nine),
                new Card(Suits.Hearts, Values.Eight),
            };
            cards.Sort();
            var ev = new IsStraight();
            var result = ev.EvaluateCards(cards);
            Assert.IsTrue(result);
            Assert.AreEqual(ev.BestCards.Count, 5);
            Assert.AreEqual(ev.HandValue, Hands.Straight);
        }

        [TestMethod]
        public void EvaluateCards_GetsSevenCardsThatIsStraight_ReturnsTrue_v3()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Hearts, Values.Queen),
                new Card(Suits.Diamonds, Values.Jack),
                new Card(Suits.Spades, Values.Ten),
                new Card(Suits.Diamonds, Values.Ten),
                new Card(Suits.Spades, Values.Nine),
                new Card(Suits.Hearts, Values.Nine),
                new Card(Suits.Hearts, Values.Eight),

            };
            cards.Sort();
            var ev = new IsStraight();
            var result = ev.EvaluateCards(cards);
            Assert.IsTrue(result);
            Assert.AreEqual(ev.BestCards.Count, 5);
            Assert.AreEqual(ev.HandValue, Hands.Straight);
        }

        [TestMethod]
        public void EvaluateCards_GetsFiveCardsThatNothing_ReturnsFalse()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Hearts, Values.Queen),
                new Card(Suits.Diamonds, Values.Jack),
                new Card(Suits.Spades, Values.Ten),
                new Card(Suits.Diamonds, Values.Ten),
                new Card(Suits.Spades, Values.Nine),

            };
            cards.Sort();
            var ev = new IsStraight();
            var result = ev.EvaluateCards(cards);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EvaluateCards_GetsSevenCardsThatNothing_ReturnsFalse()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Diamonds, Values.Ace),
                new Card(Suits.Hearts, Values.Queen),
                new Card(Suits.Spades, Values.Ten),
                new Card(Suits.Diamonds, Values.Ten),
                new Card(Suits.Spades, Values.Nine),
                new Card(Suits.Hearts, Values.Nine),
                new Card(Suits.Clubs, Values.Nine),

            };
            cards.Sort();
            var ev = new IsStraight();
            var result = ev.EvaluateCards(cards);
            Assert.IsFalse(result);
        }

    }
}
