using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace Homework_11.Models
{
    /// <summary>
    /// Сохранения настроек приложения в файл
    /// </summary>
    internal class AppSettingsFileRepository : IAppSettingsRepository
    {
        const string _path = @"app-settings.json";

        /// <summary>
        /// Сохранение настроек приложения в файл рядом с exe
        /// </summary>
        public void Save(AppSettings settings)
        {
            string json = JsonConvert.SerializeObject(settings);
            File.WriteAllText(_path, json, Encoding.UTF8);
        }

        /// <summary>
        /// Загрузка списка клинтов
        /// </summary>
        public AppSettings Load()
        {
            if (!File.Exists(_path))
                return new AppSettings();
            string data = File.ReadAllText(_path);
            return JsonConvert.DeserializeObject<AppSettings>(data);
        }
    }
}
