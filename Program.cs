using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMaid
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit;
            string loser;
            do
            {
                Console.Clear();
                quit = false;
                Console.WriteLine("1. Play game");
                Console.WriteLine("2. Quit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            OldMaidController omC = new OldMaidController();
                            List<string> deck = new OldMaidCards().returnCardList();

                            Console.Write("Input number of players: ");
                            int playerCount = Convert.ToInt32(Console.ReadLine());

                            //Creates a CardGameSession object
                            CardGameSession cg = new CardGameSession(deck, playerCount);
                            cg = omC.shuffleCards(cg);
                            cg = omC.dealCards(cg);
                            do
                            {
                                Console.Clear();
                                loser = "";
                                for (int i = 0; i < cg.Player.Count(); i++)
                                {
                                    Console.WriteLine(cg.Player[i].PlayerName + " has " + cg.Player[i].CardHand.Count() + " cards left");
                                }
                                if(cg.Player.Count() > 1)
                                {
                                    cg = omC.playRound(cg);
                                }
                                else if(cg.Player.Count() == 1)
                                {
                                    loser = cg.Player[0].PlayerName;
                                }
                            }
                            while (loser == "");
                            Console.Clear();
                            Console.WriteLine("Game finished!");
                            Console.WriteLine("This game's loser is: " + loser);
                            Console.WriteLine("\nPress any key...");
                            Console.ReadKey();
                            break;
                        }
                    case "2":
                        {
                            quit = true;
                            break;
                        }
                }

            }
            while (quit == false);
        }
    }
}
