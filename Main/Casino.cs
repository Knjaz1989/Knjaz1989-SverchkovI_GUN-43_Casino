using FinalTaskCasino.Games;
using FinalTaskCasino.Interfaces;

namespace FinalTaskCasino.Main
{
    public class Casino : IGame
    {
        private BlackJack _blackJack;
        private Craps _craps;
        public Casino()
        {
            _blackJack = new BlackJack(52);
            _blackJack.OnWin += () => Console.WriteLine("Победа!");
            _blackJack.OnLoose += () => Console.WriteLine("Поражение!");
            _blackJack.OnDraw += () => Console.WriteLine("Ничья!");

            _craps = new Craps(2);
            _craps.OnWin += () => Console.WriteLine("Победа!");
            _craps.OnLoose += () => Console.WriteLine("Поражение!");
            _craps.OnDraw += () => Console.WriteLine("Ничья!");
        }

        public void StartGame()
        {
            Console.Write("Как вас зовут: ");
            string name = Console.ReadLine();
            name = new System.Globalization.CultureInfo("en-US").TextInfo.ToTitleCase(name.ToLower());
            // Здесь нужно будет сохранить игрока в систему
            Console.WriteLine("Выбирите игру:\n\t1 - BlackJack\n\t2 - Игра в кости\n\n0 - Чтобы выйти");

            while (true)
            {
                Console.Write("Номер игры: ");
                bool success = int.TryParse(Console.ReadLine(), out int gameNumber);
                if (success)
                {
                    switch (gameNumber) 
                    {
                        case 0:
                            Console.WriteLine("До новых встреч!");
                            return;
                        case 1:
                            _blackJack.PlayGame();
                            break;
                        case 2:
                            _craps;
                            break;
                        default:
                            Console.WriteLine("Такой игры не существует. Попробуйте еще раз!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Можно ввести только число. Попробуйте еще раз!");
                }
            }
        }
    }
}
