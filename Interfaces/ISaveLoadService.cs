namespace FinalTaskCasino.Interfaces
{
    public interface ISaveLoadService<T>
    {
        public void SaveData(T entity, string id);
        public T LoadData(string id);
    }
}
