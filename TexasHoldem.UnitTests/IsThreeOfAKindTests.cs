using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TexasHoldem.Library.Classes;
using TexasHoldem.Library.Enums;
using TexasHoldem.Library.Structs;

namespace TexasHoldem.UnitTests
{
    [TestClass]
    public class IsThreeOfAKindTests
    {
        [TestMethod]
        public void EvaluateCards_GetsTwoCards_ReturnsFalse()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Hearts, Values.Queen),
                new Card(Suits.Spades, Values.Two),
            };
            var ev = new IsThreeOfAKind();
            var result = ev.EvaluateCards(cards);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EvaluateCards_GetsFiveCardsNotThreeOfAKind_ReturnsFalse()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Hearts, Values.Queen),
                new Card(Suits.Spades, Values.Six),
                new Card(Suits.Hearts, Values.Ten),
                new Card(Suits.Hearts, Values.Five),
                new Card(Suits.Clubs, Values.Five)
            };

            var ev = new IsThreeOfAKind();
            var result = ev.EvaluateCards(cards);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void EvaluateCards_GetsFiveCardsIsThreeOfAKind_ReturnsFalse()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Hearts, Values.Queen),
                new Card(Suits.Spades, Values.Five),
                new Card(Suits.Hearts, Values.Ten),
                new Card(Suits.Hearts, Values.Five),
                new Card(Suits.Clubs, Values.Five)
            };

            var ev = new IsThreeOfAKind();
            var result = ev.EvaluateCards(cards);
            Assert.IsTrue(result);
            Assert.AreEqual(ev.HandValue, Hands.ThreeOfAKind);
            Assert.AreEqual(ev.BestCards.Count, 5);
        }

        [TestMethod]
        public void EvaluateCards_GetsSevenCardsNotThreeOfAKind_ReturnsFalse()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Hearts, Values.Queen),
                new Card(Suits.Spades, Values.Six),
                new Card(Suits.Hearts, Values.Ten),
                new Card(Suits.Hearts, Values.Five),
                new Card(Suits.Hearts, Values.Three),
                new Card(Suits.Hearts, Values.Four),
                new Card(Suits.Clubs, Values.Five)
            };

            var ev = new IsThreeOfAKind();
            var result = ev.EvaluateCards(cards);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EvaluateCards_GetsSevenCardsIsThreeOfAKind_ReturnsTrue()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Hearts, Values.Queen),
                new Card(Suits.Spades, Values.Five),
                new Card(Suits.Hearts, Values.Ten),
                new Card(Suits.Hearts, Values.Five),
                new Card(Suits.Hearts, Values.Three),
                new Card(Suits.Hearts, Values.Four),
                new Card(Suits.Clubs, Values.Five)
            };

            var ev = new IsThreeOfAKind();
            var result = ev.EvaluateCards(cards);
            Assert.IsTrue(result);
            Assert.AreEqual(ev.BestCards.Count, 5);
            Assert.AreEqual(ev.HandValue, Hands.ThreeOfAKind);
        }
    }
}
