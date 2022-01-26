using Homework_11.Infrastructure.Commands;
using Homework_11.Models;
using Homework_11.ViewModels.Base;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace Homework_11.ViewModels
{
    

    class AppSettingsViewModel : BaseViewModel
    {

        IAppSettingsRepository _repository;
        AppSettings _appSettings;



        /// <summary>
        /// Создаем Модель-Представление
        /// </summary>
        public AppSettingsViewModel()
        {
            #region Commands
            SaveAppSettingsCommand = new RelayCommand(OnSaveAppSettingsCommandExecuted, CanSaveAppSettingsCommandExecute);
            GenTestClientsCommand = new RelayCommand(OnGenTestClientsCommandExecuted, CanGenTestClientsCommandExecute);
            #endregion


            _repository = new AppSettingsFileRepository();
            _appSettings = _repository.Load();
            ClientRepositoryFilePath = _appSettings.ClientRepositoryFilePath;
        }

        #region Commands

        #region SaveAppSettingsCommand
        public ICommand SaveAppSettingsCommand { get; }

        private void OnSaveAppSettingsCommandExecuted(object p)
        {
            _repository.Save(_appSettings);
        }

        private bool CanSaveAppSettingsCommandExecute(object p) => true;

        #endregion

        #region GenTestClientsCommand
        public ICommand GenTestClientsCommand { get; }

        private void OnGenTestClientsCommandExecuted(object p)
        {
            var clients = Enumerable.Range(1, 20).Select(i => new Client
            (
                new PhoneNumber($"+7900800{(i>9 ? i : "0"+i)}"),
                new PassportData(1000+i, 50000+i),
                $"Имя {i}",
                $"Фамиля {i}",
                $"Отчество {i}"
            ));
            ClientRepositoryFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"clients.json");
            _appSettings.ClientRepositoryFilePath = ClientRepositoryFilePath;
            ClientFileRepository clientsRepository = new ClientFileRepository(ClientRepositoryFilePath, clients);
            clientsRepository.Save();
        }

        private bool CanGenTestClientsCommandExecute(object p) => true;
        #endregion



        #endregion





        #region Application settings
        private string _ClientRepositoryFilePath;
        /// <summary>
        /// Настройки приложения
        /// </summary>
        public string ClientRepositoryFilePath
        {
            get => _ClientRepositoryFilePath;
            set
            {
                Set(ref _ClientRepositoryFilePath, value);
                _appSettings.ClientRepositoryFilePath = _ClientRepositoryFilePath;
            }
        }
        #endregion


    }
}
