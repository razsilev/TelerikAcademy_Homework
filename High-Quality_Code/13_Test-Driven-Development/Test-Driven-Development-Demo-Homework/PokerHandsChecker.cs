using System;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        // implemented task 3
        public bool IsValidHand(IHand hand)
        {
            bool isValid = true;

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                var card = hand.Cards[i];

                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if (card.Face == hand.Cards[j].Face && card.Suit == hand.Cards[j].Suit)
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        // implemented task 5
        public bool IsFourOfAKind(IHand hand)
        {
            var firstFace = hand.Cards[0].Face;
            var secondFace = hand.Cards[1].Face;

            // searsh secondface != firstFace
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Face != firstFace)
                {
                    secondFace = hand.Cards[i].Face;
                    break;
                }
            }

            int firstFaceCount = 0;
            int secondFaceCount = 0;
            int toFourOfAKindNumberOfCards = 4;
            bool isFourOfAKind = false;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (firstFace == hand.Cards[i].Face)
                {
                    firstFaceCount += 1;
                }

                if (secondFace == hand.Cards[i].Face)
                {
                    secondFaceCount += 1;
                }

                if (firstFaceCount == toFourOfAKindNumberOfCards ||
                    secondFaceCount == toFourOfAKindNumberOfCards)
                {
                    isFourOfAKind = true;
                    break;
                }
            }

            return isFourOfAKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        // implemented task 4
        public bool IsFlush(IHand hand)
        {
            bool isFlush = true;
            var suit = hand.Cards[0].Suit;

            for (int i = 1; i < hand.Cards.Count - 1; i++)
            {
                var card = hand.Cards[i];

                if (card.Suit != suit)
                {
                    isFlush = false;
                    break;
                }

            }

            return isFlush;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
