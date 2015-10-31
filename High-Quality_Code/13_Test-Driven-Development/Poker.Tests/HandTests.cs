using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Poker;

namespace Poker.Tests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void CreateHand()
        {
            IList<ICard> cards = GenerateCorectCards();

            Hand hand = new Hand(cards);

            Assert.IsNotNull(hand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CanNotCreateHandWithNullCards()
        {
            Hand hand = new Hand(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NumberOfCardsInHandMastBeExactFive()
        {
            IList<ICard> cards = GenerateCorectCards();
            cards.RemoveAt(4);

            Hand hand = new Hand(cards);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CanNotCreateHandWithListOfNullCards()
        {
            IList<ICard> cards = GenerateCorectCards();
            cards.RemoveAt(4);
            cards.Add(null);

            Hand hand = new Hand(cards);
        }

        [TestMethod]
        public void GivenCardsMastBeequalWithThisInHand()
        {
            IList<ICard> cards = GenerateCorectCards();
            
            Hand hand = new Hand(cards);

            Assert.AreEqual(cards, hand.Cards);
        }

        [TestMethod]
        public void TestToStrong()
        {
            IList<ICard> cards = GenerateCorectCards();

            Hand hand = new Hand(cards);
            var str = hand.ToString();
            var expectedString = "[ " + string.Join(", ", cards) + " ]";

            Assert.AreEqual(expectedString, str);
        }

        private List<ICard> GenerateCorectCards()
        {
            List<ICard> cards = new List<ICard>();

            cards.Add(new Card(CardFace.Nine, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Four, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Spades));

            return cards;
        }
    }
}
