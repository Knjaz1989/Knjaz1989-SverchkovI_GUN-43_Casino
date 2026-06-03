namespace FinalTaskCasino.Games
{
    public abstract class CasinoGameBase
    {
        protected CasinoGameBase()
        {
            FactoryMethod();
        }

        public event Action OnWin;
        public event Action OnLoose;
        public event Action OnDraw;

        protected void OnWinInvoke() 
        {
            OnWin?.Invoke();
        }
        protected void OnLooseInvoke()
        {
            OnLoose?.Invoke();
        }
        protected void OnDrawInvoke()
        {
            OnDraw?.Invoke();
        }

        protected abstract void FactoryMethod();
        public abstract void PlayGame();


    }
}
