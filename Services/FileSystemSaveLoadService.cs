using FinalTaskCasino.Interfaces;

namespace FinalTaskCasino.Services
{
    public class FileSystemSaveLoadService : ISaveLoadService<string>
    {
        public FileSystemSaveLoadService(string path)
        {

        }

        public string LoadData(string id)
        {
            throw new NotImplementedException();
        }

        public void SaveData(string entity, string id)
        {
            throw new NotImplementedException();
        }
    }
}
