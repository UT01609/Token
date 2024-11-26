using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentManagement_System_API.Database;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Repository;
using StudentManagement_System_API.Service;
using System.Text;
using System.Text.Json.Serialization;


namespace StudentManagement_System_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add services to the container.


           builder.Services.AddControllers()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
             });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StudentManagementContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("StudentDBConnection")));

            var jwtSettings = builder.Configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

         
            builder.Services.AddScoped<ITimetableRepository, TimeTableRepository>();
            builder.Services.AddScoped<ITimetableService, TimetableService>();

            builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            builder.Services.AddScoped<IAttendanceService, AttendanceService>();

            builder.Services.AddScoped<IExamRepository, ExamRepository>();
            builder.Services.AddScoped<IExamService, ExamService>();


            builder.Services.AddScoped <ICourseRepository,CourseRepository>();
            builder.Services.AddScoped<ICourseService,CourseService>();

            builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            builder.Services.AddScoped<IEntrollementService, EnrollmentService>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ILoginRepository, LoginRepository>();
            builder.Services.AddScoped<ILoginService, LoginService>();

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentService, StudentService>();


            builder.Services.AddAuthentication()
              .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });


            var app = builder.Build();
            if (app.Environment.IsDevelopment()) // This condition is important for Swagger UI in Dev environment
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("CORSPolicy");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
