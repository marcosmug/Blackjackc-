using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace C__Blackjack
{
    public class BlackjackGame
    {
        private PlayCards _deck;
        private Dealer _dealerHand;
        private List<Player> _players;



        public BlackjackGame(int numPlayers)
        {
            _deck = new PlayCards();
            _deck.ShuffleDeck();

            _dealerHand = new Dealer();

            _players = new List<Player>();
            for (int i = 0; i < numPlayers; i++)
            {
                Console.WriteLine($"voer je naam in {i + 1}; ");
                string? name = Console.ReadLine();
                _players.Add(new Player(name));

            }
        }

        public void start()
        {
            foreach (Player player in _players)
            {
                player.Cards.Add(_dealerHand.getCard());
                player.Cards.Add(_dealerHand.getCard());

                Console.WriteLine($"{player.Name}: " + string.Join(", ", player.Cards) + $" totaal: {player.GetPoints()}");
            }
            _dealerHand.Cards.Add(_dealerHand.getCard());



            foreach (Player player in _players)
            {
                Console.WriteLine();
                while (true)
                {
                    Console.WriteLine($"{player.Name} grab a card? (y/n) ");
                    ConsoleKey choice = Console.ReadKey(true).Key;

                    if (choice == ConsoleKey.Y)
                    {
                        player.Cards.Add(_dealerHand.getCard());
                        Console.WriteLine($"{player.Name}: " + string.Join(", ", player.Cards) + $" totaal: {player.GetPoints()}");


                        if (player.GetPoints() > 21)
                        {
                            Console.WriteLine("Higher then 21 you cant pick up more cards >:(");

                            Console.WriteLine($"{player.Name}: " + string.Join(", ", player.Cards) + $" totaal: {player.GetPoints()}");
                            break;
                        }
                    }
                    else if (choice == ConsoleKey.N)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Cant press that key, try again :)");
                    }
                }
            }
            while (_dealerHand.GetPoints() < 17)
            {
                _dealerHand.Cards.Add(_dealerHand.getCard());
            }

            Console.WriteLine($"{_dealerHand.Name}: " + string.Join(", ", _dealerHand.Cards) + $" totaal: {_dealerHand.GetPoints()}");

            foreach (Player player in _players)
            {
                player.ComparePointsToDealer(_dealerHand);

                if (player.HasWonRound)
                {
                    Console.WriteLine($"{player.Name} won");
                }

                else if (player.HasLostRound)
                {
                    Console.WriteLine($"{player.Name} lost");
                }
                else
                {
                    Console.WriteLine($"{player.Name} tied");
                }

            }
        }
    }
}