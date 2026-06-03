namespace FinalTaskCasino.Games
{
    public abstract class CasinoGameBase
    {

        public abstract event Action OnWin;
        public abstract event Action OnLoose;
        public abstract event Action OnDraw;

        protected abstract void FactoryMethod();
        public abstract void PlayGame();
    }
}
