using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TexasHoldem.Library.Classes;
using TexasHoldem.Library.Enums;
using TexasHoldem.Library.Structs;


namespace TexasHoldem.UnitTests
{
    [TestClass]
    public class IsPairTest
    {
        [TestMethod]
        public void EvaluateCards_GetSevenCardsNoPair_ReturnsFalse()
        {
            var nothing = new List<Card>
                {
                    new Card(Suits.Hearts, Values.King),
                    new Card(Suits.Hearts, Values.Queen),
                    new Card(Suits.Spades, Values.Nine),
                    new Card(Suits.Hearts, Values.Six),
                    new Card(Suits.Hearts, Values.Five),
                    new Card(Suits.Hearts, Values.Two),
                    new Card(Suits.Spades, Values.Ten),
                };
            nothing.Sort();

            var ev = new IsPair();
            var result = ev.EvaluateCards(nothing);
            Assert.IsFalse(result);
            Assert.AreEqual(ev.HandValue, Hands.Nothing);
        }


        [TestMethod]
        public void EvaluateCards_GetSevenCardsOnePair_ReturnsTrue()
        {
            var onePair = new List<Card>
                {
                    new Card(Suits.Hearts, Values.King),
                    new Card(Suits.Hearts, Values.Queen),
                    new Card(Suits.Spades, Values.Nine),
                    new Card(Suits.Hearts, Values.Ten),
                    new Card(Suits.Hearts, Values.Five),
                    //new Card(Suits.Hearts, Values.Two),
                    new Card(Suits.Spades, Values.Ten),
                };
            onePair.Sort();

            var ev = new IsPair();
            var result = ev.EvaluateCards(onePair);
            Assert.IsTrue(result);
            Assert.AreEqual(ev.HandValue, Hands.Pair);
        }
    }
}

