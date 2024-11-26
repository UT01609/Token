namespace StudentManagement_System_API.DTOS.RequestDTOs
{
    public class TimetableRequestDtos
    {
        public DateTime Date { get; set; }
        public List<TimetableSubjectRequestDtos> Subjects { get; set; }
    }
}
