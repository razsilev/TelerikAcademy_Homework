using System;
using System.Collections.Generic;

namespace Poker
{
    public class Hand : IHand
    {
        private const int NUMBER_OF_CARDS_IN_HAND = 5;
        public IList<ICard> cards;

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards 
        { 
            get
            {
                return this.cards;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Givan cards can not be null.");
                }

                if (value.Count != Hand.NUMBER_OF_CARDS_IN_HAND)
                {
                    throw new ArgumentOutOfRangeException("Cards mast be exact FIVE");
                }

                for (int i = 0; i < value.Count; i++)
                {
                    if (value[i] == null)
                    {
                        throw new ArgumentNullException("Givan cards list can not have null value.");
                    }
                }

                this.cards = value;
            }
        }

        public override string ToString()
        {
            return "[ " + string.Join(", ", this.Cards) + " ]";
        }
    }
}
