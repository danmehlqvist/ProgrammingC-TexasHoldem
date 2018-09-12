using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.Library.Structs;

namespace TexasHoldem.Library.Classes
{
    public class Hand
    {
        public List<Card> Cards { get; } = new List<Card>();
        public List<Card> PlayerCards { get; } = new List<Card>();
        public List<Card> BestCards { get; } = new List<Card>();

        /// <summary>
        /// Clears the Cards, PlayerCards, and BestCards collections.
        /// </summary>
        public void Clear()
        {
            Cards.Clear();
            PlayerCards.Clear();
            BestCards.Clear();
        }

        public void AddCard(Card card, bool isPlayerCard)
        {
            if (isPlayerCard && PlayerCards.Count<2)
            {
                PlayerCards.Add(card);
            }
            Cards.Add(card);
        }
    }


}
