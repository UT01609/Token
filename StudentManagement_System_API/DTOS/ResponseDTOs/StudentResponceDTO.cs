using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.DTOS.ResponseDTOs
{
    public class StudentResponceDTO
    {
        public string UTNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NICNumber { get; set; }
        public string Batch { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}
