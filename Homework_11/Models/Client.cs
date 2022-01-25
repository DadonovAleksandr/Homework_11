using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.Models
{
    internal class Client : Person
    {
        private int _id;
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        private PhoneNumber _phoneNumber;
        /// <summary>
        /// Номер телефона
        /// </summary>
        public PhoneNumber PhoneNumber { get { return _phoneNumber; } }

        private PassportData _passportData;
        /// <summary>
        /// Паспортные данные
        /// </summary>
        public PassportData PassportData { get { return _passportData; } }

        /// <summary>
        /// Создаем клиента
        /// </summary>
        /// <param name="phoneNumber">Номер тедефона</param>
        /// <param name="passportData">Паспортный данные</param>
        /// <param name="firstName">Имя</param>
        /// <param name="secondName">Фамилия</param>
        /// <param name="middleName">отчество</param>
        public Client(PhoneNumber phoneNumber, PassportData passportData, string firstName, string secondName, string middleName = "")
            : base(firstName, secondName, middleName)
        {
            _phoneNumber = phoneNumber;
            _passportData = passportData;
        }


    }
}
