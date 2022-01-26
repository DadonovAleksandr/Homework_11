using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Homework_11.Models
{
    internal class ClientFileRepository : IClientsRepository
    {
        /// <summary>
        /// Список клиентов
        /// </summary>
        List<Client> _clients;
        /// <summary>
        /// Файл репозитория
        /// </summary>
        string _path;

        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        /// <param name="path">Путь к файлу-репозиторию</param>
        public ClientFileRepository(string path)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }
            _path = path;

            if (File.Exists(_path))
                Load();
        }

        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        /// <param name="path">Путь к файлу-репозиторию</param>
        public ClientFileRepository(string path, IEnumerable<Client> clients) : this(path)
        {
            _clients = clients.ToList();
        }

        // TODO: проверить удаление по несуществующему ИД
        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="clientId">ИД клиента</param>
        public void DeleteClient(int clientId) => _clients.Remove(_clients.Where(c => c.Id == clientId).FirstOrDefault());

        // TODO: проверить получение данных по несуществующему ИД
        /// <summary>
        /// Получение данных о клиенте по ИД
        /// </summary>
        /// <param name="clientId">ИД клиента</param>
        /// <returns></returns>
        public Client GetClientByID(int clientId) => _clients.Where(c => c.Id == clientId).FirstOrDefault();

        /// <summary>
        /// Получение списка клиентов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Client> GetAllClients() => _clients;

        // TODO: проверить передачу null/не заполненого ID
        /// <summary>
        /// Добавление нового клиента
        /// </summary>
        /// <param name="client">клиент</param>
        public void InsertClient(Client client) => _clients.Add(client);

        /// <summary>
        /// Обновление данных о клиенте
        /// </summary>
        /// <param name="client"></param>
        public void UpdateClient(Client client)
        {
            if (_clients.Contains(client))
            {
                throw new ArgumentOutOfRangeException(nameof(client), "Такого объекта нет в списке");
            }

            _clients[_clients.IndexOf(client)] = client;
        }

        /// <summary>
        /// Сохранение списка клиентов в файл
        /// </summary>
        public void Save()
        {
            string dirPath = Path.GetFileName(Path.GetDirectoryName(_path));
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            string json = JsonConvert.SerializeObject(_clients);
            File.WriteAllText(_path, json, Encoding.UTF8);
        }

        /// <summary>
        /// Загрузка списка клинтов
        /// </summary>
        void Load()
        {
            string data = File.ReadAllText(_path);
            _clients = JsonConvert.DeserializeObject<List<Client>>(data);
        }

    }
}
