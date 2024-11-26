namespace StudentManagement_System_API.DTOS.ResponseDTOs
{
    public class Timetablesubjectresponse
    {
        public Guid Id { get; set; }
       
        public string SubjectName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


    }
}
