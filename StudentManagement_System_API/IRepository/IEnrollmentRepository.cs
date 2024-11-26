using StudentManagement_System_API.Entity;

namespace StudentManagement_System_API.IRepository
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment> AddEnrollment(Enrollment enrollment);
        Task<List<Enrollment>> GetEnrollmentById(int Id);
        Task DeleteEntrollment(int Id);

    }
}
