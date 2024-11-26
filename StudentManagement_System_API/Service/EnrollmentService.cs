using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;

namespace StudentManagement_System_API.Service
{
    public class EnrollmentService : IEntrollementService
    {
        private readonly IEnrollmentRepository _enrollement;

        public EnrollmentService(IEnrollmentRepository enrollement)
        {
            _enrollement = enrollement;
        }

        public async Task<EntrollementResponceDTO> AddEntrollement(int CourseId,EntrollementRequestDTO requestDTO)
        {
            var enroll = new Enrollment
            {
                CourseId = CourseId,
                EnrolledDate = requestDTO.EnrolledDate,
            };
            var data = await _enrollement.AddEnrollment(enroll);

            var resentroll = new EntrollementResponceDTO
            {
                Id = data.Id,
                EnrolledDate = data.EnrolledDate,
            };
            return resentroll;
        }

        public async Task<List<EntrollementResponceDTO>> GetEnrollmentById( int CourseId)
        {
           var ent = await _enrollement.GetEnrollmentById(CourseId);

            var resEnt = ent.Select(a => new EntrollementResponceDTO
            {
                Id=a.Id,
                EnrolledDate = a.EnrolledDate
            }).ToList();
            return resEnt;

        }
        public async Task Delete(int CourseId)
        {
            await _enrollement.DeleteEntrollment(CourseId);
        }

    }
}
