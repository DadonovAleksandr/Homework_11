using System;
using System.Text.RegularExpressions;

namespace Homework_11.Models
{
    /// <summary>
    /// Номер телефонв
    /// </summary>
    internal class PhoneNumber
    {

        private string _number;
        /// <summary>
        /// Текстовое представление телефонного номера
        /// </summary>
        public string Number
        {
            get { return _number; }
        }

        /// <summary>
        /// Создаем номер телефона из текстовой строки
        /// </summary>
        /// <param name="number"></param>
        public PhoneNumber(string number)
        {
            SetNumber(number);
        }

        /// <summary>
        /// Проверяем, является ли вводимая строка номером телефона
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        }

        /// <summary>
        /// Установка номера телефона
        /// </summary>
        /// <param name="number"></param>
        private void SetNumber(string number)
        {
            CheckNumber(number);
            _number = number;
        }

        /// <summary>
        /// Проверка валидности входных данных
        /// </summary>
        /// <param name="number"></param>
        private void CheckNumber(string number)
        {
            if (string.IsNullOrEmpty(number) || string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException($"{nameof(number)} не может быть null, empty, whitespace");
            }

            if (!IsPhoneNumber(number))
            {
                throw new ArgumentException($"{nameof(number)} не является номером телефона");
            }
        }


        public override string ToString()
        {
            return $"{Number}";
        }

    }
}
