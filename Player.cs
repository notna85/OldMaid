using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMaid
{
    class Player
    {
        private string playerName;
        private List<Card> cardHand = new List<Card>();
        public string PlayerName { get; set; }
        public List<Card> CardHand { get; set; }

        public Player(string playerName)
        {
            CardHand = new List<Card>();
            PlayerName = playerName;
        }

    }
}
