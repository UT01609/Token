using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.DTOS.ResponseDtos
{
    public class UserResponseDTOs
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NICNumber { get; set; }
        public Role UserRole { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
