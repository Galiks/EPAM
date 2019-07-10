using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._3
{
    public class User
    {
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                MyException.IsLetterOnly(value);
                if (!String.IsNullOrWhiteSpace(value))
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
                MyException.IsLetterOnly(value);
                if (!String.IsNullOrWhiteSpace(value))
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
                MyException.IsLetterOnly(value);
                if (!String.IsNullOrWhiteSpace(value))
                {
                    middleName = value;
                }
            }
        }

        private DateTime dayOfBirthday;

        public DateTime DayOfBirthday
        {
            get { return dayOfBirthday; }
            set
            {
                MyException.IsNotNowDate(value);
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
        /// <param name="surName">Отчество</param>
        /// <param name="dob">Дата рождения</param>
        public User(string firstName, string lastName, string surName, DateTime dob)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = surName;
            DayOfBirthday = dob;
            Age = GetAge();
        }

        private int GetAge()
        {
            DateTime today = DateTime.Today;
            if (today.Month > DayOfBirthday.Month)
            {
                return today.Year - DayOfBirthday.Year;
            }
            else
            {
                return today.Year - DayOfBirthday.Year - 1;
            }
        }

        public override string ToString()
        {
            return $"Имя: {FirstName}{Environment.NewLine}Фамилия: {LastName}{Environment.NewLine}Отчество: {MiddleName}{Environment.NewLine}Год рождения: {DayOfBirthday.Year} {DayOfBirthday.Month} {DayOfBirthday.Day}{Environment.NewLine}Полных лет: {Age}{Environment.NewLine}";

        }
    }
}
