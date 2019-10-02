using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.Entity
{
    public class Schedule
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public string Room { get; set; }
        public int IdSubject { get; set; }
        public int IdGrade { get; set; }
        public int IdUser { get; set; }
    }
}
