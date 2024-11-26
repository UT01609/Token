using Microsoft.IdentityModel.Tokens;
using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentManagement_System_API.Service
{
    public class LoginService : ILoginService
    {

        private readonly ILoginRepository _loginRepository;
        private readonly IConfiguration _configuration;
        public LoginService(ILoginRepository loginRepository, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
        }

        public async Task<string> Register(UserRequestDTOs userRequestDTOs)
        {
            var req = new User
            {
                Name = userRequestDTOs.Name,
                Email = userRequestDTOs.Email,
                NICNumber = userRequestDTOs.NICNumber,
                UserRole = userRequestDTOs.UserRole,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRequestDTOs.Password)
            };
            var user = await _loginRepository.AddUser(req);
            var token = CreateToken(user);
            return token;

        }

        //public async Task<TokenModel> AddStudent(StudentRegisterRequest studentRequest)
        //{
        //    var req = new User
        //    {
        //        UserId = studentRequest.UTNumber,
        //        PasswordHash = studentRequest.Password,


        //    };
        //    var student = await _loginRepository.AddUser(req);
        //    var token = CreateToken(student);
        //    return token;
        //}

        //public async Task<TokenModel> Login(string UserId, string password)
        //{
        //    var user = await _loginRepository.GetUserById(UserId);
        //    if (user == null)
        //    {
        //        throw new Exception("User Not Found!");
        //    }
        //    if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        //    {
        //        throw new Exception("Wrong Password!");
        //    }
        //    return CreateToken(user);
        //}

        private string CreateToken(User user)
        {
            var claimsList = new List<Claim>();
            
               claimsList.Add(new Claim("Id",user.Id.ToString()));
               claimsList.Add(new Claim("Name", user.Name));
               claimsList.Add(new Claim("Email", user.Email));
               claimsList.Add(new Claim("NICNumber", user.NICNumber));
               claimsList.Add(new Claim("UserRole", user.Id.ToString()));
            

            var Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var credintials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
               claims: claimsList,
               expires: DateTime.Now.AddDays(30),
               signingCredentials: credintials
               );
            return new JwtSecurityTokenHandler().WriteToken(token);

            //var token = new JwtSecurityToken(
            //    issuer:_configuration["Jwt:Issuer"], 
            //    audience:_configuration["Jwt:Audience"],
            //    claims: claimsList,
            //    expires: DateTime.Now.AddDays(30),
            //    signingCredentials: credintials
            //    );
            //var responce = new TokenModel
            //{
            //    Token = new JwtSecurityTokenHandler().WriteToken(token)
            //};
            //return responce;
        }

        private TokenModel CreateToken(Student student)
        {
            var claimsList = new List<Claim>();

            claimsList.Add(new Claim("UTNumber", student.UTNumber.ToString()));
            claimsList.Add(new Claim("Batch", student.Batch));
            


            var Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var credintials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claimsList,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credintials
                );
            var responce = new TokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return responce;
        }
    }
}

