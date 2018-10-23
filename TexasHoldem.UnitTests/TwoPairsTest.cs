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
    public class TwoPairsTest
    {
        [TestMethod]
        public void EvaluateCards_GetSevenCardsNothing_ReturnsFalse()
        {
            var nothing = new List<Card>
                {
                    new Card(Suits.Hearts, Values.King),
                    new Card(Suits.Hearts, Values.Queen),
                    new Card(Suits.Spades, Values.Nine),
                    new Card(Suits.Hearts, Values.Six),
                    new Card(Suits.Hearts, Values.Five),
                    new Card(Suits.Spades, Values.Ten),
                    new Card(Suits.Hearts, Values.Two),
                };
            nothing.Sort();

            var ev = new IsTwoPairs();
            var result = ev.EvaluateCards(nothing);

            Assert.IsFalse(result);
            Assert.AreEqual(ev.HandValue, Hands.Nothing);
        }
    }
}
