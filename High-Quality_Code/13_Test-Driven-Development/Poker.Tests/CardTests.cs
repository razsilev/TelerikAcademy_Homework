using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace Poker.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CreateCard()
        {
            var card = new Card(CardFace.Five, CardSuit.Hearts);

            Assert.IsNotNull(card, "Can not create card.");
        }

        [TestMethod]
        public void MastGetCardFace()
        {
            var card = new Card(CardFace.Five, CardSuit.Hearts);

            Assert.AreEqual(CardFace.Five, card.Face);
        }

        [TestMethod]
        public void MastGetCardSuit()
        {
            var card = new Card(CardFace.Five, CardSuit.Diamonds);

            Assert.AreEqual(CardSuit.Diamonds, card.Suit);
        }

        [TestMethod]
        public void TestToSting()
        {
            var card = new Card(CardFace.Five, CardSuit.Diamonds);
            var str = card.ToString();
            var expectedString = string.Format("{0} - {1}", CardFace.Five, CardSuit.Diamonds);

            Assert.AreEqual(expectedString, str);
        }

    }
}
