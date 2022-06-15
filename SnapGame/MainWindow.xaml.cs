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
        private int playerScore;
        private int cpuScore;
        private Random r = new Random();
        private int turnCounter = 0;
        Deck deck;
        Deck playerDeck = new Deck(new List<Card>());
        Deck cpuDeck = new Deck(new List<Card>());
        Deck pile = new Deck(new List<Card>());

        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void updateScores()
        {
            playerScore = playerDeck.GetSize();
            cpuScore = cpuDeck.GetSize();
            PlayerScoreValue.Text = playerScore.ToString();
            CpuScoreValue.Text = cpuScore.ToString();
        }

        // Shuffles a new deck of cards and deals these to the player and computer.
        private void SetUpGame()
        {
            // Creates a new deck and shuffles it.
            List<Card> cardList = new();
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
            deck = new Deck(cardList);
            deck.Shuffle();

            // Distributes shuffled deck to player and CPU.
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

            // First to 52 wins so decksize is used as score.
            playerScore = playerDeck.GetSize();
            cpuScore = cpuDeck.GetSize();
            updateScores();
        }

        private void SnapButton_Click(object sender, RoutedEventArgs e)
        {
            if (pile.CheckSnap())
            {
                MessageBox.Show("Correct");
                playerScore += pile.GetSize();
                playerDeck.AddCards(pile.GetCards());
            }
            else
            {
                MessageBox.Show("Wrong");
                cpuScore += pile.GetSize();
                cpuDeck.AddCards(pile.GetCards());
            }
            pile.SetCards(new List<Card>());
            updateScores();
        }

        private void DealButton_Click(object sender, RoutedEventArgs e)
        {
            // Draws card from either player or CPU depending on turn counter.
            Card card = turnCounter % 2 == 0 ? playerDeck.Draw() : cpuDeck.Draw();

            pile.AddCard(card);
            CardImage.Source = card.GetImage();
            //CardImage.Source = new BitmapImage(new Uri($"/images/playing_cards/{card.GetId()}.png", UriKind.Relative));

            updateScores();
            turnCounter++;
        }
    }
}
