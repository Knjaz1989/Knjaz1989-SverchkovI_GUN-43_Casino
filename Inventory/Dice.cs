using FinalTaskCasino.Exceptions;

namespace FinalTaskCasino.Inventory
{
    public struct Dice
    {
        private Random _random = new Random();
        private int _min;
        private int _max;

        public Dice(int min, int max)
        {
            if (min < 1)
                throw new WrongDiceNumberException(min);
            else if (max > int.MaxValue)
            {
                throw new WrongDiceNumberException(max);
            }
        }

        public int Number { get => _random.Next(_min, _max); }

    }
}
