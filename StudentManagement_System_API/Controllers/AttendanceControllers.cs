using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IService;
using StudentManagement_System_API.Service;

namespace StudentManagement_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceControllers : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceControllers(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }
        // GET: api/Attendance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAllAttendances()
        {
            var attendances = await _attendanceService.GetAllAttendancesAsync();
            return Ok(attendances);
        }

        // GET: api/Attendance/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> GetAttendanceById(int id)
        {
            var attendance = await _attendanceService.GetAttendanceByIdAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }

        // POST: api/Attendance
        [HttpPost]
        public async Task<ActionResult> CreateAttendance([FromBody] Attendance attendance)
        {
            if (attendance == null)
            {
                return BadRequest("Attendance data is required.");
            }

            await _attendanceService.CreateAttendanceAsync(attendance);
            return CreatedAtAction(nameof(GetAttendanceById), new { id = attendance.Id }, attendance);
        }

        // PUT: api/Attendance/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAttendance(int id, [FromBody] Attendance attendance)
        {
            if (attendance == null || id != attendance.Id)
            {
                return BadRequest("Invalid attendance data.");
            }

            var existingAttendance = await _attendanceService.GetAttendanceByIdAsync(id);
            if (existingAttendance == null)
            {
                return NotFound();
            }

            await _attendanceService.UpdateAttendanceAsync(attendance);
            return NoContent(); // Success, no content to return
        }

        // DELETE: api/Attendance/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAttendance(int id)
        {
            var attendance = await _attendanceService.GetAttendanceByIdAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }

            await _attendanceService.DeleteAttendanceAsync(id);
            return NoContent(); // Success, no content to return
        }
    }
}
  
