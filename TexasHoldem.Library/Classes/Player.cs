using System.Collections.Generic;
using TexasHoldem.Library.Enums;
using TexasHoldem.Library.Structs;

namespace TexasHoldem.Library.Classes
{
    public class Player
    {
        private Hand _hand;

        public string Name { get; }

        public List<Card> Cards { get { return _hand.Cards; } }

        public List<Card> BestCards { get { return _hand.BestCards; } }

        public List<Card> PlayerCards { get { return _hand.PlayerCards; } }

        public int CardCount { get { return Cards.Count; } }

        public Hands HandValue { get { return _hand.HandValue; } }

        public Suits Suit { get { return _hand.Suit; } }

		//public int Score { get; set; }

        public Player(string name)
        {
            Name = name;
            _hand = new Hand(new HandEvaluator());
        }

        public void ReceiveCard(Card card,bool isPlayerCard=false)
        {
            _hand.AddCard(card, isPlayerCard);
        }

        public void ClearHand()
        {
            _hand.Clear();
        }

        public void EvaluateHand()
        {
            _hand.EvaluateHand();
        }
    }
}
