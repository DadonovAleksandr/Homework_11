using System;

namespace Homework_11.Models
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    internal abstract class Person
    {
        const int minFirstNameLength = 2;   // Минимальная длина имени
        const int minSecondNameLength = 2;  // Минимальная длина фамилии

        string _firstName;
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName => _firstName;

        private string _secondName;
        /// <summary>
        /// Фамилия
        /// </summary>
        public string SecondName => _secondName;

        private string _middleName;
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName => _middleName;

        /// <summary>
        /// Создаем пользователя с именем, фамилией и необязательным отчеством
        /// </summary>
        public Person(string firstName, string secondName, string middleName = "")
        {
            SetName(firstName, secondName, middleName);
        }

        /// <summary>
        /// Корректировка имени, фамилии и необязательного отчества
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="secondName">Фамилия</param>
        /// <param name="middleName">Отчество</param>
        private protected void CorrectName(string firstName, string secondName, string middleName = "")
        {
            SetName(firstName, secondName, middleName);
        }

        /// <summary>
        /// Установка имени и фамилии
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="secondName">Фамилия</param>
        /// <param name="middleName">Отчество</param>
        private void SetName(string firstName, string secondName, string middleName)
        {
            CheckName(firstName, minFirstNameLength, "Имя");
            CheckName(secondName, minSecondNameLength, "Отчество");
            _firstName = firstName;
            _secondName = secondName;
            _middleName = middleName;
        }

        /// <summary>
        /// Проверка валидности имени и фамилии
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="minLength">Минимальная длина</param>
        /// <param name="errDesc">Описание для отображения ошибки</param>
        /// <returns></returns>
        private void CheckName(string name, int minLength, string errDesc)
        {
            // проверка
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"{nameof(errDesc)} не может пустым или пробелом");
            }
            if (name.Length < minFirstNameLength)
            {
                throw new ArgumentException($"{nameof(errDesc)} не может быть короче {minLength} символов");
            }
        }

    }
}
