using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.DTOS.ResponseDTOs
{
    public class MarksResponceDTO
    {

        public int Id { get; set; }
        public int ExamId { get; set; }
        public string UTNumber { get; set; }
        public int? MarksObtained { get; set; }
        public bool IsApproved { get; set; }

        // Navigation properties for related data
        public Exam? Exam { get; set; }
        public Student? Student { get; set; }
    }
}
