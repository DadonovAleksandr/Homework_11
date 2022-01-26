using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.Models
{
    interface IAppSettingsRepository
    {
        /// <summary>
        /// Сохранение настрек приложения
        /// </summary>
        public void Save(AppSettings settings);

        /// <summary>
        /// Загрузка настроек приложения
        /// </summary>
        public AppSettings Load();
    }
}
