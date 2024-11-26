using Microsoft.EntityFrameworkCore;
using StudentManagement_System_API.Database;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;

namespace StudentManagement_System_API.Repository
{
    public class EnrollmentRepository: IEnrollmentRepository
    {
        private readonly StudentManagementContext _context;

        public EnrollmentRepository(StudentManagementContext context)
        {
            _context = context;
        }
        public async Task<Enrollment> AddEnrollment(Enrollment enrollment)
        {
            var data = await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();

            return enrollment;
        }
        public async Task<List<Enrollment>> GetEnrollmentById(int Id)
        {
            var data = await _context.Enrollments.Where(a => a.Id == Id).ToListAsync();
            return data;

        }
        public async Task DeleteEntrollment(int Id)
        {
            var data =await _context.Enrollments.FindAsync(Id);
            if (data != null)
            {
                _context.Enrollments.Remove(data);
                await _context.SaveChangesAsync();
            }
  
        }
    }
}
