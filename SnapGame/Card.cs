using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SnapGame
{
    class Card
    {
        private int id;
        private Value value;
        private Suit suit;
        private BitmapImage image;

        public Card(int id, Value value, Suit suit)
        {
            this.id = id;
            this.value = value;
            this.suit = suit;
            image = new BitmapImage(new Uri($@"/images/playing_cards/{value.ToString().ToLower()}{suit.ToString().ToLower()}.png", UriKind.Relative));
        }

        public BitmapImage GetImage()
        {
            return image;
        }

        public int GetId()
        {
            return id;
        }
        
        public Suit GetSuit()
        {
            return suit;
        }

        public Value GetValue()
        {
            return value;
        }
    }
}
