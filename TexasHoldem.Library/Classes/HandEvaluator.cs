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

        public (List<Card>, Hands, Suits) EvaluateHand(List<Card> cards)
        {
            BestCards.Clear();
            HandValue = Hands.Nothing;
            Suit = Suits.Unknown;

            if (cards.Count() >= 2)
            {

            }
            return (BestCards, HandValue, Suit);
        }
    }
}
