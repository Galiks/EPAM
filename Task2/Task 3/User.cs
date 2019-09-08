using System;
using System.Collections.Generic;
using System.Text;

namespace Task2.Task_3
{
    public class User
    {
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                Validator.IsLetterOnly(value);
                if (!string.IsNullOrWhiteSpace(value))
                {
                    firstName = value;
                }
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                Validator.IsLetterOnly(value);
                if (!string.IsNullOrWhiteSpace(value))
                {
                    lastName = value;
                }
            }
        }

        private string middleName;

        public string MiddleName
        {
            get { return middleName; }
            set
            {
                Validator.IsLetterOnly(value);
                if (!string.IsNullOrWhiteSpace(value))
                {
                    middleName = value;
                }
            }
        }

        private DateTime dayOfBirthday;

        public DateTime DayOfBirthday
        {
            get { return dayOfBirthday; }
            private set
            {
                Validator.IsNotNowDate(value);
                dayOfBirthday = value;
            }
        }

        private int age;

        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        /// <summary>
        /// Инициализатор объекта класса User
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="dob">Дата рождения</param>
        public User(string firstName, string lastName, string middleName, DateTime dob)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            DayOfBirthday = dob;
            Age = GetYear(DayOfBirthday);
        }

        /// <summary>
        /// Возвращает количество лет со дня, указанного в параметре
        /// </summary>
        /// <param name="dateTime">начало отсчёта</param>
        /// <returns>количество лет</returns>
        protected int GetYear(DateTime dateTime)
        {
            DateTime today = DateTime.Today;
            if (today.Month > DayOfBirthday.Month)
            {
                return today.Year - dateTime.Year;
            }
            else
            {
                return today.Year - dateTime.Year - 1;
            }
        }

        public override string ToString()
        {
            return $"Имя: {FirstName}{Environment.NewLine}Фамилия: {LastName}{Environment.NewLine}Отчество: {MiddleName}{Environment.NewLine}Год рождения: {DayOfBirthday.Year} {DayOfBirthday.Month} {DayOfBirthday.Day}{Environment.NewLine}Полных лет: {Age}{Environment.NewLine}";

        }
    }
}
