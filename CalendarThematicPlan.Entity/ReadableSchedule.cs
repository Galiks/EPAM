using System;

namespace CalendarThematicPlan.Entity
{
    public class ReadableSchedule
    {
        public DateTime Date { get; set; }
        public DateTime ActualDate { get; set; }
        public string Room { get; set; }
        public int GradeNumber { get; set; }
        public string GradeLetter { get; set; }
        public string SubjectName { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public string TecaherPatronymic { get; set; }
        public string LessonTopic { get; set; }
        public string Comment { get; set; }
    }
}
