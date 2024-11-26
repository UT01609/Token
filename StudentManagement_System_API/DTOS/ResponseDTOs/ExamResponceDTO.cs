namespace StudentManagement_System_API.DTOS.ResponseDtos
{
    public class ExamResponceDTO
    {
        public int Id { get; set; }
        public DateTime ExamDate { get; set; }
        public int? MaximumMarks { get; set; }
        public int? CutOffMarks { get; set; }
    }
}
