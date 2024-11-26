namespace StudentManagement_System_API.Entity
{
    public class TimetableSubject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
