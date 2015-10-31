using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Poker;

namespace Poker.Tests
{
    [TestClass]
    public class PokerHandsCheckerTests
    {
        // test valid hand
        [TestMethod]
        public void TestIsValidHandWithValidHand()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            var cards = GenerateCorectCards();
            var hand = new Hand(cards);

            bool isValid = checker.IsValidHand(hand);

            Assert.IsTrue(isValid, "Hand is valid and result mast be true.");
        }

        [TestMethod]
        public void TestIsValidHandWithInvalidHand()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            var cards = GenerateCorectCards();
            
            cards[0] = cards[1];

            var hand = new Hand(cards);

            bool isValid = checker.IsValidHand(hand);

            Assert.IsFalse(isValid, "Hand is invalid and result mast be False.");
        }

        // test flush
        [TestMethod]
        public void TestIsFlushHandWithValidFlush()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            var cards = GenerateCorectCards();

            // make all cards suit hearts
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i] = new Card(cards[i].Face, CardSuit.Hearts);
            }

            var hand = new Hand(cards);

            bool isflush = checker.IsFlush(hand);

            Assert.IsTrue(isflush, "Hand is valid flush and result mast be true.");
        }

        [TestMethod]
        public void TestIsFlushHandWithInvalidFlush()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            var cards = GenerateCorectCards();
            var hand = new Hand(cards);
            bool isflush = checker.IsFlush(hand);

            Assert.IsFalse(isflush, "Hand is invalid flush and result mast be false.");
        }

        // test IsFourOfAKind
        [TestMethod]
        public void TestIsFourOfAKindHandEndWithValidFourOfAKind()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            var cards = GenerateCorectCards();

            // make last 4 cards face Queen
            for (int i = 1; i < cards.Count; i++)
            {
                cards[i] = new Card(CardFace.Queen, cards[i].Suit);
            }

            var hand = new Hand(cards);

            bool isFourOfAKind = checker.IsFourOfAKind(hand);

            Assert.IsTrue(isFourOfAKind, "Hand is valid isFourOfAKind and result mast be true.");
        }

        [TestMethod]
        public void TestIsFourOfAKindHandStartWithValidFourOfAKind()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            var cards = GenerateCorectCards();

            // make first 4 cards face Queen
            for (int i = 0; i < cards.Count - 1; i++)
            {
                cards[i] = new Card(CardFace.Queen, cards[i].Suit);
            }

            var hand = new Hand(cards);

            bool isFourOfAKind = checker.IsFourOfAKind(hand);

            Assert.IsTrue(isFourOfAKind, "Hand is valid isFourOfAKind and result mast be true.");
        }

        [TestMethod]
        public void TestIsFourOfAKindHandWithInvalidFourOfAKind()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            var cards = GenerateCorectCards();
            var hand = new Hand(cards);
            bool isFourOfAKind = checker.IsFourOfAKind(hand);

            Assert.IsFalse(isFourOfAKind, "Hand is invalid flush and result mast be false.");
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
