namespace StudentManagement_System_API.Entity
{
    public class Exam
    {
        public int Id { get; set; }  // Primary Key
        public int CourseId { get; set; }  // Foreign Key from Course
        public DateTime ExamDate { get; set; }
        public int? MaximumMarks { get; set; }
        public int? CutOffMarks { get; set; }


        // Navigation properties
        public Course Course { get; set; }  // One-to-many with Course
        public ICollection<Marks>? Marks { get; set; }  // One-to-many with Marks
    }

}
