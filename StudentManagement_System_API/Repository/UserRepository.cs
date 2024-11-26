using Microsoft.EntityFrameworkCore;
using StudentManagement_System_API.Database;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;

namespace StudentManagement_System_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StudentManagementContext _context;

        public UserRepository(StudentManagementContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var data = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var data = await _context.Users.Where(a => !a.IsDelete).ToListAsync();
            return data;
        }

        public async Task<User> GetUserByIdAsync(Guid Id)
        {
            var data = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            return data;
        }

        public async Task<User> GetUserByUserId (string UserId)
        {
            var data = await _context.Users.FirstOrDefaultAsync(x => x.UserId == UserId && !x.IsDelete);
            return data;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var data = await GetUserByIdAsync(user.Id);

            if (data == null) return null;
            
            data.UserId = user.UserId;
            data.Name = user.Name;
            data.Email = user.Email;
            data.NICNumber = user.NICNumber;
            data.PasswordHash = user.PasswordHash;
            data.UserRole = user.UserRole;

            await _context.SaveChangesAsync();

            return data;


        }

        public async Task DeleteUserAsync(Guid Id)
        {
            var data = await GetUserByIdAsync(Id);
            if (data != null)
            {
                data.IsDelete = true;
                _context.Users.Update(data);
                await _context.SaveChangesAsync();

            }

        }
    }
}
