using FinalTaskCasino.Utils;

namespace FinalTaskCasino.Inventory
{
    public struct Card
    {
        private CardSuit _suit;
        private CardRank _rank;

        public CardSuit Suit {  get { return _suit; } }
        public CardRank Rank { get { return _rank; } }
        public int Value
        {
            get
            {
                if (_rank == CardRank.Jack || _rank == CardRank.Queen || _rank == CardRank.King)
                    return 10;

                if (_rank == CardRank.Ace)
                    return 11;

                return (int)_rank;
            }
        }
        public Card(CardSuit suit, CardRank rank)
        {
            _rank = rank;
            _suit = suit;
        }
    }
}
