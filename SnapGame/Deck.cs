using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapGame
{
    class Deck
    {
        readonly Random r = new();
        private List<Card> Cards;
        
        public Deck(List<Card> cards)
        {
            Cards = cards;
        }

        public List<Card> GetCards()
        {
            return Cards;
        }

        public int GetSize()
        {
            return Cards.Count;
        }

        public Card GetCardAtPosition(int pos)
        {
            if (Cards != null)
            {
                return Cards[pos];
            } 
            else
            {
                throw new Exception("Deck is empty.");
            }
        }

        public bool CheckSnap()
        {
            List<Card> last2 = Cards.TakeLast(2).ToList();
            if (last2[0].GetSuit() == last2[1].GetSuit() || last2[0].GetValue() == last2[1].GetValue())
            {
                return true;
            }
            return false;
        }

        public void SetCards(List<Card> cards)
        {
            Cards = cards;
        }

        public void AddCard(Card card)
        {
           if (Cards.Contains(card)) throw new Exception("Card already in deck.");            
           
           Cards.Add(card);            
        }

        public void AddCards(List<Card> cards)
        {
            Cards.AddRange(cards);
        }

        public Card Draw()
        {
            int cardNum = r.Next(1, Cards.Count());
            Card card = Cards[cardNum];
            Cards.Remove(card);
            return card;
        }

        public void Shuffle()
        {
            Cards = Cards.OrderBy(x => r.Next()).ToList();
        }
    }
}
