using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMaid
{
    class Deck
    {
        private List<Card> deckContent = new List<Card>();

        public List<Card> DeckContent { get; private set; }

        //Constructor creates a list of Card objects and puts them in a list
        public Deck(List<string> cardvalues)
        {
            DeckContent = new List<Card>();
            foreach(string value in cardvalues)
            {
                DeckContent.Add(new Card(value));
            }
        }
    }
}
