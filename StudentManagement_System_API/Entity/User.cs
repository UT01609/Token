using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace StudentManagement_System_API.Entity
{
    public class User
    {
       public Guid Id { get; set; }
        public string UserId { get; set; }  
        public string Name { get; set; }
        public string NICNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        // Role as an enum (Admin, Staff, Lecturer, Student)
        public Role UserRole { get; set; }  // Single role per user

        public bool IsDelete { get; set; } = false;
    }

    public enum Role
    {
        Manager=1,
        Staff=2,
        Lecturer=3,
        Student=4
    }


}
