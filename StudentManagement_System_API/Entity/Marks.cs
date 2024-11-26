namespace StudentManagement_System_API.Entity
{
    public class Marks
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string UTNumber { get; set; }
        public int? MarksObtained { get; set; }
        public bool IsApproved { get; set; } // Pending or Approved

        // Navigation properties for relationships
        public Exam? Exam { get; set; }
        public Student? Student { get; set; }
    }

}
