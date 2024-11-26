using Microsoft.EntityFrameworkCore;
using StudentManagement_System_API.Database;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;

namespace StudentManagement_System_API.Repository
{
    public class ExamRepository : IExamRepository
    {
        private readonly StudentManagementContext _context;

        public ExamRepository(StudentManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exam>> GetAllAsync()
        {
            return await _context.Set<Exam>().ToListAsync();
        }

        public async Task<Exam> GetByIdAsync(int id)
        {
            return await _context.Set<Exam>().FindAsync(id);
        }

        public async Task AddAsync(Exam exam)
        {
            await _context.Set<Exam>().AddAsync(exam);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Exam exam)
        {
            _context.Set<Exam>().Update(exam);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exam = await _context.Set<Exam>().FindAsync(id);
            if (exam != null)
            {
                _context.Set<Exam>().Remove(exam);
                await _context.SaveChangesAsync();
            }
        }
    }
}