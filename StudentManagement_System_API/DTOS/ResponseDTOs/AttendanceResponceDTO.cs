using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.DTOS.ResponseDTOs
{
    public class AttendanceResponceDTO
    {
        public int Id { get; set; }
        public Guid TimetableId { get; set; }
        public string UTNumber { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }

        // Navigation property details
        public Timetable? Timetable { get; set; }
        public Student? Student { get; set; }
    }
}
