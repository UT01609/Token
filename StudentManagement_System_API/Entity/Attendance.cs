namespace StudentManagement_System_API.Entity
{
    public class Attendance
    {
        public int Id { get; set; }  // Primary Key
        public Guid TimetableId { get; set; }  // Foreign Key from Timetable
        public string UTNumber { get; set; }  // Foreign Key from Student
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }  // Present or Absent
        // Navigation properties
        public Timetable? Timetable { get; set; }
        public Student? Student { get; set; }
    }
 }
