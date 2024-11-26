using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;

namespace StudentManagement_System_API.Service
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;

        public ExamService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task<IEnumerable<Exam>> GetAllAsync()
        {
            return await _examRepository.GetAllAsync();
        }

        public async Task<Exam> GetByIdAsync(int id)
        {
            return await _examRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Exam exam)
        {
            await _examRepository.AddAsync(exam);
        }

        public async Task UpdateAsync(Exam exam)
        {
            await _examRepository.UpdateAsync(exam);
        }

        public async Task DeleteAsync(int id)
        {
            await _examRepository.DeleteAsync(id);
        }
    }
}