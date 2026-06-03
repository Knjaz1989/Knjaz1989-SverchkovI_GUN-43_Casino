using FinalTaskCasino.Inventory;

namespace FinalTaskCasino.Games
{
    internal class Craps : CasinoGameBase
    {
        private int _diceCount;
        private int _minDiceValue;
        private int _maxDiceValue;
        private List<Dice> _dices = new();
        public Craps(int diceCount, int min = 1, int max = 6)
        {
            _diceCount = diceCount;
            _minDiceValue = min;
            _maxDiceValue = max;
            FactoryMethod();
        }

        private int GetBoneAndPoints()
        {
            int points = 0;
            foreach (var dice in _dices)
            {
                points += dice.Number;
            }
            Console.WriteLine($"Всего очков: {points}");
            return points;
        }

        public override void PlayGame()
        {
            int userPoints = GetBoneAndPoints();
            int compPoints = GetBoneAndPoints();
            if (userPoints > compPoints)
            {
                OnWinInvoke();
            }
            else if (userPoints < compPoints)
            {
                OnLooseInvoke();
            }
            else
            {
                OnDrawInvoke();
            }
        }

        protected override void FactoryMethod()
        {
            for (int i = 0; i < _diceCount; i++)
            {
                var dice = new Dice(_minDiceValue, _maxDiceValue);
                _dices.Add(dice);
            }
        }
    }
}
