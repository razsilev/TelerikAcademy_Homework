namespace JustBelot.AI.OscorpIT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using JustBelot.Common;
    using JustBelot.Common.Extensions;

    public class OscorpIT : IPlayer
    {
        //static void Main(string[] args)
        //{
        //}

        public OscorpIT() : this("OscorpIT")
        {
        }

        public OscorpIT(string name, bool alwaysPass = true)
        {
            this.Name = name;
            this.AlwaysPass = alwaysPass;
        }

        public string Name { get; protected set; }

        public bool AlwaysPass { get; set; }

        public void StartNewGame(GameInfo gameInfo, PlayerPosition position)
        {
            //throw new NotImplementedException();
        }

        public void StartNewDeal(DealInfo dealInfo)
        {
            //throw new NotImplementedException();
        }

        public void AddCards(IEnumerable<Card> cards)
        {
            //throw new NotImplementedException();
        }

        public BidType AskForBid(Contract currentContract, IList<BidType> allowedBids, IList<BidType> previousBids)
        {
            return allowedBids.First();
        }

        public IEnumerable<CardsCombination> AskForCardsCombinations(IEnumerable<CardsCombination> allowedCombinations)
        {
            return allowedCombinations;
        }

        public PlayAction PlayCard(IList<Card> allowedCards, IList<Card> currentTrickCards)
        {
            return new PlayAction(allowedCards.First());
        }

        public void EndOfDeal(DealResult dealResult)
        {
            //throw new NotImplementedException();
        }
    }
}
