using KlondikeGame;


namespace TestForKodiLike
{
    public class UnitTest1
    {
        [Fact]
        public void Card_StoresRankAndSuit()
        {
            var card = new Card(Suit.Hearts, Rank.Seven);

            Assert.Equal(Rank.Seven, card.RankCard);
            Assert.Equal(Suit.Hearts, card.SuitCard);
        }
    }
}