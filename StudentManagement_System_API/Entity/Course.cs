using System.Xml;

namespace StudentManagement_System_API.Entity
{
    public class  Course  
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Navigation properties
        public ICollection<Enrollment> Enrollments { get; set; }  // Many-to-many with Student via Enrollment
        public ICollection<Exam> Exams { get; set; }  // One-to-many with Exam
        public ICollection<Timetable> Timetables { get; set; }  // One-to-many with Timetable
    }

}
