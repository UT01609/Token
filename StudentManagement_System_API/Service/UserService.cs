  using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;
using System.Numerics;

namespace StudentManagement_System_API.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponseDTOs> CreateUser(UserRequestDTOs userRequestDTOs)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserId = userRequestDTOs.UserId,
                Name = userRequestDTOs.Name,
                Email = userRequestDTOs.Email,
                NICNumber = userRequestDTOs.NICNumber,
                PasswordHash = userRequestDTOs.Password,
                UserRole = userRequestDTOs.UserRole,


            };

            var data = await _repository.CreateUserAsync(user);

            var resuser = new UserResponseDTOs
            {
                Id = data.Id,
                UserId = data.UserId,
                Name = data.Name,
                Email = data.Email,
                NICNumber = data.NICNumber,
                Password = data.PasswordHash,
                UserRole = data.UserRole,
                IsDeleted = data.IsDelete,
            };
            return resuser;
        }

        public async Task<UserResponseDTOs> GetUserById (Guid id) 
        {
            var data = await _repository.GetUserByIdAsync(id);
            var resuser = new UserResponseDTOs
            {
                Id = data.Id,
                UserId = data.UserId,
                Name = data.Name,
                Email = data.Email,
                NICNumber = data.NICNumber,
                Password = data.PasswordHash,
                UserRole = data.UserRole,
                IsDeleted = data.IsDelete,
            };
            return resuser;
        }

        public async Task<List<UserResponseDTOs>> GetAllUsers()
        {
            var data = await _repository.GetUsersAsync();

            var resusers = data.Select(x => new UserResponseDTOs
            {
                Id = x.Id,
                UserId = x.UserId,
                Name = x.Name,
                Email = x.Email,
                NICNumber = x.NICNumber,
                Password = x.PasswordHash,
                UserRole = x.UserRole,
                IsDeleted = x.IsDelete,
            }).ToList(); ;
            return resusers;
        }

        public async Task<UserResponseDTOs> GetUserByUserId(string userId)
        {
            var data = await _repository.GetUserByUserId(userId);

            var resusers = new UserResponseDTOs
            {
                Id = data.Id,
                UserId = data.UserId,
                Name = data.Name,
                Email = data.Email,
                NICNumber = data.NICNumber,
                Password = data.PasswordHash,
                UserRole = data.UserRole,
                IsDeleted = data.IsDelete,
            };
            return resusers;
        }

        public async Task<UserResponseDTOs> UpdateUser(Guid UserId, UserRequestDTOs userrequest)
        {
            var user = new User
            {
                Id = UserId,
                UserId = userrequest.UserId,
                Name = userrequest.Name,
                Email = userrequest.Email,
                NICNumber = userrequest.NICNumber,
                PasswordHash = userrequest.Password,
                UserRole = userrequest.UserRole

            };
            var data = await _repository.UpdateUserAsync(user);

            var resUser = new UserResponseDTOs
            {
                Id = data.Id,
                UserId = data.UserId,
                Name = data.Name,
                Email = data.Email,
                NICNumber = data.NICNumber,
                Password = data.PasswordHash,
                UserRole = data.UserRole,
                IsDeleted = data.IsDelete

            };
            return resUser;
        }

        public async Task Deleteuser (Guid Id)
        {
            await _repository.DeleteUserAsync(Id);
        }
    }
}
     
