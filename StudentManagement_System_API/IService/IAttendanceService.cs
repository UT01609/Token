using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IService
{
    public interface IAttendanceService
    {
        Task<IEnumerable<Attendance>> GetAllAttendancesAsync();
        Task<Attendance> GetAttendanceByIdAsync(int id);
        Task CreateAttendanceAsync(Attendance attendance);
        Task UpdateAttendanceAsync(Attendance attendance);
        Task DeleteAttendanceAsync(int id);
    }
}
