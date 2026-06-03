using FinalTaskCasino.Inventory;

namespace FinalTaskCasino.Games
{
    internal class Craps : CasinoGameBase
    {
        private int _diceCount;
        private int _minDiceValue;
        private int _maxDiceValue;
        private List<Dice> _dices = new();

        public override event Action OnWin;
        public override event Action OnLoose;
        public override event Action OnDraw;

        public Craps(int diceCount, int min = 1, int max = 6)
        {
            _diceCount = diceCount;
            _minDiceValue = min;
            _maxDiceValue = max;
            FactoryMethod();
        }

        protected override void FactoryMethod()
        {
            for (int i = 0; i < _diceCount; i++)
            {
                var dice = new Dice(_minDiceValue, _maxDiceValue);
                _dices.Add(dice);
            }
        }

        private int GetPoints(string name)
        {
            int points = 0;
            foreach (var dice in _dices)
            {
                points += dice.Number;
            }
            Console.WriteLine($"{name} -> Всего очков: {points}");
            return points;
        }

        public override void PlayGame()
        {
            int userPoints = GetPoints("Пользователь");
            int compPoints = GetPoints("Компьютер");
            if (userPoints > compPoints)
            {
                OnWin?.Invoke();
            }
            else if (userPoints < compPoints)
            {
                OnLoose?.Invoke();
            }
            else
            {
                OnDraw?.Invoke();
            }
        }
    }
}
