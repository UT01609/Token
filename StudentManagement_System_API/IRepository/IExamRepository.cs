using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IRepository
{
    public interface IExamRepository
    {
        Task<IEnumerable<Exam>> GetAllAsync();
        Task<Exam> GetByIdAsync(int id);
        Task AddAsync(Exam exam);
        Task UpdateAsync(Exam exam);
        Task DeleteAsync(int id);
    }
}
