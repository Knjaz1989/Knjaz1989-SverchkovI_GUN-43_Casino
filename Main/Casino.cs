using FinalTaskCasino.Games;
using FinalTaskCasino.Interfaces;
using FinalTaskCasino.Inventory;
using FinalTaskCasino.Services;
using System.Text.Json;

namespace FinalTaskCasino.Main
{
    public class Casino : IGame
    {
        private CasinoGameBase _currentGame;


        private User GetUser(FileSystemSaveLoadService fsss, string name)
        {
            string json = fsss.LoadData(name);
            if (string.IsNullOrEmpty(json))
            {
                return new User(name);
            }
            else
            {
               return JsonSerializer.Deserialize<User>(json);
            }
        }

        public void StartGame()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");
            var fsss = new FileSystemSaveLoadService(path);
            Console.Write("Как вас зовут: ");
            string name = Console.ReadLine();
            name = new System.Globalization.CultureInfo("en-US").TextInfo.ToTitleCase(name.ToLower());
            var user = GetUser(fsss, name);
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
                            string json = JsonSerializer.Serialize(user);
                            fsss.SaveData(json, name);
                            Console.WriteLine("До новых встреч!");
                            return;
                        case 1:
                            _currentGame = new BlackJack(52);
                            break;
                        case 2:
                            _currentGame = new Craps(2);
                            break;
                        default:
                            Console.WriteLine("Такой игры не существует. Попробуйте еще раз!");
                            continue;
                    }
                    if (user.Money <= 0)
                    {
                        Console.WriteLine("No money? Kicked!");
                        return;
                    }
                    Console.Write("Ваша ставка: ");
                    bool isInteger = int.TryParse(Console.ReadLine(), out int bet);
                    if (isInteger && bet <= user.Money)
                    {
                        user.Money -= (uint)bet;
                        _currentGame.OnWin += () =>
                        {
                            user.Money += (uint)(bet * 2);
                            Console.WriteLine($"Победа! Ваш баланс: {user.Money}");
                        };
                        _currentGame.OnLoose += () =>
                        {
                            Console.WriteLine($"Поражение! Ваш баланс: {user.Money}");
                        };
                        _currentGame.OnDraw += () =>
                        {
                            user.Money += (uint)bet;
                            Console.WriteLine($"Ничья! Ваш баланс: {user.Money}");
                        };
                        _currentGame.PlayGame();
                        _currentGame.OnWin -= () => Console.WriteLine("Победа!");
                        _currentGame.OnLoose -= () => Console.WriteLine("Поражение!");
                        _currentGame.OnDraw -= () => Console.WriteLine("Ничья!");
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств для ставки!");
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
