using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_BlackJack
{
    class Game
    {
       

        List<String> Values = new List<String> { 6.ToString(), 7.ToString(), 8.ToString(), 9.ToString(), 10.ToString(), "Jack", "Queen", "King", "Ace" };
        List<String> Suits = new List<String> { "Spades", "Clubs", "Diamonds", "Hearts" };

        List<Card> _CardDeck = new List<Card> { };

        List<Card> _ComputerCards = new List<Card> { };
        List<Card> _PlayerCards = new List<Card> { };

        Random _random = new Random();


        //Total amount of games
        public static int GameCounter { get; private set; }

        //Counters for total result
        public static int PlayerWon { get; private set; }
        public static int ComputerWon { get; private set; }
        public static int Draw { get; private set; }

        //Counters of points in each game

        int _ComputerPoints = 0;
        int _PlayerPoints = 0;



        public Game()
        {
            Game.GameCounter++;

            while (true)
            {

                for (int i = 0; i < Values.Count; i++)
                {
                    for (int j = 0; j < Suits.Count; j++)
                    {
                        _CardDeck.Add(new Card(Values[i], Suits[j]));
                    }


                }

                for (int i = 0; i < 2; i++)
                {
                    ComputerMove();
                    PlayerMove();
                }

                



                //If player recieved 1st card

                if (GameCounter % 2 == 1)
                {
                    Console.WriteLine("You recieve cards first");

                    foreach (Card card in _PlayerCards)
                    {
                        Console.WriteLine("Your card: " + card.ToString());

                    }
                    Console.WriteLine("You have " + _PlayerPoints + " points");

                    //Check 22 points

                    if (_PlayerPoints == 22)
                    {
                        Console.WriteLine("You WON!");
                        break;

                    }

                    if (_ComputerPoints == 22)
                    {
                        Console.WriteLine("Computer WON!");
                        break;

                    }

                    //

                    PlayerRecivesCards();

                    if (_PlayerPoints <= 21)
                    {
                        while (_ComputerPoints < _PlayerPoints)
                        {
                            ComputerMove();

                        }

                    }


                }


                //If computer recieved 1st card.
                else
                {
                    while (_ComputerPoints < 17)
                    {
                        ComputerMove();

                    }

                    Console.WriteLine("Computer recived cards first and has {0} points with next cards:", _ComputerPoints);

                    foreach (Card card in _ComputerCards)
                    {
                        Console.WriteLine(card.ToString());
                    }

                    foreach (Card card in _PlayerCards)
                    {
                        Console.WriteLine("Your card: " + card.ToString());

                    }
                    Console.WriteLine("You have " + _PlayerPoints + " points");


                    PlayerRecivesCards();

                }

                //Result of the GAME

                Console.WriteLine("You have " + _PlayerPoints + " points"); ;
                

                if (GameCounter % 2 == 1)
                {
                    Console.WriteLine("Computer has " + _ComputerPoints + " points");

                    Console.WriteLine("Computer cards are:");
                    foreach (Card card in _ComputerCards)
                    {
                        Console.WriteLine(card.ToString());
                    }
                }

                //Deciding who is a winner

                if (_ComputerPoints > _PlayerPoints)
                {
                    if (_ComputerPoints > 21)
                    {
                        Console.WriteLine("You won!");
                        PlayerWon++;
                    }
                    else
                    {
                        Console.WriteLine("Computer won!");
                        ComputerWon++;
                    }


                }

                else if (_PlayerPoints > _ComputerPoints)
                {
                    if (_PlayerPoints > 21)
                    {
                        Console.WriteLine("Computer won!");
                        ComputerWon++;
                    }
                    else
                    {
                        Console.WriteLine("You won!");
                        PlayerWon++;
                    }


                }
                else
                {
                    Console.WriteLine("It's a draw!");
                    Draw++;
                }

                break;



            }
        }

        //2 methods: computer got a card and player got a card
        private void ComputerMove()
        {
            int ComputerCard = _random.Next(_CardDeck.Count - 1);
            _ComputerCards.Add(_CardDeck[ComputerCard]);
            _ComputerPoints += _CardDeck[ComputerCard]._Points;
            _CardDeck.RemoveAt(ComputerCard);
        }

        private void PlayerMove()
        {
            int PlayerCard = _random.Next(_CardDeck.Count - 1);
            _PlayerCards.Add(_CardDeck[PlayerCard]);
            _PlayerPoints += _CardDeck[PlayerCard]._Points;
            _CardDeck.RemoveAt(PlayerCard);
        }

        // Player recives cards in a loop.
        private void PlayerRecivesCards()
        {
            while (true)
            {

                Console.WriteLine("One more card? (Y)es or (N)o");
                string Answer;
                while (true)
                {
                    Answer = Console.ReadLine();
                    if (Answer == "y" || Answer == "n")
                    {
                        break;
                    }

                    Console.WriteLine("Your answer is incorrect! Please press (Y)es or (N)o");

                }

                if (Answer == "y")
                {
                    PlayerMove();

                    Console.WriteLine("Your card: " + _PlayerCards.Last().ToString());




                    if (_PlayerPoints > 21)

                    {
                        break;
                    }

                    Console.WriteLine("You have " + _PlayerPoints + " points");

                }

                if (Answer == "n")
                {
                    break;
                }

            }
        }

    }
}
