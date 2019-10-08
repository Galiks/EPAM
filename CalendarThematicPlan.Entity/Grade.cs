﻿using System.ComponentModel.DataAnnotations;

namespace CalendarThematicPlan.Entity
{
    public class Grade
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Номер класса обязателен")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Буква класса обязательна")]
        public string Letter { get; set; }
        [Required(ErrorMessage = "Количество детей в классе обязателно")]
        public int KidsInClass { get; set; }

        public override string ToString()
        {
            return $"{Id} : {Number}{Letter}";
        }
    }
}
