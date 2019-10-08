using System.ComponentModel.DataAnnotations;

namespace CalendarThematicPlan.Entity
{
    public class Subject
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Hours { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Hours}";
        }
    }
}
