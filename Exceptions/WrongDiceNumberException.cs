namespace FinalTaskCasino.Exceptions
{
    internal class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException(int number)
            : base($"Неверное число: {number}. Допустимый диапазон: 1 - {int.MaxValue}")
            {
            }
    }
}
