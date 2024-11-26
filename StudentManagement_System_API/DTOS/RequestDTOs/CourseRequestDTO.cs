namespace StudentManagement_System_API.DTOS.RequestDtos
{
    public class CourseRequestDTO
    {
        public string CourseName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
