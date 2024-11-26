using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IService;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("Register/Staff")]
        public async Task<IActionResult> UserRegister(UserRequestDTOs userRequest)
        {
       
                var result = await _loginService.Register(userRequest);
                return Ok(result);
        
        }


        //[HttpPost("Login")]
        //public async Task<IActionResult> UserLogin(string userId, string password)
        //{
        //    try
        //    {
        //        var result = await _loginService.Login(userId, password);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [Authorize]
        [HttpGet("Check")]
        public async Task<IActionResult> CheckAPI()
        {
            try
            {
                var userrole = User.FindFirst("UserRole").Value;
                return Ok(userrole);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

