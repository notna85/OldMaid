using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMaid
{
    //Contains the list of cards to  be used for an Old Maid card game
    class OldMaidCards
    {
        private List<string> cardValues = new List<string>();

        public List<string> CardValues { get; private set; }
        
        //Fills a list with values and returns said list
        public List<string> returnCardList()
        {
            CardValues = new List<string>();
            CardValues.Add("ONE");
            CardValues.Add("ONE");
            CardValues.Add("ONE");
            CardValues.Add("ONE");
            CardValues.Add("TWO");
            CardValues.Add("TWO");
            CardValues.Add("TWO");
            CardValues.Add("TWO");
            CardValues.Add("THREE");
            CardValues.Add("THREE");
            CardValues.Add("THREE");
            CardValues.Add("THREE");
            CardValues.Add("FOUR");
            CardValues.Add("FOUR");
            CardValues.Add("FOUR");
            CardValues.Add("FOUR");
            CardValues.Add("FIVE");
            CardValues.Add("FIVE");
            CardValues.Add("FIVE");
            CardValues.Add("FIVE");
            CardValues.Add("SIX");
            CardValues.Add("SIX");
            CardValues.Add("SIX");
            CardValues.Add("SIX");
            CardValues.Add("SEVEN");
            CardValues.Add("SEVEN");
            CardValues.Add("SEVEN");
            CardValues.Add("SEVEN");
            CardValues.Add("EIGHT");
            CardValues.Add("EIGHT");
            CardValues.Add("EIGHT");
            CardValues.Add("EIGHT");
            CardValues.Add("NINE");
            CardValues.Add("NINE");
            CardValues.Add("NINE");
            CardValues.Add("NINE");
            CardValues.Add("TEN");
            CardValues.Add("TEN");
            CardValues.Add("TEN");
            CardValues.Add("TEN");
            CardValues.Add("JACK");
            CardValues.Add("JACK");
            CardValues.Add("JACK");
            CardValues.Add("JACK");
            CardValues.Add("KING");
            CardValues.Add("KING");
            CardValues.Add("KING");
            CardValues.Add("KING");
            CardValues.Add("OLDMAID");
            return CardValues;
        }
    }
}
