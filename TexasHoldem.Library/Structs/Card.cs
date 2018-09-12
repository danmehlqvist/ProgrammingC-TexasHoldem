using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.Library.Enums;

namespace TexasHoldem.Library.Structs
{
    public struct Card:IComparable
    {
        /// <summary>
        /// Constructor. Needs suit and value
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="value"></param>
        public Card(Suits suit, Values value)
        {
            Value = value;
            Suit = suit;
        }
        
        public Values Value { get; }
        public Suits Suit { get; }

        public string Output
        {
            get
            {
                var value = (int)Value <= 10 ? ((int)Value).ToString() : Value.ToString().Substring(0, 1);
                return $"{(char)Suit}\n{value}";
            }
        }

        public int CompareTo(object obj)
        {
            var card = (Card)obj;
            if (Value > card.Value)
            {
                return 1;
            }

            if (Value == card.Value)
            {
                return 0;
            }
            return -1;
        }
    }
}