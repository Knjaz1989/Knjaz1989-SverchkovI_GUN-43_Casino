using FinalTaskCasino.Inventory;
using FinalTaskCasino.Utils;


namespace FinalTaskCasino.Games
{
    public class BlackJack : CasinoGameBase
    {
        private int _cardCount;
        private Random _random = new Random();
        private List<Card> _cards = new List<Card>();
        private Queue<Card> _deck;

        public override event Action OnWin;
        public override event Action OnLoose;
        public override event Action OnDraw;

        public BlackJack(int cardCount)
        {
            _cardCount = cardCount;
            FactoryMethod();
        }

        private void Shuffle()
        {
            var cards = new List<Card>(_cards);
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = _random.Next(0, i + 1);
                (cards[i], cards[j]) = (cards[j], cards[i]);
            }
            _deck = new Queue<Card>(cards);
        }

        private int GetCardAndPoints(Queue<Card> deck, int cardCount, int points = 0)
        {
            for (int i = 0; i < 2; i++)
            {
                var card = _deck.Dequeue();
                Console.WriteLine($"Получена карта: {card.Rank} of {card.Suit}");
                points += card.Value;
            }
            Console.WriteLine($"Всего очков: {points}");
            return points;
        }

        public override void PlayGame()
        {
            Shuffle();
            int userPoints = GetCardAndPoints(_deck, 2);
            int compPoints = GetCardAndPoints(_deck, 2);

            while (userPoints == compPoints && userPoints <= 21 && compPoints <= 21)
            {
                userPoints = GetCardAndPoints(_deck, 1, userPoints);
                compPoints = GetCardAndPoints(_deck, 1, compPoints);
            }
            if (userPoints > 21 && compPoints > 21)
            {
                OnDraw?.Invoke();
            }
            else if (userPoints > compPoints || compPoints > 21)
            {
                OnWin?.Invoke();
            }
            else
            {
                OnLoose?.Invoke();
            }
        }

        protected override void FactoryMethod()
        {
            var allCards = new List<Card>();

            foreach (CardSuit suit in Enum.GetValues<CardSuit>())
            {
                foreach (CardRank rank in Enum.GetValues<CardRank>())
                {
                    allCards.Add(new Card(suit, rank));
                }
            }

            for (int i = 0; i < _cardCount; i++)
            {
                _cards.Add(allCards[i % allCards.Count]);
            }
        }
    }
}
