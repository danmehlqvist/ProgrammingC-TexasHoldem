using System;
using System.Collections.Generic;
using TexasHoldem.Library.Enums;
using TexasHoldem.Library.Structs;

namespace TexasHoldem.Library.Classes
{
    public class Deck
    {
        private List<Card> _cards;

        public Deck()
        {
            _cards = new List<Card>();
        }

        /// <summary>
        /// Shuffles the deck noOfShuffles times. 
        /// </summary>
        /// <param name="noOfShuffles"></param>
        public void ShuffleDeck(int noOfShuffles=7)
        // According to Bayer and Diaconis seven is the amount of shuffles required for a random deck
        {
            NewDeck();
            var rnd = new Random();
            for (int ii = 0; ii < noOfShuffles; ii++)
            {
                var tempDeck = new List<Card>();
                while (_cards.Count != 0)
                {
                    var index = rnd.Next(_cards.Count);
                    var card = _cards[index];
                    _cards.Remove(card);
                    tempDeck.Add(card);
                }
                _cards = tempDeck;
            }
        }

        public Card DrawCard()
        {
            var card = _cards[0];
            _cards.Remove(card);
            return card;
        }

        /// <summary>
        /// Creates a new un-shuffled deck
        /// </summary>
        private void NewDeck()
        {
            _cards.Clear();
            foreach (var suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (var value in Enum.GetValues(typeof(Values)))
                {
                    if (suit.Equals(Suits.Unknown))
                    {
                        continue;
                    }
                    _cards.Add(new Card((Suits)suit, (Values)value));
                }
            }


        }
    }
}
