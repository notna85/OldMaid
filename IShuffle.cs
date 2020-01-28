using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMaid
{
    interface IShuffle<T>
    {
        T shuffleCards(T cards);
    }
}
