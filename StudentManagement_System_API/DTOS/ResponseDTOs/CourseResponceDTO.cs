namespace StudentManagement_System_API.DTOS.ResponseDtos
{
    public class CourseResponceDTO
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool  IsDeleted { get; set; }=false;

        public List<EntrollementResponceDTO> Entrollements { get; set; }
    }
}
