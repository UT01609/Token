using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.IService;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }



        [HttpGet("GetStudentById")]
        public async Task<IActionResult> GetStudentById(string utNumber)
        {
            var student = await _studentService.GetStudentById(utNumber);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }


        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudent()
        {
            var students = await _studentService.GetAllStudent();
            return Ok(students);
        }


        [HttpPost("AddStudent")]
        public async Task<IActionResult> CreateStudent(StudentRequestDTO studentRequestDto)
        {
            var data = await _studentService.CreateStudent(studentRequestDto); 
            return Ok(data);
        }



        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(string utnumber,StudentRequestDTO studentRequestDto)
        {
            var student = await _studentService.UpdateStudent(utnumber,studentRequestDto);
            return Ok(student);
        }

        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(string utNumber)
        {
            var result = await _studentService.DeleteStudent(utNumber);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
