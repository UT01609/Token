namespace StudentManagement_System_API.DTOS.RequestDtos
{
    public class ExamRequestDTO
    {
        public DateTime ExamDate { get; set; }
        public int? MaximumMarks { get; set; }
        public int? CutOffMarks { get; set; }
    }
}
