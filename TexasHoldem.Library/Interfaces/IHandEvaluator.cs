using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.Library.Enums;
using TexasHoldem.Library.Structs;

namespace TexasHoldem.Library.Interfaces
{
    public interface IHandEvaluator
    {
        (List<Card>, Hands, Suits) EvaluateHand(List<Card> cards);  
    }
}
