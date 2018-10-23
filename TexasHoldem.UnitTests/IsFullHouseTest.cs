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
    public class IsFullHouseTest
    {
        [TestMethod]
        public void EvaluateCards_GetsFiveCardsWhichAreNotFullHouse_ReturnsFalse()
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
            var ev = new IsFullHouse();
            var result = ev.EvaluateCards(cards);
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void EvaluateCards_GetsSevenCardsWhichAreNotFullHouse_ReturnsFalse()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Spades, Values.Queen),
                new Card(Suits.Hearts, Values.Two),
                new Card(Suits.Hearts, Values.Ten),
                new Card(Suits.Hearts, Values.Five),
                new Card(Suits.Hearts, Values.King),
                new Card(Suits.Clubs, Values.Five),
                new Card(Suits.Clubs, Values.King)
            };
            cards.Sort();
            var ev = new IsFullHouse();
            var result = ev.EvaluateCards(cards);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EvaluateCards_GetsTwoCards_ReturnsFalse()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Spades, Values.Queen),
                new Card(Suits.Hearts, Values.Two),
            };
            cards.Sort();
            var ev = new IsFullHouse();
            var result = ev.EvaluateCards(cards);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void EvaluateCards_GetsFiveCardsWhichAreFullHouse_ReturnsTrue()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Spades, Values.Queen),
                new Card(Suits.Hearts, Values.Queen),
                new Card(Suits.Hearts, Values.Ten),
                new Card(Suits.Clubs, Values.Queen),
                new Card(Suits.Clubs, Values.Ten)
            };
            cards.Sort();
            var ev = new IsFullHouse();
            var result = ev.EvaluateCards(cards);
            Assert.IsTrue(result);
            Assert.AreEqual(ev.HandValue, Hands.FullHouse);
            Assert.AreEqual(ev.BestCards.Count, 5);
        }


        [TestMethod]
        public void EvaluateCards_GetsSevenCardsWhichAreFullHouse_ReturnsTrue()
        {
            var cards = new List<Card>
            {
                new Card(Suits.Hearts, Values.King),
                new Card(Suits.Clubs, Values.King),
                new Card(Suits.Diamonds, Values.King),
                new Card(Suits.Spades, Values.Queen),
                new Card(Suits.Hearts, Values.Five),
                new Card(Suits.Clubs, Values.Five),
                new Card(Suits.Hearts, Values.Two)
            };
            cards.Sort();
            var ev = new IsFullHouse();
            var result = ev.EvaluateCards(cards);
            Assert.IsTrue(result);
            Assert.AreEqual(ev.HandValue, Hands.FullHouse);
            Assert.AreEqual(ev.BestCards.Count, 5);
        }

    }
}
