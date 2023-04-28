using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace C__Blackjack
{
    internal class Dealer : Player
    {
        private PlayCards deck;

        public Dealer() : base("Dealer")
        {
            deck = new PlayCards();
            deck.ShuffleDeck();
        }

        public Card getCard()
        {
            return this.deck.NextCard();
        }
    }
}