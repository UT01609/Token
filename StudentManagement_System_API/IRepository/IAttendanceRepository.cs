using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IRepository
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAllAsync();
        Task<Attendance> GetByIdAsync(int id);
        Task AddAsync(Attendance attendance);
        Task UpdateAsync(Attendance attendance);
        Task DeleteAsync(int id);
    }
}
