using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlondikeGame
{
    public enum Suit { Diamonds, Hearts, Clubs, Spades}
    public enum Rank { Ace = 1, Two,  Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King}
    public class Card
    {
        public Suit SuitCard {  get; set; }
        public Rank RankCard { get; set; }
        public bool FaceUp { get; set; }
        public bool IsRed { get; set; }

        public Card(Suit s, Rank r)
        {
            SuitCard = s;
            RankCard = r;
        }
        public override string ToString()
        {
            return string.Empty;
        }
    }
}
