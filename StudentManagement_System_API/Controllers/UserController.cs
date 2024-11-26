using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.IService;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequestDTOs userRequestDTOs)
        {
            var data = await _userService.CreateUser(userRequestDTOs);
            return Ok(data);
        }

        [HttpGet("Get_user")]
        public async Task<IActionResult> GetAllUsers()
        {
            var data = await _userService.GetAllUsers();
            return Ok(data);
        }
        [HttpGet("{Id}")]

        public async Task<IActionResult> GetUserId(Guid Id)
        {
            var data = await _userService.GetUserById(Id);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserUserId(string UserId)
        {
            var data = await _userService.GetUserByUserId(UserId);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Updateuser(Guid Id, UserRequestDTOs userRequestDTOs)
        {
            var data = await _userService.UpdateUser(Id, userRequestDTOs);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> Deleteuser(Guid Id)
        {
            await _userService.Deleteuser(Id);
            return NoContent();
        }
    }
}
