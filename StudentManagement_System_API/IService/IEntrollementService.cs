using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;

namespace StudentManagement_System_API.IService
{
    public interface IEntrollementService
    {
        Task<EntrollementResponceDTO> AddEntrollement(int CourseId, EntrollementRequestDTO requestDTO);
        Task<List<EntrollementResponceDTO>> GetEnrollmentById(int CourseId);
        Task Delete(int CourseId);
    }
}
