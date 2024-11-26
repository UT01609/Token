using Microsoft.EntityFrameworkCore;
using StudentManagement_System_API.Database;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;

namespace StudentManagement_System_API.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly StudentManagementContext _context;

        public AttendanceRepository(StudentManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendance>> GetAllAsync()
        {
            return await _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Timetable)
                .ToListAsync();
        }

        public async Task<Attendance> GetByIdAsync(int id)
        {
            return await _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Timetable)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(Attendance attendance)
        {
            await _context.Attendances.AddAsync(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
                await _context.SaveChangesAsync();
            }
        }

        Task<IEnumerable<Attendance>> IAttendanceRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Attendance> IAttendanceRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}