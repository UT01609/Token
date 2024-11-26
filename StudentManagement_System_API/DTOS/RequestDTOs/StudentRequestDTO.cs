namespace StudentManagement_System_API.DTOS.RequestDTOs
{
    public class StudentRequestDTO
    {
        public string UTNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NICNumber { get; set; }
        public string Batch { get; set; }
        public int UserId { get; set; }
    }
}
