using System;
using System.Collections.Generic;
using System.Text;
using Task2.Task_3;

namespace Task2.Task_5
{
    public class Employee : User
    {
        private string position;

        public string Position
        {
            get { return position; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    position = value;
                }
            }
        }

        private DateTime startWorking;

        public DateTime StartWorking
        {
            get { return startWorking; }
            private set
            {
                Validator.IsNotNowDate(value);
                startWorking = value;
            }
        }

        private int workExperience;

        public int WorkExperience
        {
            get { return workExperience; }
            set { workExperience = GetYear(StartWorking); }
        }


        public Employee(string position, DateTime startWorking, string firstName, string lastName, string middleName, DateTime dayOfBirthday) :
            base(firstName, lastName, middleName, dayOfBirthday)
        {
            Position = position;
            StartWorking = startWorking;
        }

        public override string ToString()
        {
            return $"{base.ToString()}Стаж работы: {workExperience}{Environment.NewLine}Должность: {this.Position}";
        }
    }
}
