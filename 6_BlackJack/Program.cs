using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the card deck


            List<String> Values = new List<String> { 6.ToString(), 7.ToString(), 8.ToString(), 9.ToString(), 10.ToString(), "Jack", "Queen", "King", "Ace" };
            List<String> Suits = new List<String> { "Spades", "Clubs", "Diamonds", "Hearts" };

            List<Card> CardDeck = new List<Card> { };


            for (int i = 0; i < Values.Count; i++)
            {
                for (int j = 0; j < Suits.Count; j++)
                {
                    CardDeck.Add(new Card(Values[i], Suits[j]));
                }


            }



            //Radomiser for random card giving.
            Random r = new Random();

            //Lists of computer's and player's cards

            List<Card> ComputerCards = new List<Card> { };
            List<Card> PlayerCards = new List<Card> { };



            //Game logic


            while (true)
            {
                int ComputerPoints = 0;
                int PlayerPoints = 0;

                //Computer and player get 2 cards 
                for (int i = 0; i < 2; i++)
                {
                    int ComputerCard = r.Next(CardDeck.Count - 1);
                    ComputerCards.Add(CardDeck[ComputerCard]);
                    ComputerPoints += CardDeck[ComputerCard]._Points;
                    CardDeck.RemoveAt(ComputerCard);



                    int PlayerCard = r.Next(CardDeck.Count - 1);
                    PlayerCards.Add(CardDeck[PlayerCard]);
                    PlayerPoints += CardDeck[PlayerCard]._Points;
                    CardDeck.RemoveAt(PlayerCard);


                }
                foreach (Card card in PlayerCards)
                {
                    Console.WriteLine("Your card: " + card.ToString());

                }
                Console.WriteLine("You have " + PlayerPoints + " points");


                if (ComputerPoints == 22)
                {
                    Console.WriteLine("Computer WON!");
                    break;

                }
                if (PlayerPoints == 22)
                {
                    Console.WriteLine("You WON!");
                    break;

                }


                //  Card by card for player

                while (true)
                {

                    Console.WriteLine("One more card? (Y)es or (N)o");
                    string answer = Console.ReadLine();

                    if (answer == "y")
                    {
                        int PlayerCard = r.Next(CardDeck.Count - 1);
                        PlayerCards.Add(CardDeck[PlayerCard]);
                        PlayerPoints += CardDeck[PlayerCard]._Points;
                        CardDeck.RemoveAt(PlayerCard);

                        Console.WriteLine("Your card: " + PlayerCards.Last().ToString());


                        Console.WriteLine("You have " + PlayerPoints + " points");

                        if (PlayerPoints > 21)

                        {
                            break;
                        }

                    }

                    if (answer == "n")
                    {
                        break;
                    }

                }


                //  Card by card for computer


                while (ComputerPoints < 17)
                {
                    int ComputerCard = r.Next(CardDeck.Count - 1);
                    ComputerCards.Add(CardDeck[ComputerCard]);
                    ComputerPoints += CardDeck[ComputerCard]._Points;
                    CardDeck.RemoveAt(ComputerCard);

                }

                Console.WriteLine("Computer has {0} points", ComputerPoints);

                //Result of GAME!!!

                if (ComputerPoints > PlayerPoints)
                {
                    if (ComputerPoints > 21)
                    {
                        Console.WriteLine("You won!");

                    }
                    else
                    {
                        Console.WriteLine("Computer won!");

                    }


                }

                else if (PlayerPoints > ComputerPoints)
                {
                    if (PlayerPoints > 21)
                    {
                        Console.WriteLine("Computer won!");
                    }
                    else
                    {
                        Console.WriteLine("You won!");
                    }


                }
                else
                {
                    Console.WriteLine("It's a draw!");
                }

                break;



            }





        }


    }
}
