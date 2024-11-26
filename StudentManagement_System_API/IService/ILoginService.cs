using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IService
{
    public interface ILoginService
    {
        Task<string> Register(UserRequestDTOs userRequestDTOs);
        //Task<TokenModel> Login(string UserId, string password);
    }
}
