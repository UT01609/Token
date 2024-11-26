using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IRepository
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(Guid Id);
        Task<User> GetUserByUserId(string UserId);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid Id);
    }
}
