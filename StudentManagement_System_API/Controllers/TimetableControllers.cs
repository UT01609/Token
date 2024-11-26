using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.RequestDTOs;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Service;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimetableControllers : ControllerBase
    {
        private readonly ITimetableService _timetableService;

        public TimetableControllers(ITimetableService timetableService)
        {
            _timetableService = timetableService;
        }

        [HttpPost]

        public async Task<IActionResult> CreateTimetable(int CourseId, TimetableRequestDtos timetableRequestDTO)
        {
            var createdTable = await _timetableService.CreateTable(CourseId, timetableRequestDTO);
            return Ok(createdTable);
        }


        [HttpGet("{date}")]

        public async Task<IActionResult> GetTable(DateTime date)
        {
            var table = await _timetableService.GetTimetableByDate(date);
            if (table == null) return NotFound();

            return Ok(table);
        }

        [HttpPut("{date}")]

        public async Task<IActionResult> UpdateTable(DateTime date, TimetableRequestDtos TimetableRequestDTO)
        {
            await _timetableService.UpdateTimetable(date, TimetableRequestDTO);
            return NoContent();
        }

        [HttpDelete("{date}")]

        public async Task<IActionResult> DeleteTable(DateTime date)
        {
            await _timetableService.DeleteTable(date);
            return NoContent();
        }
    }
}
