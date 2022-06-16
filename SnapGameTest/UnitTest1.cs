using NUnit.Framework;
using SnapGame;
using System.Collections.Generic;

namespace SnapGameTest
{
    public class Tests
    {
        List<Card> cardList = new();
        Deck deck;
        Deck deck2;

        [SetUp]
        public void Setup()
        {
            // Create card list
            for (int i = 0; i < 52; i++)
            {
                if (i < 13)
                {
                    cardList.Add(new Card(i + 1, (Value)i, Suit.Spade));
                }
                else if (i < 26)
                {
                    int x = i - 13;
                    cardList.Add(new Card(x + 1, (Value)x, Suit.Club));
                }
                else if (i < 39)
                {
                    int x = i - 26;
                    cardList.Add(new Card(x + 1, (Value)x, Suit.Heart));
                }
                else
                {
                    int x = i - 39;
                    cardList.Add(new Card(x + 1, (Value)x, Suit.Diamond));
                }
            }
        }

        [Test]
        public void TestDeckShuffle()
        {
            deck = new Deck(cardList);
            deck2 = new Deck(cardList);
            deck.Shuffle();

            if (deck.GetCards() == deck2.GetCards())
            {
                Assert.Fail("Deck should be in a different order after shuffle.");
            }
            else
            {
                Assert.Pass();
            }          
        }

        [Test]
        public void TestDeckCheckSnap()
        {

        }


    }
}