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
            while (true)
            {
                Game game = new Game();


                Console.WriteLine("Do you want to continue game? (Y)es or (N)o");

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



                if (Answer == "n")
                {
                    Console.WriteLine("Result of the game:");
                    Console.WriteLine("You won {0} time(s)", Game.PlayerWon);
                    Console.WriteLine("Computer won {0} time(s)", Game.ComputerWon);
                    Console.WriteLine("Draw was {0} time(s)", Game.Draw);


                    break;
                }

                Console.Clear();
            }

        }


    }
}
