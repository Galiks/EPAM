namespace CalendarThematicPlan.Entity
{
    public class UserSubject
    {
        public int? Id { get; set; }
        public int IdSubject { get; set; }
        public int IdUser { get; set; }

        public override string ToString()
        {
            return $"{Id} {IdSubject} {IdUser}";
        }
    }
}
