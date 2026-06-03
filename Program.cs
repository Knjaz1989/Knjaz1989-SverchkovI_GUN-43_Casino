using FinalTaskCasino.Interfaces;
using FinalTaskCasino.Main;

namespace FinalTaskCasino
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IGame casino = new Casino();
            casino.StartGame();
        }
    }
}
