using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.Entity
{
    public class Grade
    {
        public int? Id { get; set; }
        public int? Number { get; set; }
        public string Letter { get; set; }
        public int? KidsInClass { get; set; }
    }
}
