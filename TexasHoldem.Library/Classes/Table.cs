using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldem.Library.Enums;

namespace TexasHoldem.Library.Classes
{
    public class Table
    {
        private Deck _deck;

        public List<Player> Players { get; } = new List<Player>();

        public Player Dealer { get; } = new Player("Dealer");

        public Table(string[] playerNames)
        {
            _deck = new Deck();

            bool isNull = playerNames == null;
            bool lessThanTwo = playerNames.Length < 2;
            bool moreThanFour = playerNames.Length > 4;
            if (isNull || lessThanTwo || moreThanFour)
            {
                throw new ArgumentException("Incorrect number of players!");
            }
            else
            {
                foreach (string player in playerNames)
                {
                    Players.Add(new Player(player));
                }
            }
        }

        public void DealNewHand()
        {
            _deck.ShuffleDeck();
            Dealer.ClearHand();
            DealPlayerCards();
        }

        public void DealPlayerCards()
        {
            foreach(var player in Players)
            {
                player.ClearHand();
                player.ReceiveCard(_deck.DrawCard(), true);
                player.ReceiveCard(_deck.DrawCard(), true);
            }
        }

        public void DealerDrawsCard(int count = 1)
        {
            if(Dealer.CardCount == 5)
            {
                return;
            }

            for (int ii=0; ii < count; ii++)
            {
                var card = _deck.DrawCard();
                Dealer.ReceiveCard(card);
                foreach(var player in Players)
                {
                    player.ReceiveCard(card);
                }
            }
        }

        public void EvaluatePlayerHands()
        {
            foreach(var player in Players)
            {
                player.EvaluateHand();
            }
        }

		public List<Player> DetermineWinner()
		{
			List<Player> ranking = Players.OrderBy(x => (int)x.HandValue).Reverse().ToList();

			List<Player> winners = ranking.Where(x => (int)x.HandValue == (int)ranking[0].HandValue).ToList();

			return winners;
		}

		private int scoreHand(Player player)
		{
			return (int)player.HandValue;
		}

	}

}
