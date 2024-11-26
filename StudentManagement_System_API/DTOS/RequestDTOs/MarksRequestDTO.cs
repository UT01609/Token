namespace StudentManagement_System_API.DTOS.RequestDTOs
{
    public class MarksRequestDTO
    {

        public int? ExamId { get; set; } // Filter by ExamId
        public string? UTNumber { get; set; } // Filter by UTNumber
        public bool? IsApproved { get; set; } // Filter by IsApproved status
    }
}
