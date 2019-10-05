using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarThematicPlan.Entity
{
    public class Subject
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Hours { get; set; }
    }
}
