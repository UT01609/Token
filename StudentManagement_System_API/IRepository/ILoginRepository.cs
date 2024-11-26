

using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IRepository
{
    public interface ILoginRepository
    {
        Task<User> AddUser(User user);
        //Task<User> GetUserById(string email);
        
    }
}
