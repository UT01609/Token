using StudentManagement_System_API.DTOS.ResponseDTOs;

namespace StudentManagement_System_API.DTOS.ResponseDtos
{
    public class TimetableResponceDTO
    {
        internal List<Timetablesubjectresponse>? timetablesubjectresponses;

        public Guid Id { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
       
    }
}
