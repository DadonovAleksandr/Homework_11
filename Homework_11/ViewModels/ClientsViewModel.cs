using Homework_11.Infrastructure.Commands;
using Homework_11.Models;
using Homework_11.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Homework_11.ViewModels
{
    class ClientsViewModel : BaseViewModel
    {

        public ObservableCollection<Client> Clients { get; }

        IClientsRepository ClientsRepository;

        public ClientsViewModel()
        {
            #region Commands
            AddClientCommand = new RelayCommand(OnAddClientCommandExecuted, CanAddClientCommandExecute);
            DelClientCommand = new RelayCommand(OnDelClientCommandExecuted, CanDelClientCommandExecute);
            EditClientCommand = new RelayCommand(OnEditClientCommandExecuted, CanEditClientCommandExecute);
            #endregion

            var appSetings = new AppSettings();
            IAppSettingsRepository appSettingsRepository = new AppSettingsFileRepository();
            appSetings = appSettingsRepository.Load();
            ClientsRepository = new ClientFileRepository(appSetings.ClientRepositoryFilePath);
            //ClientsRepository = new ClientFileRepository(@"C:\Users\Aleksandr\source\SkillBox\Homework_11\Homework_11\bin\Debug\net5.0-windows\clients.json");
            Clients = new ObservableCollection<Client>(ClientsRepository.GetAllClients());
        }

        #region Commands

        #region AddClient
        public ICommand AddClientCommand { get; }

        private void OnAddClientCommandExecuted(object p)
        {
            ;
        }

        private bool CanAddClientCommandExecute(object p) => true;

        #endregion

        #region DelClient
        public ICommand DelClientCommand { get; }

        private void OnDelClientCommandExecuted(object p)
        {
            ;
        }

        private bool CanDelClientCommandExecute(object p) => true;
        #endregion

        #region EditClient
        public ICommand EditClientCommand { get; }

        private void OnEditClientCommandExecuted(object p)
        {
            ;
        }

        private bool CanEditClientCommandExecute(object p) => true;
        #endregion


        #endregion

        #region Window title
        private string _Title = "Банк А. Программа консультант";
        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion
    }
}
