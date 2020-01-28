using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMaid
{
    class OldMaidController : IShuffle<CardGameSession>
    {
        //Shuffles the elements of a given list and returns the shuffled list
        public CardGameSession shuffleCards(CardGameSession cgSession)
        {
            Random randomCard = new Random();
            for(int i = 0; i < 100; i++)
            {
                int randomCardIndex = randomCard.Next(0, cgSession.Deck.DeckContent.Count());
                Card cardToMove = cgSession.Deck.DeckContent[randomCardIndex];
                cgSession.Deck.DeckContent.RemoveAt(randomCardIndex);
                cgSession.Deck.DeckContent.Add(cardToMove);
            }
            return cgSession;
        }

        //Deals out cards to all the players, one card per player at a time, until the deck is empty
        public CardGameSession dealCards(CardGameSession cgSession)
        {
            //Variable to store index of the player to be dealt a card
            int currentPlayer = 0;
            for (int deckIndex = 0; deckIndex < cgSession.Deck.DeckContent.Count(); deckIndex++)
            {
                //If variable exceeds last index, set it to 0
                if (currentPlayer == cgSession.Player.Count())
                {
                    currentPlayer = 0;
                }       
                cgSession.Player[currentPlayer].CardHand.Add(cgSession.Deck.DeckContent[deckIndex]);
                //Increments index to move to the next player
                currentPlayer++;
            }
            //Steps through each players hand and calls the discardPairs method to remove pairs from their hand
            for(int playerIndex = 0; playerIndex < cgSession.Player.Count(); playerIndex++)
            {
                cgSession.Player[playerIndex].CardHand = discardPairs(cgSession.Player[playerIndex].CardHand);
            }
            return cgSession;
        }

        //Plays a round of the cardgame. If only 1 player remains after a round, returns name of that player
        public CardGameSession playRound(CardGameSession cgSession)
        {            
            int playerCount = cgSession.Player.Count();
            for(int playerIndex = 0; playerIndex < playerCount; playerIndex++)
            {
                int playerToDrawFromIndex = playerIndex - 1;
                if(playerIndex == 0)
                {
                    playerToDrawFromIndex = playerCount - 1;
                }
                Player playerToDrawFrom = cgSession.Player[playerToDrawFromIndex];
                Player playerToDraw = cgSession.Player[playerIndex];
               
                int chosenCardIndex = drawCard(cgSession.Player[playerIndex].PlayerName, playerToDrawFrom.CardHand);
                Card drawnCard = playerToDrawFrom.CardHand[chosenCardIndex];

                cgSession.Player[playerToDrawFromIndex].CardHand = subtractCardFromHand(playerToDrawFrom.CardHand, chosenCardIndex);
                cgSession.Player[playerIndex].CardHand = addCardToHand(playerToDraw.CardHand, drawnCard);
                cgSession.Player[playerIndex].CardHand = discardPairs(playerToDraw.CardHand);

                if (cgSession.Player[playerToDrawFromIndex].CardHand.Count() == 0)
                {
                    cgSession.Player.RemoveAt(playerToDrawFromIndex);
                    playerIndex--;
                    playerCount--;
                }
                if(cgSession.Player[playerIndex].CardHand.Count() == 0)
                {
                    cgSession.Player.RemoveAt(playerIndex);
                    playerCount--;
                }
            }
            return cgSession;
        }

        //Prints out a list of cards, let's a user pick one and returns the index number of that card
        public int drawCard(string currentPlayerName, List<Card> cardHandToDrawFrom )
        {
            int cardHandIndex = 1;
            Console.Clear();
            Console.WriteLine(currentPlayerName + "'s turn!\n");
            foreach (Card card in cardHandToDrawFrom)
            {
                Console.WriteLine(cardHandIndex + ". " + card.CardValue);
                //Console.WriteLine(cardHandIndex);
                cardHandIndex++;
            }
            Console.Write("Choose a card: ");
            int chosenCardIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            return chosenCardIndex;
        }

        //Subtracts cards from a given cardlist and returns the list
        private List<Card> subtractCardFromHand(List<Card> cardHand, int cardIndex)
        {
            cardHand.RemoveAt(cardIndex);
            return cardHand;
        }
        //Adds cards to a given cardlist and returns the list
        private List<Card> addCardToHand(List<Card> cardHand, Card cardToAdd)
        {
            cardHand.Add(cardToAdd);
            return cardHand;
        }

        //Discards cards who form pairs from a supplied cardlist and returns said list
        private List<Card> discardPairs(List<Card> cardHand)
        {
            for (int outerIndex = 0; outerIndex < cardHand.Count()-1; outerIndex++)
            {                
                for(int innerIndex = outerIndex+1; innerIndex < cardHand.Count(); innerIndex++)
                {
                    if (cardHand[outerIndex].CardValue == cardHand[innerIndex].CardValue)
                    {
                        cardHand.RemoveAt(innerIndex);
                        cardHand.RemoveAt(outerIndex);
                        outerIndex--;
                        break;
                    }
                }
            }
            return cardHand;
        }
    }
}
