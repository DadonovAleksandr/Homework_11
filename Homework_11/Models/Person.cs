using System;

namespace Homework_11.Models
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    internal abstract class Person
    {
        const int minFirstNameLength = 2;   // Минимальная длина имени
        const int minMiddleNameLength = 2;  // Минимальная длина отчества
        const int minSecondNameLength = 2;  // Минимальная длина фамилии

        string _firstName;
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get { return _firstName; } }

        private string _secondName;
        /// <summary>
        /// Фамилия
        /// </summary>
        public string SecondName { get { return _secondName; } }

        private string _middleName;
        /// <summary>
        /// Отчество
        /// </summary>
        public string middleName { get { return _middleName; } }

        /// <summary>
        /// Создаем пользователя с именем, фамилией и необязательным отчеством
        /// </summary>
        public Person(string firstName, string secondName, string middleName = "")
        {
            SetName(firstName, secondName, middleName);
        }

        /// <summary>
        /// Корректировка имени и фамилии
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="secondName">Фамилия</param>
        /// <param name="middleName">Отчество</param>
        private protected void CorrectName(string firstName, string secondName, string middleName)
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
            CheckName(firstName, secondName, middleName);
            _firstName = firstName;
            _secondName = secondName;
            _middleName = middleName;
        }

        /// <summary>
        /// Проверка валидности имени и фамилии
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="secondName">Фамилия</param>
        /// <param name="middleName">Отчество</param>
        /// <returns></returns>
        private void CheckName(string firstName, string secondName, string middleName)
        {
            // проверка имени
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException($"{nameof(firstName)} не может быть null, empty, whitespace");
            }
            if (firstName.Length < minFirstNameLength)
            {
                throw new ArgumentException($"{nameof(firstName)} не может быть короче {minFirstNameLength} симоволов");
            }

            // проверка фамилии
            if (string.IsNullOrEmpty(secondName) || string.IsNullOrWhiteSpace(secondName))
            {
                throw new ArgumentException($"{nameof(secondName)} не может быть null, empty, whitespace");
            }
            if (secondName.Length < minSecondNameLength)
            {
                throw new ArgumentException($"{nameof(secondName)} не может быть короче {minSecondNameLength} симоволов");
            }

            // проверка отчества
            if (string.IsNullOrWhiteSpace(middleName))
            {
                throw new ArgumentException($"{nameof(middleName)} не может быть null, whitespace");
            }
            if (middleName.Length > 0 && middleName.Length < minMiddleNameLength)
            {
                throw new ArgumentException($"{nameof(middleName)} не может быть короче {minMiddleNameLength} симоволов");
            }

        }

    }
}
