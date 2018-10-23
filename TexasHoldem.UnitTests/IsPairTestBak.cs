using System.Collections.Generic;

namespace TexasHoldem.UnitTests
{


    //var onePair = new List<Card>
    //            {
    //                new Card(Suits.Hearts, Values.King),
    //                new Card(Suits.Hearts, Values.Queen),
    //                new Card(Suits.Hearts, Values.Ten),
    //                new Card(Suits.Hearts, Values.Six),
    //                new Card(Suits.Hearts, Values.Five),
    //                new Card(Suits.Hearts, Values.Two),
    //                new Card(Suits.Spades, Values.Ten),
    //            };



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

            var ev = new IsFlush();
            var result = ev.EvaluateCards(nothing);
            Assert.IsFalse(result);
            Assert.AreEqual(ev.HandValue, Hands.Pair);
        }
    }
}
