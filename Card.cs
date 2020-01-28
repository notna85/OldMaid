using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMaid
{
    class Card
    {
        private string cardValue;
        public string CardValue { get; set; }

        public Card(string cardValue)
        {
            CardValue = cardValue;
        }
    }
}
