using StudentManagement_System_API.DTOS.RequestDtos;
using StudentManagement_System_API.DTOS.ResponseDtos;
using StudentManagement_System_API.Entity;
using StudentManagement_System_API.IRepository;
using StudentManagement_System_API.IService;

namespace StudentManagement_System_API.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

       public async Task<CourseResponceDTO> AddCourse(CourseRequestDTO courseRequestDTO)
        {
            var course = new Course
            {
                CourseName = courseRequestDTO.CourseName,
                Description = courseRequestDTO.Description,
                StartDate = courseRequestDTO.StartDate,
                EndDate = courseRequestDTO.EndDate,

            };
            var data = await _courseRepository.AddCourses(course);
            var resCourse = new CourseResponceDTO
            {
                Id = data.Id,
                CourseName = data.CourseName,
                Description = data.Description,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                IsDeleted = data.IsDeleted,

            };
            return resCourse;
        }

        public async Task<List<CourseResponceDTO>> GetAllCourses()
        {
            var data = await _courseRepository.GetallCourses();
           var rescoures = data.Select(c => new CourseResponceDTO
           {
               Id= c.Id,
               CourseName = c.CourseName,
               Description = c.Description,
               StartDate = c.StartDate,
               EndDate = c.EndDate,
               IsDeleted = c.IsDeleted,
               Entrollements = c.Enrollments? .Select(e => new EntrollementResponceDTO
               {
                   Id = e.Id,
                   EnrolledDate = e.EnrolledDate
               }).ToList()
           }).ToList();
            return rescoures;
          
        }
        public async Task<CourseResponceDTO> GetCourseById(int id)
        {
            var data = await _courseRepository.GetCourseById(id);
            var resCourse = new CourseResponceDTO
            {
                Id = data.Id,
                CourseName = data.CourseName,
                Description = data.Description,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                IsDeleted = data.IsDeleted,
                Entrollements = data.Enrollments?.Select(e => new EntrollementResponceDTO
                {
                    Id = e.Id,
                    EnrolledDate = e.EnrolledDate
                }).ToList()
            };
            return resCourse;
        }

        public async Task<CourseResponceDTO?> UpdateCoures(int id, CourseRequestDTO courseRequest)
        {
            // Retrieve the existing course
            var existingCourse = await _courseRepository.GetCourseById(id);
            if (existingCourse == null)
            {
                return null; // Alternatively, throw an exception for a better error response
            }

            // Update the existing course with values from the request DTO
            existingCourse.CourseName = courseRequest.CourseName;
            existingCourse.Description = courseRequest.Description;
            existingCourse.StartDate = courseRequest.StartDate;
            existingCourse.EndDate = courseRequest.EndDate;

            // Save the updated course to the database
            var updatedCourse = await _courseRepository.UpadteCourse(existingCourse);

            // Map the updated entity to the response DTO
            var responseCourse = new CourseResponceDTO
            {
                Id = updatedCourse.Id,
                CourseName = updatedCourse.CourseName,
                Description = updatedCourse.Description,
                StartDate = updatedCourse.StartDate,
                EndDate = updatedCourse.EndDate,
                IsDeleted = updatedCourse.IsDeleted
            };

            return responseCourse;
        }


        public async Task DeleteCourse(int Id)
        {
            await _courseRepository.DeleteCourse(Id);
        }


        
    }
}
