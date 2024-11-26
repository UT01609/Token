using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Service;
using System.Runtime.InteropServices;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseControllers : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseControllers(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        [Route("Add-Course")]
        public async Task<IActionResult> AddCourse(CourseRequestDTO courseRequestDTO)
        {
            var data = await _courseService.AddCourse(courseRequestDTO);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            var data = await _courseService.GetAllCourses();
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCourseById(int Id)
        {
            var data = await _courseService.GetCourseById(Id);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoures(int Id, CourseRequestDTO courseRequestDTO)
        {
            var data = await _courseService.UpdateCoures(Id, courseRequestDTO);
            return Ok(data);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCourse(int Id)
        {
            await _courseService.DeleteCourse(Id);
            return NoContent();
        }
    }
}