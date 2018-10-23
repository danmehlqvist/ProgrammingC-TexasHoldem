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

		private IsStraight isStraight = new IsStraight();

		public (List<Card>, Hands, Suits) EvaluateHand(List<Card> cards)
		{
			BestCards.Clear();
			HandValue = Hands.Nothing;
			Suit = Suits.Unknown;

			if (cards.Count() >= 2)
			{
				cards.Sort();



				var isRoyalOrStraightFlush = new IsRoyalStraightFlush();
				if (isRoyalOrStraightFlush.EvaluateCards(cards))
				{
					BestCards = isRoyalOrStraightFlush.BestCards;
					HandValue = isRoyalOrStraightFlush.HandValue;
					Suit = isRoyalOrStraightFlush.Suit;
				}
				else
				{
					var isFourOfAKind = new IsFourOfAKind();
					if (isFourOfAKind.EvaluateCards(cards))
					{
						BestCards = isFourOfAKind.BestCards;
						HandValue = isFourOfAKind.HandValue;
					}
					else
					{
						var isFullHouse = new IsFullHouse();
						if (isFullHouse.EvaluateCards(cards))
						{
							BestCards = isFullHouse.BestCards;
							HandValue = isFullHouse.HandValue;
						}
						else
						{
							var isFlush = new IsFlush();
							if (isFlush.EvaluateCards(cards))
							{
								BestCards = isFlush.BestCards;
								HandValue = isFlush.HandValue;
								Suit = isFlush.Suit;
							}
							else
							{
								var isStraight = new IsStraight();
								if (isStraight.EvaluateCards(cards))
								{
									BestCards = isStraight.BestCards;
									HandValue = isStraight.HandValue;
								}
								else
								{
									var isThreeOfAKind = new IsThreeOfAKind();
									if (isThreeOfAKind.EvaluateCards(cards))
									{
										BestCards = isThreeOfAKind.BestCards;
										HandValue = isThreeOfAKind.HandValue;

									}
									else
									{
										var isTwoPairs = new IsTwoPairs();
										if (isTwoPairs.EvaluateCards(cards))
										{
											BestCards = isTwoPairs.BestCards;
											HandValue = isTwoPairs.HandValue;

										}
										else
										{
											var isPair = new IsPair();
											if (isPair.EvaluateCards(cards))
											{
												BestCards = isPair.BestCards;
												HandValue = isPair.HandValue;

											}
										}
									}
								}
							}
						}
					}
				}
			}
			return (BestCards, HandValue, Suit);
		}
	}
}
