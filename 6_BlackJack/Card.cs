using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_BlackJack
{
    class Card
    {
        public string _Value {get; private set; }
        public string _Suit { get; private set; }
        public int _Points { get; private set; }

        public Card(string value, string suit)
        {
            _Value = value;
            _Suit = suit;
            if (value=="Ace")
            {
                _Points = 11;
            }
            else if (value == "King")
            {
                _Points = 4;
            }
            else if (value == "Queen")
            {
                _Points = 3;
            }
            else if (value == "Jack")
            {
                _Points = 2;
            }
            else if (value == "10")
            {
                _Points = 10;
            }
            else if (value == "9")
            {
                _Points = 9;
            }
            else if (value == "8")
            {
                _Points = 8;
            }
            else if (value == "7")
            {
                _Points = 7;
            }
            else if (value == "6")
            {
                _Points = 6;
            }

        }

        public override string ToString()
        {
            return _Value + " " + _Suit;
        }
    }
}
