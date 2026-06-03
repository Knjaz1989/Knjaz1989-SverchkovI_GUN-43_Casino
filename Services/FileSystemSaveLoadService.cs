using FinalTaskCasino.Interfaces;
using FinalTaskCasino.Inventory;
using System.Text.Json;

namespace FinalTaskCasino.Services
{
    public class FileSystemSaveLoadService : ISaveLoadService<string>
    {
        private string _path;
        public FileSystemSaveLoadService(string path)
        {
            _path = path;
            EnsurePathExists();
        }

        private void EnsurePathExists()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }

        public string LoadData(string name)
        {
            string filePath = Path.Combine(_path, $"{name}.txt");

            if (!File.Exists(filePath))
                return string.Empty;

            return File.ReadAllText(filePath);
        }

        public void SaveData(string entity, string id)
        {
            File.WriteAllText(Path.Combine(_path, $"{id}.txt"), entity);
        }
    }
}
