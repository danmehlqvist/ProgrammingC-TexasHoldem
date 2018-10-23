using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.Library.Enums;
using TexasHoldem.Library.Structs;

namespace TexasHoldem.Library.Classes
{
  public   class IsFourOfAKind
    {
        public List<Card> BestCards { get; private set; }

        public Hands HandValue { get; private set; }
        
        public bool EvaluateCards(List<Card> cards)
        {
            if (cards.Count < 4)
            {
                return false;
            }
            var tempCards = new List<Card>(cards);

            var indexToCheck = cards.Count / 2;

            if (cards.Count(c=> c.Value== cards[indexToCheck].Value) == 4) // We have four of a kind
            {
                tempCards = cards.Where(c => c.Value != cards[indexToCheck].Value).ToList();
                var highestCard = tempCards[tempCards.Count - 1];
                BestCards = cards.Where(c => c.Value == cards[indexToCheck].Value).ToList();
                BestCards.Add(highestCard);
                HandValue = Hands.FourOfAKind;
                return true;
            }
            return false;
        }

    }
}
