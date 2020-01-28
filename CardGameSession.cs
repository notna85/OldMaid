using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMaid
{
    class CardGameSession
    {
        private Player player;
        private Deck deck;
        public List<Player> Player { get; set; }
        public Deck Deck { get; set; }

        //Constructor creates a number of players and a deck
        public CardGameSession(List<string> cardvalues, int playerCount)
        {
            Player = new List<Player>();
            for(int i=1; i<=playerCount; i++)
            {
                Player.Add(new Player("Player"+ i));
            }
            Deck = new Deck(cardvalues);
        }

    }
}
