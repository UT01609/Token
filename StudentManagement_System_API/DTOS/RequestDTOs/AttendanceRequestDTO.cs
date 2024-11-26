namespace StudentManagement_System_API.DTOS.RequestDTOs
{
    public class AttendanceRequestDTO
    {

        public int? TimetableId { get; set; } // Optional filter by timetable
        public string? UTNumber { get; set; } // Optional filter by student identifier
        public DateTime? Date { get; set; } // Optional filter by specific date
        public bool? IsPresent { get; set; } // Optional filter by attendance status
    }
}
