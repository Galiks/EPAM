using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.Entity
{
    public class Schedule
    {
        public int? Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime ActualDate { get; set; }
        [Required]
        public string Room { get; set; }
        [Required]
        public int IdSubject { get; set; }
        [Required]
        public int IdGrade { get; set; }
        [Required]
        public int IdUser { get; set; }
        public string LessonTopic { get; set; }
        public string Comment { get; set; }
    }
}
