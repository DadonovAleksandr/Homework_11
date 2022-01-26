using Homework_11.Infrastructure.Commands;
using Homework_11.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Homework_11.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            #region Commands
            ChangePageIndexCommand = new RelayCommand(OnChangePageIndexCommandExecuted, CanChangePageIndexCommandExecute);
            #endregion

            #region Pages
            _Clients = new Views.Pages.Clients();
            _AppSettings = new Views.MainWindows.Pages.AppSettings();
            _Welcome1 = new Views.Pages.Welcome_1();
            _Welcome2 = new Views.Pages.Welcome_2();
            _Welcome3 = new Views.Pages.Welcome_3();

            FrameOpacity = 1.0;
            CurrentPage = _Clients;

            #endregion

        }

        #region Commands

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        #endregion

        #region ChangePageIndexCommand
        public ICommand ChangePageIndexCommand { get; }

        private void OnChangePageIndexCommandExecuted(object p)
        {
            if (p is null) return;
            SelectedPageIndex = Convert.ToInt32(p);
            switch(SelectedPageIndex)
            {
                case 1: SlowOpacity(_Clients); break;
                case 2: SlowOpacity(_Welcome1); break;
                case 3: SlowOpacity(_Welcome2); break;
                case 4: SlowOpacity(_AppSettings); break;
                default: SlowOpacity(_Welcome1); break;
            };
        }

        private bool CanChangePageIndexCommandExecute(object p) => SelectedPageIndex >= 0;
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

        #region Pages
        private Page _Clients;
        private Page _AppSettings;
        private Page _Welcome1;
        private Page _Welcome2;
        private Page _Welcome3;
        



        private Page _CurrentPage;
        /// <summary>
        /// Текущая страница фрейма
        /// </summary>
        public Page CurrentPage
        {
            get => _CurrentPage;
            set => Set(ref _CurrentPage, value);
        }

        private int _SelectedPageIndex;
        /// <summary>
        /// Номер выбранной страницы
        /// </summary>
        public int SelectedPageIndex
        {
            get => _SelectedPageIndex;
            set => Set(ref _SelectedPageIndex, value);
        }

        private double _FrameOpacity;
        public double FrameOpacity
        {
            get => _FrameOpacity;
            set => Set(ref _FrameOpacity, value);
        }
        #endregion










        

        

        



        #region Status
        private string _Status = @"Готов!";
        /// <summary>
        /// Статус программы
        /// </summary>
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }
        #endregion


        private async void SlowOpacity(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
                CurrentPage = page;
                for (double i = 0.0; i < 1.0; i += 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
            });
        }

    }
}
