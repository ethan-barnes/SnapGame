using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnapGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Deck deck;
        Deck playerDeck = new Deck(new List<Card>());
        Deck cpuDeck = new Deck(new List<Card>());

        public MainWindow()
        {
            InitializeComponent();
            SetUpCards();
        }

        private void SetUpCards()
        {
            List<Card> cardList = new List<Card>();
            for (int i = 0; i < 52; i++)
            {
                cardList.Add(new Card(i + 1));
            }
            deck = new Deck(cardList);
            deck.Shuffle();

            for (int j = 0; j < 52; j++)
            {
                if (j < 26)
                {
                    playerDeck.AddCard(deck.GetCardAtPosition(j));
                } 
                else
                {
                    cpuDeck.AddCard(deck.GetCardAtPosition(j));
                }
            }
        }

        private void SnapButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Snapped");
            // PlayerCardImg.Source = new BitmapImage(new Uri(@"/images/playing_cards/1.png", UriKind.Relative));
            
        }

        private void DealButton_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int card = r.Next(1, 52);
            CardImage.Source = new BitmapImage(new Uri($"/images/playing_cards/{card}.png", UriKind.Relative));
        }
    }
}
