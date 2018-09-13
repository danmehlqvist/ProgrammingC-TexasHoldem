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
    public class Hand
    {
        public List<Card> Cards { get; } = new List<Card>();

        public List<Card> PlayerCards { get; } = new List<Card>();

        public List<Card> BestCards { get; } = new List<Card>();

        public Hands HandValue { get; private set; }

        public Suits Suit { get; private set; }

        private IHandEvaluator _eval;

        public Hand(IHandEvaluator Eval)
        {
            _eval = Eval;
        }

        /// <summary>
        /// Clears the Cards, PlayerCards, and BestCards collections.
        /// </summary>
        public void Clear()
        {
            Cards.Clear();
            PlayerCards.Clear();
            BestCards.Clear();
            HandValue = Hands.Nothing;
            Suit = Suits.Unknown;
        }

        public void AddCard(Card card, bool isPlayerCard)
        {
            if (isPlayerCard && PlayerCards.Count<2)
            {
                PlayerCards.Add(card);
            }
            Cards.Add(card);
        }

        public void EvaluateHand()
        {
            if (Cards.Count < 2)
            {
                return;
            }
            var Evaluation = _eval.EvaluateHand(Cards);
            foreach(var card in Evaluation.Item1)
            {
                BestCards.Add(card);
            }
            HandValue = Evaluation.Item2;
            Suit = Evaluation.Item3;
        }
    }


}
